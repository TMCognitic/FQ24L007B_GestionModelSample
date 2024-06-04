using FQ24L007B_GestionModelSample.Bll.Entities;
using FQ24L007B_GestionModelSample.Bll.Repositories;
using FQ24L007B_GestionModelSample.Foms.Sample;
using Microsoft.AspNetCore.Mvc;

namespace FQ24L007B_GestionModelSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ILogger<SampleController> _logger;
        private readonly ISampleRepository _sampleRepository;

        public SampleController(ILogger<SampleController> logger, ISampleRepository sampleRepository)
        {
            _logger = logger;
            _sampleRepository = sampleRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_sampleRepository.Get().ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Sample? sample = _sampleRepository.Get(id);
            return (sample is null) ? NotFound() : Ok(sample); 
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateSampleForm form)
        {
            _sampleRepository.Insert(new Sample(form.Text));
            return NoContent();
        }

        [HttpPut("{id}")]
        [HttpPatch("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] UpdateSampleForm form)
        {
            _sampleRepository.Update(id, new Sample(form.Text));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _sampleRepository.Delete(id);
            return NoContent();
        }
    }
}
