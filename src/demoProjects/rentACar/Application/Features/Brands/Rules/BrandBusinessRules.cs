﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandRepository _brandRepository;
        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Brand> result = await _brandRepository.GetListAsync(b=>b.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException("Brand name exists.");
            }
        }

        public async Task<Brand> BrandShouldExistWhenRequested(int id)
        {
            Brand? brand = await _brandRepository.GetAsync(b => b.Id == id);
            if (brand == null)
            {
                throw new BusinessException("Requested brand does not exist");
            }
            return brand;
        }
    }
}
