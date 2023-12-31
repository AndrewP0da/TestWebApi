﻿using TestWebApi.Menu.Models;

namespace TestWebApi.Menu
{
    public interface ICategoryService
    {
        Task<Guid> Create(Category category);
        Task<Category> Get(Guid categoryId);
        Task<List<Category>> GetAll();
        Task<bool> Update(Guid categoryId, string newName);
        Task Delete(Guid categoryId);

        Task<bool> CategoryExists(string categoryName);
    }
}
