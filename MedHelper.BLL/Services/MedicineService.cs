using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using MedHelper.DAL;
using MedHelper.DAL.Entities;

namespace MedHelper.BLL.Services
{
    public class MedicineService: ICrud<Medicine>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicineService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<Medicine> GetAll()
        {
            var medicines =  _unitOfWork.MedicineRepository.FindAll();
            var compositions = _unitOfWork.CompositionRepository.FindAll();
            var diseases = _unitOfWork.DiseaseRepository.FindAll();
            var groups = _unitOfWork.PharmacotherapeuticGroupRepository.FindAll();

            foreach (var medicine in medicines)
            {
                medicine.Group = groups.FirstOrDefault(obj => obj.Id == medicine.PharmacotherapeuticGroupId);
                foreach (var id in medicine.CompositionsId)
                {
                    var data = compositions.FirstOrDefault(obj => obj.Id == id);
                    medicine.Compositions.Add(data);
                }
                
                foreach (var id in medicine.ContraindicationsId)
                {
                    var data = diseases.FirstOrDefault(obj => obj.Id == id);
                    medicine.Contraindications.Add(data);
                }
            }

            return medicines;
        }

        public async Task<Medicine> GetByIdAsync(int id)
        {
            var medicine = await _unitOfWork.MedicineRepository.GetByIdAsync(id);
            var compositions = _unitOfWork.CompositionRepository.FindAll();
            var diseases = _unitOfWork.DiseaseRepository.FindAll();
        
            foreach (var cid in medicine.CompositionsId)
            {
                medicine.Group = await
                    _unitOfWork.PharmacotherapeuticGroupRepository.GetByIdAsync(medicine.PharmacotherapeuticGroupId);
                var data = compositions.FirstOrDefault(obj => obj.Id == cid);
                medicine.Compositions.Add(data);
            }
            
            foreach (var cid in medicine.ContraindicationsId)
            {
                var data = diseases.FirstOrDefault(obj => obj.Id == cid);
                medicine.Contraindications.Add(data);
            }

            return medicine;
        }

        public async Task AddAsync(Medicine model)
        {
            var compositions = _unitOfWork.CompositionRepository.FindAll();
            var diseases = _unitOfWork.DiseaseRepository.FindAll();
        
            foreach (var cid in model.CompositionsId)
            {
                model.Group = await
                    _unitOfWork.PharmacotherapeuticGroupRepository.GetByIdAsync(model.PharmacotherapeuticGroupId);
                var data = compositions.FirstOrDefault(obj => obj.Id == cid);
                model.Compositions.Add(data);
            }
            
            foreach (var cid in model.ContraindicationsId)
            {
                var data = diseases.FirstOrDefault(obj => obj.Id == cid);
                model.Contraindications.Add(data);
            }
            
            await _unitOfWork.MedicineRepository.AddAsync(model);
        }

        public async Task UpdateAsync(Medicine model)
        {
            var compositions = _unitOfWork.CompositionRepository.FindAll();
            var diseases = _unitOfWork.DiseaseRepository.FindAll();
        
            foreach (var cid in model.CompositionsId)
            {
                model.Group = await
                    _unitOfWork.PharmacotherapeuticGroupRepository.GetByIdAsync(model.PharmacotherapeuticGroupId);
                var data = compositions.FirstOrDefault(obj => obj.Id == cid);
                model.Compositions.Add(data);
            }
            
            foreach (var cid in model.ContraindicationsId)
            {
                var data = diseases.FirstOrDefault(obj => obj.Id == cid);
                model.Contraindications.Add(data);
            }
            
            await _unitOfWork.MedicineRepository.UpdateAsync(model);
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.MedicineRepository.DeleteByIdAsync(modelId);
        }
    }
}