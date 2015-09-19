using System;
using Quartz;

namespace QuartzJobs
{
    public class ComplexJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Complex one");
        }
    }
}
