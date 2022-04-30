using MedHelper.DAL.Entities;
using MedHelper.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Repositories
{
    public class UserRepository:IUserRepository
    {
        protected readonly MedHelperDBContext _context;
        private DbSet<User> _enteties;
        public UserRepository(MedHelperDBContext context)

        {
            _context = context;
            _enteties = context.Set<User>();
        }
        public async Task AddAsync(User entity)
        {

            await _enteties.AddAsync(entity);

        }

        public void Delete(User entity)
        {

            _enteties.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _enteties.SingleOrDefaultAsync(s => s.Id == id);
            Delete(entity);
        }

        public IQueryable<User> FindAll()
        {
            return _enteties;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _enteties.SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Update(User entity)
        {
            _context.Update(entity);
        }

        public async Task<User> GetByIdWithDetailsAsync(int id)
        {
            var user = await GetByIdAsync(id);

            //patients
            var patients = _context.Patients.Where(x => x.UserId == user.Id).ToList();
            foreach (var patient in patients)
            {
                getPatientDetails(patient);
            }
            user.Patients = patients;

            //medicines
            var medicines = _context.Medicines.Where(x=>x.UserId==user.Id).ToList();
            foreach(var medicine in medicines)
            {
                getMedicineDetails(medicine);
            }
            user.Medicines = medicines;

            //roles
            var userRoles = _context.UserRole.Where(x => x.UserId == user.Id);
            foreach (var userRole in userRoles)
            {
                userRole.Role = _context.Roles.FirstOrDefault(x => x.Id == userRole.RoleId);
            }
            user.UserRoles = userRoles.ToList();

            return user;
        }

        private void getMedicineDetails(Medicine medicine)
        {
            //pharmatheuticGroup
            medicine.Group = _context.PharmacotherapeuticGroups.FirstOrDefault(x => x.Id == medicine.PharmacotherapeuticGroupId);

            //contraindications
            var contraindications = _context.MedicineContraindication.Where(x => x.MedicineId == medicine.Id).ToList();
            foreach (var contraindication in contraindications)
            {
                contraindication.Contraindication = _context.Diseases.FirstOrDefault(x => x.Id == contraindication.ContraindicationId);
            }
            medicine.MedicineContraindications = contraindications;

            //interactions
            var interactions = _context.MedicineInteraction.Where(x => x.MedicineId == medicine.Id).ToList();
            foreach (var interaction in interactions)
            {
                interaction.Composition = _context.Compositions.FirstOrDefault(x => x.Id == interaction.CompositionId);
            }
            medicine.MedicineInteractions = interactions;

            //compositions
            var compositions = _context.MedicineComposition.Where(x => x.MedicineId == medicine.Id).ToList();
            foreach (var composition in compositions)
            {
                composition.Composition = _context.Compositions.FirstOrDefault(x => x.Id == composition.CompositionId);
            }
            medicine.MedicineCompositions = compositions;
        }

        private void getPatientDetails(Patient patient)
        {
            //medicines
            var patientMedicines = _context.PatientMedicine.Where(p => p.PatientId == patient.Id).ToList();
            foreach (var patientMedicine in patientMedicines)
            {
                var medicine = _context.Medicines.FirstOrDefault(x => x.Id == patientMedicine.MedicineId);
                getMedicineDetails(medicine);
                patientMedicine.Medicine = medicine;
            }
            patient.PatientMedicines = patientMedicines;

            //diseases
            var patientDiseases = _context.PatientDisease.Where(p => p.PatientId == patient.Id).ToList();
            foreach (var patientDisease in patientDiseases)
            {
                patientDisease.Disease = _context.Diseases.FirstOrDefault(x => x.Id == patientDisease.DiseaseId);
            }
            patient.PatientDiseases = patientDiseases;
        }
    }
}
