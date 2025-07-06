using Application.Features.CQRS.Commands.BrandCommands;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> _brandRepository;

        public RemoveBrandCommandHandler(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task Handle(RemoveBrandCommand command)
        {
            var brand = await _brandRepository.GetByIdAsync(command.Id);
            if (brand == null)
            {
                throw new Exception("Brand not found");
            }

            await _brandRepository.RemoveAsync(brand);
        }
    }
}
