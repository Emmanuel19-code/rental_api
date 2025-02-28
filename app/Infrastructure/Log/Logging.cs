using Serilog;
using Serilog.Formatting.Json;

namespace app.Infrastructure.Log
{
    public static class ApplicationLogger
    {
        public static void LoggerConfiguration(this IHostBuilder host)
        {
             host.UseSerilog((ctx,lc)=>{
                lc.WriteTo.Console();
                //lc.WriteTo.Seq("");
                lc.WriteTo.File(new JsonFormatter(),"log.txt");
            });
        }
    }
}