using BlazorApp1.Client.Models;
using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace BlazorApp1.Data.Endpoints
{
    public static class Endpoints
    {
        public static void MapSchedulerEndpoints(this WebApplication app)
        {
            app.MapGet("api/appointmentStands", AppointmentStandsGetHandler);
            app.MapPost("api/appointmentStands", AppointmentStandsPostHandler);
            app.MapDelete("api/appointmentStands", AppointmentStandsDeleteHandler);
            app.MapPut("api/appointmentStands", AppointmentStandsPutHandler);
            
            app.MapGet("api/stands", StandsHandler);
            app.MapPost("api/stands", StandsHandler);
            app.MapDelete("api/stands", StandsHandler);
            app.MapPut("api/stands", StandsHandler);
            
            app.MapGet("api/user", UserHandler);
        }

        private static async Task<IResult> UserHandler(HttpContext context, [FromServices] UserManager<ApplicationUser> userManager)
        {
            var user = await userManager.GetUserAsync(context.User);
            if (user == null)
            {
                return Results.Ok("");
            }
            return Results.Ok(user.Id);
        }

        private static IResult AppointmentStandsGetHandler(HttpContext context, [FromServices] ApplicationDbContext dbcontext)
        {
            try
            {
                
                var standAppointments = dbcontext.ScheduledStands
                    .Include(x => x.Scheduler)
                    .Include(x => x.Stand)
                    .Include(x => x.User)
                    .Select(x => new AppointmentStand(x.Id, x.Stand.Id, x.Stand.Name, x.SchedulerId,
                            x.User.StudentGroupId, x.User.Id,
                            TimeZoneInfo.ConvertTimeFromUtc(x.SessionStartTime.DateTime, TimeZoneInfo.Local),
                            TimeZoneInfo.ConvertTimeFromUtc(x.SessionEndTime.DateTime, TimeZoneInfo.Local)))
                    .ToList();

                return Results.Ok(standAppointments);
            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Can't get stands. Get error: {ex.Message}");
            }
        }

        private static async Task<IResult> AppointmentStandsPostHandler(HttpContext context, [FromBody] AppointmentStand? appointmentStand,
            [FromServices] UserManager<ApplicationUser> userManager, [FromServices] ApplicationDbContext dbcontext)
        {
            var user = await userManager.GetUserAsync(context.User);
            var stands = dbcontext.ScheduledStands
                .ToList();

            try
            {
                if (!dbcontext.Stand.Any(x => x.Id == appointmentStand.StandId))
                    return Results.BadRequest("No stand was found to schedule");
                if (stands.FirstOrDefault(x => x.UserId == user.Id) == null)
                {
                    await dbcontext.ScheduledStands.AddAsync(new ScheduledStand
                    {
                        StandId = appointmentStand.StandId,
                        UserId = user.Id,
                        Id = Guid.NewGuid().ToString(),
                        SessionStartTime = appointmentStand.StartAppointment.ToUniversalTime(),
                        SessionEndTime = appointmentStand.EndAppointment.ToUniversalTime()
                    });
                    await dbcontext.SaveChangesAsync();
                }
                else
                {
                    return Results.BadRequest($"{user.UserName} already have one appointment");
                }
                return Results.Ok(stands);
            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Failed to add stand. Get exeption: {ex.Message}");
            }
        }

        private static async Task<IResult> AppointmentStandsDeleteHandler(HttpContext context, [FromQuery] string? id, [FromBody] AppointmentStand? appointmentStand,
        [FromServices] UserManager<ApplicationUser> userManager, [FromServices] ApplicationDbContext dbcontext)
        {
            var user = await userManager.GetUserAsync(context.User);
            var stands = dbcontext.ScheduledStands
                .ToList();

            try
            {
                var standToRemove = dbcontext.ScheduledStands
                    .Include(x => x.Stand)
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                if (standToRemove == null)
                    return Results.BadRequest("Stand does not exist");
                dbcontext.Remove(standToRemove);
                await dbcontext.SaveChangesAsync();
                return Results.Ok($"Scheduled stand {standToRemove.Stand.Name} was removed from");
            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Failed to remove scheduled stand. Get exeption: {ex.Message}");
            }
        }

        private static async Task<IResult> AppointmentStandsPutHandler(HttpContext context, [FromBody] AppointmentStand? appointmentStand,
        [FromServices] UserManager<ApplicationUser> userManager, [FromServices] ApplicationDbContext dbcontext)
        {
            var user = await userManager.GetUserAsync(context.User);
            var stand = ScheduledStand.GetFromAppointmentStand(appointmentStand);
            try
            {
                dbcontext.Attach(stand!).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return Results.Ok($"Scheduled stand with id {stand.Id} was successfully edited");
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }

        private static bool Equal(this ScheduledStand stand, AppointmentStand appointmentStand)
        {
            return stand.StandId == appointmentStand.StandId
                && stand.UserId == appointmentStand.UserId
                && stand.SessionStartTime == appointmentStand.StartAppointment.ToUniversalTime()
                && stand.SessionEndTime == appointmentStand.EndAppointment.ToUniversalTime();
        }

        private static IResult StandsHandler(HttpContext context, [FromServices] ApplicationDbContext dbcontext)
        {
            switch (context.Request.Method)
            {
                case "GET":
                    var stands = dbcontext.Stand
                        .ToList();
                    return Results.Ok(stands);
                case "POST":
                    return Results.BadRequest("Not implemented request for api");
                case "PUT":
                    return Results.BadRequest("Not implemented request for api");
                case "DELETE":
                    return Results.BadRequest("Not implemented request for api");
                default:
                    return Results.BadRequest("Unknown method for api request");
            }
        }
    }
}
