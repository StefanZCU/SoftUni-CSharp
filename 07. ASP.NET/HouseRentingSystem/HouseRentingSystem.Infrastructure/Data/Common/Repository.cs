using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Infrastructure.Data.Common;

public class Repository : IRepository
{
    private readonly DbContext _context;

    public Repository(HouseRentingDbContext context)
    {
        _context = context;
    }

    private DbSet<T> DbSet<T>() where T : class
    {
        return _context.Set<T>();
    }

    public IQueryable<T> All<T>() where T : class
    {
        return DbSet<T>();
    }

    public IQueryable<T> AllReadOnly<T>() where T : class
    {
        return DbSet<T>()
            .AsNoTracking();
    }

    public async Task AddAsync<T>(T entity) where T : class
    {
        await DbSet<T>().AddAsync(entity);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}