using AssetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Persistence
{
    public class AssetManagementDBContext : DbContext
    {
        public AssetManagementDBContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Asset> Assets { get; set; }
    }
}
