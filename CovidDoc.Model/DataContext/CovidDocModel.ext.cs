using Microsoft.EntityFrameworkCore;

namespace CovidDoc.Model
{
    public partial class CovidDocModel : DbContext
    {
        public CovidDocModel()
        {

        }

        partial void CustomInit(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("data source=C:\\Users\\bpost\\source\\repos\\CovidDoc\\Data\\CovidDoc.db");
        }
    }
}
