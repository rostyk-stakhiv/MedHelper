using MedHelper.DAL.Entities;
using System.Threading.Tasks;

namespace MedHelper.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Composition> CompositionRepository { get;}
        public IRepository<Disease> DiseaseRepository { get;}
        public IUserRepository UserRepository { get;}
        public IMedicineRepository MedicineRepository { get;}
        public IPatientRepository PatientRepository { get;}
        public IRepository<MedicineInteraction> MedicineInteractionRepository { get;}
        public IRepository<PharmacotherapeuticGroup> PharmacotherapeuticGroupRepository { get;}
        Task<int> SaveAsync();
    }
}