﻿using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FilterLists.Directory.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FilterLists.Directory.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaintainersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaintainersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetMaintainers.MaintainerViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetMaintainers.Query(), cancellationToken));
        }
    }
}