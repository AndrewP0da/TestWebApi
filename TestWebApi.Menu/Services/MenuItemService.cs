using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.DB;
using TestWebApi.Menu.Models;

namespace TestWebApi.Menu.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IDbRepository _dbRepository;
        //private readonly IMapper _mapper;

        public MenuItemService(IDbRepository dbRepository/*, IMapper mapper*/)
        {
            _dbRepository = dbRepository;
            //_mapper = mapper;
        }

        public async Task<MenuItem> Get(Guid categoryId)
        {
            //var lead = await _dbRepository.Get<LeadEntity>().Include(x => x.Person).FirstOrDefaultAsync(x => x.Id == id);
            //var leadModel = _mapper.Map<LeadModel>(lead);
            //var employees = _dbRepository.Add(new EmployeeEntity());
            //await _dbRepository.SaveChangesAsync();
            return new MenuItem();
        }

        public async Task<List<MenuItem>> GetAll()
        {
            //var lead = await _dbRepository.Get<LeadEntity>().Include(x => x.Person).FirstOrDefaultAsync(x => x.Id == id);
            //var leadModel = _mapper.Map<LeadModel>(lead);
            //var employees = _dbRepository.Add(new EmployeeEntity());
            //await _dbRepository.SaveChangesAsync();
            return new List<MenuItem>();
        }

        public async Task<Guid> Create(MenuItem category)
        {
            //var entity = _mapper.Map<LeadEntity>(lead);
            //entity.UserCreated = _currentUser.Id;

            //var result = await _dbRepository.Add(entity);
            //await _dbRepository.SaveChangesAsync();

            //return result;
            return new Guid();
        }

        public async Task Update(MenuItem category)
        {
            //var entity = _mapper.Map<LeadEntity>(lead);

            //await _dbRepository.Update(entity);
            //await _dbRepository.SaveChangesAsync();
        }

        public async Task Delete(Guid categoryId)
        {
            //await _dbRepository.Delete<LeadEntity>(leadId);
            //await _dbRepository.SaveChangesAsync();
        }
    }
}
