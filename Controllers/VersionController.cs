using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using to.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Serilog;
namespace to.Controllers
{

   [Route("api/[controller]")]
   [ApiController]
   public class VersionController : ControllerBase
   {
       // GET api/values
       [HttpGet]
       public ActionResult<string> Get()
       {
           Log.Information("Acquiring version info");
           Log.Warning("Some warning");
           Log.Error("Here comes an error");
            var versionInfo = new Version1
            {
                Company = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company,
                Product = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product,
                ProductVersion = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion
            };
            Log.Information($"Acquired version is {versionInfo.ProductVersion}");
            Log.Debug($"Full version info: {@versionInfo}");
 
           //return Ok(Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion);
        return Ok(versionInfo);
       }
   }
}


