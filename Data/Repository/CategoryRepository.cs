using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DataBaseContext;
using Data.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class CategoryRepository : IRepository<Category>

    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> All => _context.Categories.ToList();

        public async Task Add(Category entity)
        {
            _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Category entity)
        {
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Clear()
        {
            var entity = _context.Categories.ToList();

            _context.Categories.RemoveRange(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Category targetEntity)
        {
            var findEntity = await _context.Categories.FindAsync(id);
            findEntity = targetEntity;

            await _context.SaveChangesAsync();
        }

        public async Task Update(Category entity)
        {
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> FindById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}