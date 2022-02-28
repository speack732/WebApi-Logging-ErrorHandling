using DataAccess.Example.Core;
using DataAccess.Example.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataAccess.Example.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorsDataManager _manager;
        private readonly ILogger _logger;

        public ColorsController(IColorsDataManager manager, ILogger<ColorsController> logger)
        {
            _manager = manager;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<ColorsController>
        [HttpGet]
        public IEnumerable<Color> Get()
        {
           var colors = _manager.GetAll();

            _logger.LogInformation("Total colors retrieved: " + colors?.Count);

            return colors;
        }

        // GET api/<ColorsController>/5
        [HttpGet("{id}")]
        public Color Get(int id)
        {
            throw new Exception();
            return _manager.Get(id);
        }

        // POST api/<ColorsController>
        [HttpPost]
        public void Post([FromBody] Color value)
        {

            _manager.Insert(value);

        }

        // PUT api/<ColorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Color value)
        {
            value.Id = id;
            _manager.Update(value);

        }

        // DELETE api/<ColorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _manager.Delete(id);
        }
    }
}
