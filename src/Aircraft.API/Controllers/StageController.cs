using Aircraft.API.Request;
using Aircraft.API.Response;
using Aircraft.Application.Interfaces;
using Aircraft.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
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
        public async Task<ActionResult<TransactionResponse>> Post(IEnumerable<StageRequest> request)
        {
            bool response = await _service.Insert(_mapper.Map<IEnumerable<Stage>>(request));

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StageResponse>>> Get(Guid maintenanceId)
        {
            return Ok(_mapper.Map<IEnumerable<Stage>>(await _service.Get(maintenanceId)));
        }

    }
}
