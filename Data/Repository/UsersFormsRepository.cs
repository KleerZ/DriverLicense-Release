using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DataBaseContext;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class UsersFormsRepository: IRepository<UsersForms>
    {
        private readonly ApplicationContext _context;
        private IRepository<UsersForms> _repositoryImplementation;

        public UsersFormsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<UsersForms> All => _context.UsersForms
            .Include(p => p.Users).ToList();

        public async Task Add(UsersForms entity)
        {
            await _context.UsersForms.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(UsersForms entity)
        {
            _context.UsersForms.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Clear()
        {
            var entity = _context.UsersForms.ToList();
            
            _context.UsersForms.RemoveRange(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, UsersForms targetEntity)
        {
            var findEntity = await _context.UsersForms.FindAsync(id);
            findEntity = targetEntity;
            
            await _context.SaveChangesAsync();
        }
        
        public async Task Update(UsersForms entity)
        {
            _context.UsersForms.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<UsersForms> FindById(int id)
        {
            return await _context.UsersForms.FirstOrDefaultAsync(p => p.ID == id);
        }
    }
}