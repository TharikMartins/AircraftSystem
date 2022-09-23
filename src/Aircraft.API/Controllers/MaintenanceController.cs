using Aircraft.API.Response;
using Aircraft.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Aircraft.API.Request;
using Aircraft.Domain;

namespace Aircraft.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MaintenanceController : Controller
    {
        private readonly IMaintenanceService _service;
        private readonly IMapper _mapper;
        public MaintenanceController(IMaintenanceService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post(MaintenanceRequest request)
        {
            bool response = await _service.Insert(_mapper.Map<Maintenance>(request));
            return Ok(new TransactionResponse(response));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceResponse>>> Get(Guid userId)
        {
            return Ok(_mapper.Map<IEnumerable<MaintenanceResponse>>(await _service.Get(userId)));
        }
    }
}
