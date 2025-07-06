using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCategoryCommand command)
        {
            var category = await _repository.GetByIdAsync(command.Id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }

            await _repository.RemoveAsync(category);
        }
    }
}
