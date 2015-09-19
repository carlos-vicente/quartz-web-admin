using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Nancy;
using Quartz;

namespace QuartzWebAdmin.Modules
{
    public class IndexModule : NancyModule
    {
        private readonly IScheduler _scheduler;

        public IndexModule(IScheduler scheduler)
        {
            _scheduler = scheduler;
            Get["/", true] = GetCalendars;
        }

        public async Task<dynamic> GetCalendars(dynamic parameters, CancellationToken token)
        {
            var calendarNames = _scheduler.GetCalendarNames();

            var calendars = await Task.FromResult(calendarNames
                .AsParallel()
                .Select(_scheduler.GetCalendar));

            return View["index"];
        }
    }
}