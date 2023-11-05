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
    public class MenuItemService : IMenuItemService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public MenuItemService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<MenuItemResponse> Get(Guid idMenuItem)
        {
            var entityCategory = await _dbRepository.Get<MenuItemEntity>().FirstOrDefaultAsync(x => x.Id == idMenuItem);

            var entityModel = _mapper.Map<MenuItemResponse>(entityCategory);

            return entityModel;
        }

        public async Task<List<MenuItemResponse>> GetAll()
        {
            var listMenuItemEntity = _dbRepository.GetAll<MenuItemEntity>().ToList();
            var listMenuItem = _mapper.Map<List<MenuItemResponse>>(listMenuItemEntity);

            return listMenuItem;
        }

        public async Task<Guid> Create(MenuItem menuItem)
        {
            var entityMenuItem = _mapper.Map<MenuItemEntity>(menuItem);

            DateTime localDateTime = DateTime.Now;
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            entityMenuItem.DateCreated = entityMenuItem.DateUpdated = TimeZoneInfo.ConvertTimeToUtc(localDateTime, localTimeZone);

            var result = await _dbRepository.Add(entityMenuItem);
            await _dbRepository.SaveChangesAsync();

            return result;
        }

        public async Task<bool> Update(Guid idMenuItem, MenuItem updateMenuItem)
        {
            var entityMenuItem = await _dbRepository.Get<MenuItemEntity>().FirstOrDefaultAsync(x => x.Id == idMenuItem);
            if (entityMenuItem != null)
            {
                entityMenuItem.Quantity = updateMenuItem.Quantity;
                entityMenuItem.Price = updateMenuItem.Price;
                entityMenuItem.Description = updateMenuItem.Description;
                entityMenuItem.CategoryId = updateMenuItem.CategoryId;
                entityMenuItem.Composed = updateMenuItem.Composed;
                entityMenuItem.Image = updateMenuItem.Image;

                DateTime localDateTime = DateTime.Now;
                TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
                entityMenuItem.DateUpdated = TimeZoneInfo.ConvertTimeToUtc(localDateTime, localTimeZone);

                await _dbRepository.Update(entityMenuItem);
                var resultSave = await _dbRepository.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task Delete(Guid idMenuItem)
        {
            await _dbRepository.Delete<MenuItemEntity>(idMenuItem);
            await _dbRepository.SaveChangesAsync();
        }
    }
}
