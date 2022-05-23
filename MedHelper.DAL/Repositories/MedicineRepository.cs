using MedHelper.DAL.Entities;
using MedHelper.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Repositories
{
    public class MedicineRepository : Repository<Medicine>, IMedicineRepository
    {
        public MedicineRepository(MedHelperDBContext context):base(context)
        {
        }
        public IEnumerable<Medicine> GetAllWithDetails(string search = null)
        {
            var medicines = FindAll().ToList();

            if (!String.IsNullOrEmpty(search))
            {
                medicines = medicines.Where(s => s.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            foreach (var medicine in medicines)
            {
                getDetails(medicine);
            }
            return medicines;
                
        }

        public async Task<Medicine> GetByIdWithDetailsAsync(int id)
        {
            var medicine = await GetByIdAsync(id);
            getDetails(medicine);
            return medicine;
        }

        private void getDetails(Medicine medicine)
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
    }
}
