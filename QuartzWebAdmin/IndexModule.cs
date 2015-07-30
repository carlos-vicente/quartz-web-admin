namespace QuartzWebAdmin
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters => View["index"];
            Get["/Jobs"] = parameters => View["index"];
            Get["/Triggers"] = parameters => View["index"];
        }
    }
}