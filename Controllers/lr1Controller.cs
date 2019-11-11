using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using to.Models;
using to.Storage;
namespace to.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class LabController : ControllerBase
   {
       

       //private static IStorage<lr1Data> _memCache = new MemCache();
       private IStorage<lr1Data> _memCache;

       public LabController(IStorage<lr1Data> memCache)
       {
           _memCache = memCache;
       }

       [HttpGet]
       public ActionResult<IEnumerable<lr1Data>> Get()
       {
           return Ok(_memCache.All);
       }

       [HttpGet("{id}")]
       public ActionResult<lr1Data> Get(Guid id)
       {
           if (!_memCache.Has(id)) return NotFound("No such");

            return Ok(_memCache[id]);
       }

       [HttpPost]
       public IActionResult Post([FromBody] lr1Data value)
       {
           var validationResult = value.Validate();

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            _memCache.Add(value);

            return Ok($"{value.ToString()} has been added");
       }

       [HttpPut("{id}")]
       public IActionResult Put(Guid id, [FromBody] lr1Data value)
       {
           if (!_memCache.Has(id)) return NotFound("No such");

            var validationResult = value.Validate();

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var previousValue = _memCache[id];
            _memCache[id] = value;

            return Ok($"{previousValue.ToString()} has been updated to {value.ToString()}");
       }

       [HttpDelete("{id}")]
       public IActionResult Delete(Guid id)
       {
          if (!_memCache.Has(id)) return NotFound("No such");

            var valueToRemove = _memCache[id];
            _memCache.RemoveAt(id);

            return Ok($"{valueToRemove.ToString()} has been removed");
       }
   }

}
