using MedHelper.DAL.Entities;
using MedHelper.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Repositories
{
    public class PatientRepository:Repository<Patient>, IPatientRepository
    {
        public PatientRepository(MedHelperDBContext context):base(context)
        {

        }

        public IEnumerable<Patient> GetPatients(int id, string search)
        {
            var patients = _context.Patients.Where(i => i.UserId == id).Where(
                s => s.LastName.ToLower().Contains(search.ToLower()) || s.FirstName.ToLower().Contains(search.ToLower())).ToList();
            return patients;
        }

        public IEnumerable<Patient> GetAllWithDetails()
        {
            var patients = FindAll();
            foreach (var patient in patients)
            {
                getPatientDetails(patient);
            }
            return patients;
        }

        public async Task<Patient> GetByIdWithDetailsAsync(int id)
        {
            var patient = await GetByIdAsync(id);
            getPatientDetails(patient);
            
            return patient;
        }

        private void getMedicineDetails(Medicine medicine)
        {
            //pharmatheuticGroup
            var group = _context.PharmacotherapeuticGroups.FirstOrDefault(x => x.Id == medicine.PharmacotherapeuticGroupId);
            medicine.Group = group;

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
