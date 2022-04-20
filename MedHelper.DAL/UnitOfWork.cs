using MedHelper.DAL.Entities;
using MedHelper.DAL.Interfaces;
using MedHelper.DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace MedHelper.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedHelperDB _context;
        private IRepository<Patient> patientRepository;
        private IRepository<Medicine> medicineRepository;
        private IRepository<Disease> diseaseRepository;
        public UnitOfWork(MedHelperDB context)
        {
            _context = context;
        }

        public IRepository<Patient> PatientRepository
        {
            get
            {
                if (patientRepository == null)
                {
                    patientRepository = new Repository<Patient>(_context);
                }
                return patientRepository;
            }
        }

        public IRepository<Medicine> MedicineRepository
        {
            get
            {
                if (medicineRepository == null)
                {
                    medicineRepository = new Repository<Medicine>(_context);
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

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}