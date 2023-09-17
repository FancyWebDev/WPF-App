using WpfAppService.Models;

namespace WpfAppService.Repositories;

public interface IAccountRepository : IRepository<Account> { }

public class AccountRepository : IAccountRepository
{
    private readonly DataContext _context;

    public AccountRepository(DataContext context)
    {
        _context = context;
    }

    public ValueTask<IEnumerable<Account>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<Account> GetByAsync(Func<Account, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public async ValueTask AddAsync(Account entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public ValueTask UpdateAsync(Account entity)
    {
        _context.Update(entity);
        return ValueTask.CompletedTask;
    }

    public ValueTask DeleteAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> ExistsAsync(Func<Account, bool> predicate)
    {
        var result =_context.Accounts.Any(predicate);
        return ValueTask.FromResult(result);
    }
}