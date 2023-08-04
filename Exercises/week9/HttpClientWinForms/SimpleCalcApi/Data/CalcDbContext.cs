using Microsoft.EntityFrameworkCore;

namespace SimpleCalcApi.Data
{
    public class CalcDbContext : DbContext
    {
        public CalcDbContext(DbContextOptions<CalcDbContext> options) : base(options) { }

        public DbSet<CalculationResult> CalculationResults { get; set; }
    }
}

