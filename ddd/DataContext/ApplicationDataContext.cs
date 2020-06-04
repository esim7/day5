using System.Data.Entity;
using ddd.Models;

namespace ddd.DataContext
{
    public class ApplicationDataContext : DbContext
    {
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        public ApplicationDataContext() : base("name=ApplicationConnectionString")
        {

        }
    }
}