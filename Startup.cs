using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using to.Storage;
using to.Models;


namespace to
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddMvc();

           switch (Configuration["Storage:Type"].ToStorageEnum())
           {
               case StorageEnum.MemCache:
                   services.AddSingleton<IStorage<lr1Data>, MemCache>();
                   break;
               case StorageEnum.FileStorage:
                   services.AddSingleton<IStorage<lr1Data>>(
                       x => new FileStorage(Configuration["Storage:FileStorage:Filename"], int.Parse(Configuration["Storage:FileStorage:FlushPeriod"])));
                   break;
               default:
                   throw new IndexOutOfRangeException($"Storage type '{Configuration["Storage:Type"]}' is unknown");
           }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
