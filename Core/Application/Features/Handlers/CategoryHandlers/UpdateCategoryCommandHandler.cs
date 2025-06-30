using Application.Features.Commands.CategoryCommands;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCategoryCommand command)
        {
            var category = await _repository.GetByIdAsync(command.CategoryId);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {command.CategoryId} not found.");
            }
            category.CategoryId = command.CategoryId;
            category.Name = command.Name;
            

            await _repository.UpdateAsync(category);
            
        }
    }
}
