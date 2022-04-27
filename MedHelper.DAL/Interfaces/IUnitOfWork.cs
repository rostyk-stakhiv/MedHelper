using MedHelper.DAL.Entities;
using System.Threading.Tasks;

namespace MedHelper.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Composition> CompositionRepository { get;}
        public IRepository<Disease> DiseaseRepository { get;}
        public IRepository<User> UserRepository { get;}
        public IRepository<Medicine> MedicineRepository { get;}
        public IRepository<Patient> PatientRepository { get;}
        public IRepository<MedicineInteraction> MedicineInteractionRepository { get;}
        public IRepository<Role> RoleRepository { get;}
        public IRepository<PharmacotherapeuticGroup> PharmacotherapeuticGroupRepository { get;}
        public MedHelperDBContext Context { get; }

        public IRepository<PharmacotherapeuticGroup> PharmacotherapeuticGroupRepository { get; }

        Task<int> SaveAsync();
    }
}