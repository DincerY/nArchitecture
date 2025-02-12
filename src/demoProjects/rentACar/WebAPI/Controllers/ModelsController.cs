﻿using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetListModel;
using Application.Features.Models.Queries.GetListModelByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]PageRequest pageRequest)
        {
            GetListModelQuery getListModelQuery = new GetListModelQuery
            {
                PageRequest = pageRequest
            };
            ModelListModel result = await MediatoR?.Send(getListModelQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,[FromBody]Dynamic dynamic)
        {
            GetListModelByDynamicQuery getListModelByDynamicQuery = new()
            {
                Dynamic = dynamic,
                PageRequest = pageRequest
            };
            ModelListModel result =await MediatoR.Send(getListModelByDynamicQuery);
            return Ok(result);
        }
    }
}
