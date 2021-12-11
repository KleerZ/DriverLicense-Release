using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DataBaseContext;
using Data.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class UsersRepository : IRepository<Users>

    {
    private readonly ApplicationContext _context;

    public UsersRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IEnumerable<Users> All => _context.Users.ToList();

    public async Task Add(Users entity)
    {
        _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Users entity)
    {
        _context.Users.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Clear()
    {
        var entity = _context.Users.ToList();

        _context.Users.RemoveRange(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Users targetEntity)
    {
        var findEntity = await _context.Users.FindAsync(id);
        findEntity = targetEntity;

        await _context.SaveChangesAsync();
    }

    public async Task Update(Users entity)
    {
        _context.Users.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Users> FindById(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(p => p.ID == id);
    }
    }
}