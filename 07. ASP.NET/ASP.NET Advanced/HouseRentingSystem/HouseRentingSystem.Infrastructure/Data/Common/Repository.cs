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
        return DbSet<T>().AsQueryable();
    }

    public IQueryable<T> AllReadOnly<T>() where T : class
    {
        return DbSet<T>()
            .AsNoTracking();
    }
}