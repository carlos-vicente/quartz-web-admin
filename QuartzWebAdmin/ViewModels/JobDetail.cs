using System;
using System.Collections.Generic;

namespace QuartzWebAdmin.ViewModels
{
    //public interface IJobDetail : ICloneable
    //{
    //    /// <summary>
    //    /// Whether the associated Job class carries the <see cref="T:Quartz.PersistJobDataAfterExecutionAttribute"/>.
    //    /// 
    //    /// </summary>
    //    /// <seealso cref="T:Quartz.PersistJobDataAfterExecutionAttribute"/>
    //    bool PersistJobDataAfterExecution { get; }

    //    /// <summary>
    //    /// Whether the associated Job class carries the <see cref="T:Quartz.DisallowConcurrentExecutionAttribute"/>.
    //    /// 
    //    /// </summary>
    //    /// <seealso cref="T:Quartz.DisallowConcurrentExecutionAttribute"/>
    //    bool ConcurrentExecutionDisallowed { get; }

    //    /// <summary>
    //    /// Set whether or not the <see cref="T:Quartz.IScheduler"/> should re-Execute
    //    ///             the <see cref="T:Quartz.IJob"/> if a 'recovery' or 'fail-over' situation is
    //    ///             encountered.
    //    /// 
    //    /// </summary>
    //    /// 
    //    /// <remarks>
    //    /// If not explicitly set, the default value is <see langword="false"/>.
    //    /// 
    //    /// </remarks>
    //    /// <seealso cref="P:Quartz.IJobExecutionContext.Recovering"/>
    //    bool RequestsRecovery { get; }
    //}

    public class JobDetail
    {
        public string JobName { get; set; }
        public string JobGroup { get; set; }
        public string Description { get; set; }
        public Type JobType { get; set; }
        public IDictionary<string, object> JobDataMap { get; set; }
        public bool Durable { get; set; }
    }
}