using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Repository
{
    public class RegistrationRepository : Repository<Registrations>, IRegistration
    {
        public readonly AppDbContext _db;
        public RegistrationRepository(AppDbContext db) :base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Registrations reg)
        {
            _db.Registrations.Update(reg);  
        }
    }
}
