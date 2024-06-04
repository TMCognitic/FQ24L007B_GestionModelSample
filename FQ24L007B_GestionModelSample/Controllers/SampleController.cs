using FQ24L007B_GestionModelSample.Domain.Commands;
using FQ24L007B_GestionModelSample.Domain.Entities;
using FQ24L007B_GestionModelSample.Domain.Queries;
using FQ24L007B_GestionModelSample.Domain.Repositories;
using FQ24L007B_GestionModelSample.Foms.Sample;
using Microsoft.AspNetCore.Mvc;

using Tools.CQS.Commands;

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
            return Ok(_sampleRepository.Execute(new GetSamplesQuery()).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Sample? sample = _sampleRepository.Execute(new GetSampleByIdQuery(id));
            return (sample is null) ? NotFound() : Ok(sample);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateSampleForm form)
        {
            CommandResult result = _sampleRepository.Execute(new CreateSampleCommand(form.Text));

            if(result.IsSuccess)
                return NoContent();

            return BadRequest(new { Message = result.ErrorMessage });
        }

        [HttpPut("{id}")]
        [HttpPatch("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] UpdateSampleForm form)
        {
            CommandResult result = _sampleRepository.Execute(new UpdateSampleCommand(id, form.Text));
            
            if(result.IsFailure)
                return BadRequest(new { Message = result.ErrorMessage });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _sampleRepository.Execute(new DeleteSampleCommand(id));
            return NoContent();
        }
    }
}
