using System;
using Quartz;

namespace QuartzJobs
{
    public class HelloJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Executed");
        }
    }
}
