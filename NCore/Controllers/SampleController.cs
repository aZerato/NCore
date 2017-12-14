namespace NCore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using NCore.Domain.SampleModule.Services;

    /// <summary>
    /// Sample controller.
    /// </summary>
    [Route("api/[controller]")]
    public class SampleController : Controller
    {
        #region Members

        private readonly ISampleService _sampleService;

        private readonly IMemoryCache _cache;

        #endregion

        #region Ctor

        public SampleController(
            ISampleService sampleService,
            IMemoryCache cache)
        {
            _sampleService = sampleService;
            _cache = cache;
        }

        #endregion

        #region Actions

        // GET: api/values
        [HttpGet]
        public bool Get()
        {
            return _sampleService.IsAvailable();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var value = string.Empty;

            _cache.TryGetValue(id, out value);

            return value;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _cache.Set(1, value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            var oldValue = string.Empty;

            _cache.TryGetValue(id, out oldValue);

            if (!string.IsNullOrEmpty(oldValue))
            {
                _cache.Remove(id);
                _cache.Set(id, value);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var value = string.Empty;

            _cache.TryGetValue(id, out value);

            if (!string.IsNullOrEmpty(value))
            {
                _cache.Remove(id);
            }
        }

        #endregion
    }
}
