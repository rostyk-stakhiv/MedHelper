using AutoMapper;
using MedHelper.BLL.Models;
using MedHelper.DAL.Entities;
using System.Linq;

namespace MedHelper.BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            /*CreateMap<PatientModel, PatientModel>()
                .ForMember(p => p.Id, c => c.MapFrom(patient => patient.Id))
                .ForMember(p => p.Birthdate, c => c.MapFrom(patient => patient.Birthdate))
                .ForMember(p => p.FirstName, c => c.MapFrom(patient => patient.FirstName))
                .ForMember(p => p.LastName, c => c.MapFrom(patient => patient.LastName))
                .ForMember(p => p.DiseasesId, c => c.MapFrom(patient => patient.DiseasesId))
                .ForMember(p => p.Gender, c => c.MapFrom(patient => patient.Gender))
                .ForMember(p => p.MedicinesId, c => c.MapFrom(patient => patient.MedicinesId))
                .ForMember(p => p.UserID, c => c.MapFrom(patient => patient.UserID))
                .ForMember(p => p.User, c => c.MapFrom(patient => patient.User))
                .ForMember(p => p.Medicines, c => c.MapFrom(patient => patient.Medicines))
                .ForMember(p => p.Diseases, c => c.MapFrom(patient => patient.Diseases))
                .ReverseMap();

            CreateMap<CompositionModel, CompositionModel>()
                .ForMember(p => p.Id, c => c.MapFrom(composition => composition.Id))
                .ForMember(p => p.Description, c => c.MapFrom(composition => composition.Description))
                .ReverseMap();

            CreateMap<DiseaseModel, DiseaseModel>()
                .ForMember(p => p.Id, c => c.MapFrom(disease => disease.Id))
                .ForMember(p => p.Title, c => c.MapFrom(disease => disease.Title))
                .ReverseMap();

            CreateMap<Medicine, MedicineModel>()
                .ForMember(p => p.Id, c => c.MapFrom(medicine => medicine.Id))
                .ForMember(p => p.Group, c => c.MapFrom(medicine => medicine.Group))
                .ForMember(p => p.MedicineInteractions, c => c.MapFrom(medicine => medicine.MedicineInteractions))
                .ForMember(p => p.Compositions, c => c.MapFrom(medicine => medicine.Compositions))
                .ForMember(p => p.CompositionsId, c => c.MapFrom(medicine => medicine.CompositionsId))
                .ForMember(p => p.Contraindications, c => c.MapFrom(medicine => medicine.Contraindications))
                .ForMember(p => p.ContraindicationsId, c => c.MapFrom(medicine => medicine.ContraindicationsId))
                .ForMember(p => p.Name, c => c.MapFrom(medicine => medicine.Name))
                .ForMember(p => p.PharmacotherapeuticGroupId, c => c.MapFrom(medicine => medicine.PharmacotherapeuticGroupId))
                .ReverseMap();

            CreateMap<MedicineCompositionModel, MedicineCompositionModel>()
                .ForMember(p => p.CompositionId, c => c.MapFrom(medicinecomposition => medicinecomposition.CompositionId))
                .ForMember(p => p.MedicineId, c => c.MapFrom(medicinecomposition => medicinecomposition.MedicineId))
                .ForMember(p => p.Composition, c => c.MapFrom(medicinecomposition => medicinecomposition.Composition))
                .ForMember(p => p.Medicine, c => c.MapFrom(medicinecomposition => medicinecomposition.Medicine))
                .ReverseMap();

            CreateMap<MedicineInteractionModel, MedicineInteractionModel>()
                .ForMember(p => p.Description, c => c.MapFrom(medicineinteraction => medicineinteraction.Description))
                .ForMember(p => p.CompositionId, c => c.MapFrom(medicineinteraction => medicineinteraction.CompositionId))
                .ForMember(p => p.MedicineId, c => c.MapFrom(medicineinteraction => medicineinteraction.MedicineId))
                .ForMember(p => p.Composition, c => c.MapFrom(medicineinteraction => medicineinteraction.Composition))
                .ForMember(p => p.Medicine, c => c.MapFrom(medicineinteraction => medicineinteraction.Medicine))
                .ReverseMap();

            CreateMap<PharmacotherapeuticGroupModel, PharmacotherapeuticGroupModel>()
                .ForMember(p => p.Id, c => c.MapFrom(group => group.Id))
                .ForMember(p => p.Title, c => c.MapFrom(group => group.Title))
                .ReverseMap();

            CreateMap<RoleModel, RoleModel>()
                .ForMember(p => p.Id, c => c.MapFrom(role => role.Id))
                .ForMember(p => p.UserRole, c => c.MapFrom(role => role.UserRole))
                .ReverseMap();

            CreateMap<UserModel, UserModel>()
                .ForMember(p => p.Id, c => c.MapFrom(user => user.Id))
                .ForMember(p => p.Email, c => c.MapFrom(user => user.Email))
                .ForMember(p => p.FirstName, c => c.MapFrom(user => user.FirstName))
                .ForMember(p => p.LastName, c => c.MapFrom(user => user.LastName))
                .ForMember(p => p.Pass, c => c.MapFrom(user => user.Pass))
                .ForMember(p => p.Patients, c => c.MapFrom(user => user.Patients))
                .ForMember(p => p.PatientsId, c => c.MapFrom(user => user.PatientsId))
                .ForMember(p => p.Role, c => c.MapFrom(user => user.Role))
                .ForMember(p => p.RoleId, c => c.MapFrom(user => user.RoleId))
                .ReverseMap();*/
        }
    }
}