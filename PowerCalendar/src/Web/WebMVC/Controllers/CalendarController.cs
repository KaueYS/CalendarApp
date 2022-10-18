using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class CalendarController : ControllerBase
    {
        [HttpGet]
        public async Task<List<CalendarEventDTO>> GetEvents()
        {
            List<CalendarEventDTO> calendarEvents = new List<CalendarEventDTO>();
            CalendarEventDTO calendarEvent = new CalendarEventDTO();
            
            calendarEvent.Title = "Consulta";
            calendarEvent.Start = "2014-10-07T06:00:00";
            calendarEvent.End = "2014-10-07T08:00:00";
            calendarEvent.Class = "bg-success-lighter";
            calendarEvents.Add(calendarEvent);

            calendarEvent = new CalendarEventDTO();
            calendarEvent.Title = "Exames";
            calendarEvent.Start = "2014-10-07T08:00:00";
            calendarEvent.End = "2014-10-07T09:00:00";
            calendarEvent.Class = "bg-success-lighter";
            calendarEvents.Add(calendarEvent);

            return await Task.FromResult(calendarEvents);
             
        }
    }
}
