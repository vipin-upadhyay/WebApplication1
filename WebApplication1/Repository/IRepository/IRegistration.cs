using WebApplication1.Model;

namespace WebApplication1.Repository.IRepository
{
    public interface IRegistration : IRepository<Registrations>
    {
        void Update(Registrations reg);
        void Save();
    }
}
