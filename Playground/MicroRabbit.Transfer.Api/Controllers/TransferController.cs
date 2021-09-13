using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MicroRabbit.Transfer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _service;

        public TransferController(ITransferService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> GetTransferLogs()
        {
            return Ok(_service.GetTransferLogs());
        }
    }
}
