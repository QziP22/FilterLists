﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FilterLists.Directory.Api.Contracts.Models;
using FilterLists.Directory.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace FilterLists.Directory.Api.Controllers
{
    public class ListsController : BaseController
    {
        private readonly IMediator _mediator;

        public ListsController(IMemoryCache cache, IMediator mediator) : base(cache)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets the FilterLists..
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The FilterLists.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ListVm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return await CacheGetOrCreateAsync(() => _mediator.Send(new GetLists.Query(), cancellationToken));
        }

        /// <summary>
        /// Gets the details of the FilterList.
        /// </summary>
        /// <param name="id">The identifier of the FilterList.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The details of the FilterList.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ListDetailsVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await CacheGetOrCreateAsync(() => _mediator.Send(new GetListDetails.Query(id), cancellationToken), id);
        }
    }
}
