using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Nancy;
using Quartz;
using Quartz.Impl.Matchers;
using QuartzWebAdmin.ViewModels;

namespace QuartzWebAdmin.Modules
{
    public class JobsModule : NancyModule
    {
        private readonly IScheduler _scheduler;

        public JobsModule(IScheduler scheduler)
            : base("Jobs")
        {
            _scheduler = scheduler;

            Get["/", true] = GetJobs;
            Get["/{groupName}", true] = GetJobsForGroup;
        }

        private async Task<dynamic> GetJobs(dynamic parameters, CancellationToken token)
        {
            var groupNames = _scheduler.GetJobGroupNames();

            // getting all jobs with group information
            var quartzJobdetails = groupNames
                .AsParallel()
                .SelectMany(gn =>
                {
                    var groupMatcher = GroupMatcher<JobKey>.GroupContains(gn);
                    var jobKeys = _scheduler.GetJobKeys(groupMatcher);

                    return jobKeys.Select(_scheduler.GetJobDetail);
                })
                .ToList();

            // map to view model
            var jobDetails = quartzJobdetails
                .Select(jb => new JobDetail
                {
                    JobName = jb.Key.Name,
                    JobGroup = jb.Key.Group,
                    Description = jb.Description,
                    JobType = jb.JobType,
                    JobDataMap = jb.JobDataMap,
                    Durable = jb.Durable
                })
                .ToList();

            return Negotiate
                .WithView("jobs")
                .WithModel(jobDetails);
        }

        private async Task<dynamic> GetJobsForGroup(dynamic parameters, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}