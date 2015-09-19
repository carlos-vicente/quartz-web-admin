using System;
using Quartz;
using Quartz.Impl;
using QuartzJobs;

namespace QuartzConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var sched = StdSchedulerFactory.GetDefaultScheduler();

            // define the job and tie it to our HelloJob class
            var job = JobBuilder
                .Create<HelloJob>()
                .WithIdentity("myJob", "group1")
                .StoreDurably()
                .Build();

            var complexJob = JobBuilder
                .Create<ComplexJob>()
                .WithIdentity("myComplexJob", "group2")
                .StoreDurably()
                .UsingJobData("key1", "value1")
                .UsingJobData("key2", "value2")
                .UsingJobData("key3", "value3")
                .UsingJobData("key4", "value4")
                .Build();

            // Trigger the job to run now, and then every 40 seconds
            var simpletrigger = TriggerBuilder
                .Create()
                .ForJob(job.Key)
                .WithIdentity("mySimpleTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(40)
                    .RepeatForever())
                .Build();

            var cronTrigger = TriggerBuilder
                .Create()
                .ForJob(job.Key)
                .WithIdentity("myCronTrigger", "group1")
                .WithCronSchedule("0 0/5 * * * ?")
                .Build();

            var cronComplexTrigger = TriggerBuilder
                .Create()
                .ForJob(complexJob.Key)
                .WithIdentity("myCronComplexTrigger", "group2")
                .WithCronSchedule("0 0/1 * * * ?")
                .Build();

            // Tell quartz to schedule the job using our trigger
            sched.AddJob(job, true);
            sched.AddJob(complexJob, true);

            sched.ScheduleJob(simpletrigger);
            sched.ScheduleJob(cronTrigger);
            sched.ScheduleJob(cronComplexTrigger);

            sched.Start();

            Console.ReadKey();

            sched.Shutdown();
        }
    }
}
