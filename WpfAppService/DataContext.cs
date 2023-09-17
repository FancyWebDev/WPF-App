using Microsoft.EntityFrameworkCore;
using WpfAppService.Models;

namespace WpfAppService;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Account> Accounts { get; init; }
}