using SharedInfrastructure.Extensions;

using TestApp.Infrastructure;

namespace TestApp.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddSharedInfrastructure(AppDomain.CurrentDomain.Load("TestApp.Domain"));
            builder.AddTestAppInfrastructure();

            var app = builder.Build();

            app.UseTestAppInfrastructure();
            app.UseSharedInfrastructure();

            app.Run();
        }
    }
}