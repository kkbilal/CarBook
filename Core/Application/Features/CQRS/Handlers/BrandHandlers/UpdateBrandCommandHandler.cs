﻿using Application.Features.CQRS.Commands.BrandCommands;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBrandCommand command)
        {
            var existingBrand = await _repository.GetByIdAsync(command.BrandId);
            if (existingBrand != null)
            {
                existingBrand.Name = command.Name;

                await _repository.UpdateAsync(existingBrand);
            }
            else
            {
                throw new Exception("Brand not found");
            }
        }
    }
}
