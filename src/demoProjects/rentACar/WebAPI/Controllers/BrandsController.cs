﻿using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetByIdBrand;
using Application.Features.Brands.Queries.GetListBrand;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateBrandCommand command)
        {
            CreatedBrandDto result = await MediatoR.Send(command);
            return Created("",result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new()
            {
                PageRequest = pageRequest
            };

            BrandListModel result = await MediatoR.Send(getListBrandQuery);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdBrandQuery getListBrandQuery = new() { Id = id };
            BrandGetByIdDto brandGetByIdDto = await MediatoR.Send(getListBrandQuery);
            return Ok(brandGetByIdDto);
        }
    }
}
