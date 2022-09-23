using Aircraft.API.Request;
using Aircraft.API.Response;
using Aircraft.Application.Interfaces;
using Aircraft.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Aircraft.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StageController : Controller
    {
        private readonly IStageService _service;
        private readonly IMapper _mapper;

        public StageController(IStageService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<TransactionResponse>> Post(StageRequest request)
        {
            bool response = await _service.Insert(_mapper.Map<Stage>(request));
            return Ok(response);
        }
    }
}
