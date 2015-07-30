using Nancy.Bootstrappers.Autofac;
using Nancy.Conventions;

namespace QuartzWebAdmin
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        /// <summary>
        /// Overrides/configures Nancy's conventions
        /// </summary>
        /// <param name="nancyConventions">Convention object instance</param>
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions
                .StaticContentsConventions
                .Add(StaticContentConventionBuilder.AddDirectory("extLib", "lib"));
        }
    }
}