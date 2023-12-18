//using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
//using NLog;
//using NLog.Web;

// Early init of NLog to allow startup and exception logging, before host is built
//var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
//var logger = LogManager
//logger.Debug("init main"); 

var builder = WebAssemblyHostBuilder.CreateDefault(args);

await builder.Build().RunAsync();
