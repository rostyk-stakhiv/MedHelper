using MedHelper.DAL.Entities;
using MedHelper.DAL.Interfaces;
using MedHelper.DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace MedHelper.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedHelperDBContext _context;
        private IPatientRepository patientRepository;
        private IMedicineRepository medicineRepository;
        private IRepository<Disease> diseaseRepository;
        private IRepository<Composition> compositionRepository;
        private IUserRepository userRepository;
        private IRepository<MedicineInteraction> medicineInteractionRepository;
        private IRepository<Role> roleRepository;
        private IRepository<PharmacotherapeuticGroup> pharmacotherapeuticGroupRepository;
        public UnitOfWork(MedHelperDBContext context)

        {
            _context = context;
        }


        public IPatientRepository PatientRepository
        {
            get
            {
                if (patientRepository == null)
                {
                    patientRepository = new PatientRepository(_context);
                }
                return patientRepository;
            }
        }

        public IMedicineRepository MedicineRepository
        {
            get
            {
                if (medicineRepository == null)
                {
                    medicineRepository = new MedicineRepository(_context);
                }
                return medicineRepository;
            }
        }

        public IRepository<Disease> DiseaseRepository
        {
            get
            {
                if (diseaseRepository == null)
                {
                    diseaseRepository = new Repository<Disease>(_context);
                }
                return diseaseRepository;
            }
        }

        public IRepository<Composition> CompositionRepository
        {
            get
            {
                if (compositionRepository == null)
                {
                    compositionRepository = new Repository<Composition>(_context);
                }
                return compositionRepository;
            }
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_context);
                }
                return userRepository;
            }
        }
        public IRepository<MedicineInteraction> MedicineInteractionRepository
        {
            get
            {
                if (medicineInteractionRepository == null)
                {
                    medicineInteractionRepository = new Repository<MedicineInteraction>(_context);
                }
                return medicineInteractionRepository;
            }
        }
        public IRepository<Role> RoleRepository
        {
            get
            {
                if (roleRepository == null)
                {
                    roleRepository = new Repository<Role>(_context);
                }
                return roleRepository;
            }
        }
        public IRepository<PharmacotherapeuticGroup> PharmacotherapeuticGroupRepository
        {
            get
            {
                if (pharmacotherapeuticGroupRepository == null)
                {
                    pharmacotherapeuticGroupRepository = new Repository<PharmacotherapeuticGroup>(_context);
                }
                return pharmacotherapeuticGroupRepository;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}