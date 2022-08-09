using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    class SocialDevContextFactory : IDesignTimeDbContextFactory<SocialDevDbContext>
    {
        public SocialDevDbContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<SocialDevDbContext>();
            OptionsBuilder.UseSqlServer("Data Source=DESKTOP-NFM67UE\\MSSQLSERVER1;Initial Catalog=SocialDev;Integrated Security=true");
            return new SocialDevDbContext(OptionsBuilder.Options);
        }
    }
}
