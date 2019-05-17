using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using to.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

   [Route("api/[controller]")]
   [ApiController]
   public class VersionController : ControllerBase
   {
       // GET api/values
       [HttpGet]
       public ActionResult<string> Get()
       {
            var versionInfo = new Version
            {
                Company = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company,
                Product = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product,
                ProductVersion = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion
            };
           //return Ok(Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion);
        return Ok(versionInfo);
       }
   }


