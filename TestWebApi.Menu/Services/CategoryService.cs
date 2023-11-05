using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.DB;
using TestWebApi.DB.Entities;
using TestWebApi.Menu.Models;

namespace TestWebApi.Menu.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public CategoryService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<Category> Get(Guid categoryId)
        {
            var entityCategory = await _dbRepository.Get<CategoryEntity>().FirstOrDefaultAsync(x => x.Id == categoryId);

            if (entityCategory == null)
            {
                return new Category();
            }

            var entityModel = _mapper.Map<Category>(entityCategory);

            if (entityModel == null)
            {
                return new Category();
            }

            entityModel.CategoryId = entityCategory.Id;
            return entityModel;
        }

        public async Task<List<Category>> GetAll()
        {
            var listCategoryEntity = _dbRepository.GetAll<CategoryEntity>().ToList();
            var listCategory = _mapper.Map<List<Category>>(listCategoryEntity);

            foreach (var category in listCategory)
            {
                var categoryEntity = listCategoryEntity.FirstOrDefault(c => c.Name == category.Name);

                if (categoryEntity != null && categoryEntity.Id != Guid.Empty)
                {
                    category.CategoryId = categoryEntity.Id;
                }
            }

            return listCategory;
        }

        public async Task<Guid> Create(Category category)
        {
            var entityCategory = _mapper.Map<CategoryEntity>(category);
       
            DateTime localDateTime = DateTime.Now;
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            entityCategory.DateCreated = TimeZoneInfo.ConvertTimeToUtc(localDateTime, localTimeZone);
            entityCategory.DateUpdated = TimeZoneInfo.ConvertTimeToUtc(localDateTime, localTimeZone);

            entityCategory.Name = category.Name;

            var result = await _dbRepository.Add(entityCategory);
            var resultSave = await _dbRepository.SaveChangesAsync();

            return result;
        }

        public async Task<bool> Update(Category category)
        {
            var entityCategory = await _dbRepository.Get<CategoryEntity>().FirstOrDefaultAsync(x => x.Id == category.CategoryId);
            if (entityCategory != null)
            {
                entityCategory.Name = category.Name;

                DateTime localDateTime = DateTime.Now;
                TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
                entityCategory.DateUpdated = TimeZoneInfo.ConvertTimeToUtc(localDateTime, localTimeZone);
                
                await _dbRepository.Update(entityCategory);
                var resultSave = await _dbRepository.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task Delete(Guid categoryId)
        {
            await _dbRepository.Delete<CategoryEntity>(categoryId);
            var resultSave = await _dbRepository.SaveChangesAsync();
        }

        public async Task<bool> CategoryExists(string categoryName)
        {
            List<Category> categoryList = await GetAll();
            return categoryList.Any(c => c.Name == categoryName);
        }

    }
}
