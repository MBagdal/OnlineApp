using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestBackEndApi.Domain.Queries.Cep.Get;
using TestBackEndApi.Infrastructure.Data.Dto;

namespace TestBackEndApi.Api.Controllers
{
    [Route("api/cep")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CepController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("/{format}"), FormatFilter]
        public async Task<IActionResult> Get([FromQuery] GetCepQuery query)
        {
            try
            {
                var response = await _mediator.Send(query);

                if (response == null) return NotFound();

                if (string.IsNullOrEmpty(response.Cep)) return BadRequest(response);

                var responseDTO = _mapper.Map<CepResponseDTO>(response);
                
                return Ok(responseDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
