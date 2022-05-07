using AutoMapper;
using MedHelper.DAL.Entities;
using System.Linq;
using MedHelper.BLL.Dto.Doctor;
using MedHelper.BLL.Dto.Medicine;
using MedHelper.BLL.Dto.Patient;
using MedHelper.BLL.Dto.Responses;

namespace MedHelper.BLL
{
    public class AutomapperProfile : Profile
    {
    public AutomapperProfile()
    {
            CreateMap<MedicineContraindication, DiseaseResponse>()
            .ForMember(d => d.Id, c => c.MapFrom(disease => disease.Contraindication.Id))
            .ForMember(d => d.Title, c => c.MapFrom(disease => disease.Contraindication.Title));

            CreateMap<MedicineComposition, CompositionResponse>()
            .ForMember(d => d.Id, c => c.MapFrom(disease => disease.Composition.Id))
            .ForMember(d => d.Description, c => c.MapFrom(disease => disease.Composition.Description));

            CreateMap<PatientDisease, DiseaseResponse>()
            .ForMember(d => d.Id, c => c.MapFrom(disease => disease.Disease.Id))
            .ForMember(d => d.Title, c => c.MapFrom(disease => disease.Disease.Title));
            CreateMap<PatientMedicine, MedicineResponse>()
            .ForMember(d => d.Id, c => c.MapFrom(medicine => medicine.Medicine.Id))
            .ForMember(d => d.Name, c => c.MapFrom(medicine => medicine.Medicine.Name))
            .ForMember(d => d.Group, c => c.MapFrom(medicine => medicine.Medicine.Group))
            .ForMember(d => d.Contraindications, c => c.MapFrom(medicine => medicine.Medicine.MedicineContraindications))
            .ForMember(d => d.Compositions, c => c.MapFrom(medicine => medicine.Medicine.MedicineCompositions))
            .ForMember(d => d.MedicineInteractions, c => c.MapFrom(medicine => medicine.Medicine.MedicineInteractions));

            CreateMap<User, DoctorResponse>()
                .ForMember(d => d.FirstName, c => c.MapFrom(disease => disease.FirstName))
                .ForMember(d => d.LastName, c => c.MapFrom(disease => disease.LastName))
                .ForMember(d => d.Email, c => c.MapFrom(disease => disease.Email))
                .ForMember(d => d.Patients, c => c.MapFrom(disease => disease.Patients));


            CreateMap<PharmacotherapeuticGroup, PharmacotherapeuticGroupResponse>()
            .ForMember(d => d.Id, c => c.MapFrom(disease => disease.Id))
            .ForMember(d => d.Title, c => c.MapFrom(disease => disease.Title));
        
        CreateMap<MedicineInteraction, MedicineInteractionResponse>()
            .ForMember(d => d.Id, c => c.MapFrom(disease => disease.Id))
            .ForMember(d => d.Description, c => c.MapFrom(disease => disease.Description));
        
        CreateMap<Patient, PatientResponse>()
            .ForMember(p => p.Id, c => c.MapFrom(patient => patient.Id))
            .ForMember(p => p.LastName, c => c.MapFrom(patient => patient.LastName))
            .ForMember(p => p.FirstName, c => c.MapFrom(patient => patient.FirstName))
            .ForMember(p => p.Gender, c => c.MapFrom(patient => patient.Gender))
            .ForMember(p => p.Birthdate, c => c.MapFrom(patient => patient.Birthdate))
            .ForMember(p => p.Diseases, c => c.MapFrom(patient => patient.PatientDiseases))
            .ForMember(p => p.Medicines, c => c.MapFrom(patient => patient.PatientMedicines));
        
        CreateMap<Medicine, MedicineResponse>()
            .ForMember(d => d.Id, c => c.MapFrom(medicine => medicine.Id))
            .ForMember(d => d.Name, c => c.MapFrom(medicine => medicine.Name))
            .ForMember(d => d.Group, c => c.MapFrom(medicine => medicine.Group))
            .ForMember(d => d.Contraindications, c => c.MapFrom(medicine => medicine.MedicineContraindications))
            .ForMember(d => d.Compositions, c => c.MapFrom(medicine => medicine.MedicineCompositions))
            .ForMember(d => d.MedicineInteractions, c => c.MapFrom(medicine => medicine.MedicineInteractions));

        CreateMap<UpdateDoctorDto, User>()
            .ForMember(d => d.FirstName, c => c.MapFrom(disease => disease.FirstName))
            .ForMember(d => d.LastName, c => c.MapFrom(disease => disease.LastName))
            .ForMember(d => d.Email, c => c.MapFrom(disease => disease.Email))
            .ForMember(d => d.Password, c => c.MapFrom(data => data.Password));

        CreateMap<CreatePatientDto, Patient>()
            .ForMember(p => p.LastName, c => c.MapFrom(patient => patient.LastName))
            .ForMember(p => p.FirstName, c => c.MapFrom(patient => patient.FirstName))
            .ForMember(p => p.Gender, c => c.MapFrom(patient => patient.Gender))
            .ForMember(p => p.Birthdate, c => c.MapFrom(patient => patient.Birthdate))
            .ForMember(p => p.PatientDiseases, c => c.MapFrom(patient => patient.Diseases))
            .ForMember(p => p.PatientMedicines, c => c.MapFrom(patient => patient.Medicines));
        
        CreateMap<UpdatePatientDto, Patient>()
            .ForMember(p => p.LastName, c => c.MapFrom(patient => patient.LastName))
            .ForMember(p => p.FirstName, c => c.MapFrom(patient => patient.FirstName))
            .ForMember(p => p.Gender, c => c.MapFrom(patient => patient.Gender))
            .ForMember(p => p.Birthdate, c => c.MapFrom(patient => patient.Birthdate))
            .ForMember(p => p.PatientDiseases, c => c.MapFrom(patient => patient.Diseases))
            .ForMember(p => p.PatientMedicines, c => c.MapFrom(patient => patient.Medicines));

        //        CreateMap<Patient, PatientModel>()
        //            .ForMember(p => p.Id, c => c.MapFrom(patient => patient.Id))
        //            .ForMember(p => p.Birthdate, c => c.MapFrom(patient => patient.Birthdate))
        //            .ForMember(p => p.FirstName, c => c.MapFrom(patient => patient.FirstName))
        //            .ForMember(p => p.LastName, c => c.MapFrom(patient => patient.LastName))
        //            .ForMember(p => p.DiseasesId, c => c.MapFrom(patient => patient.DiseasesId))
        //            .ForMember(p => p.Gender, c => c.MapFrom(patient => patient.Gender))
        //            .ForMember(p => p.MedicinesId, c => c.MapFrom(patient => patient.MedicinesId))
        //            .ForMember(p => p.UserID, c => c.MapFrom(patient => patient.UserID))
        //            .ForMember(p => p.User, c => c.MapFrom(patient => patient.User))
        //            .ForMember(p => p.Medicines, c => c.MapFrom(patient => patient.Medicines))
        //            .ForMember(p => p.Diseases, c => c.MapFrom(patient => patient.Diseases))
        //            .ReverseMap();

        //        CreateMap<Composition, CompositionModel>()
        //            .ForMember(p => p.Id, c => c.MapFrom(composition => composition.Id))
        //            .ForMember(p => p.Description, c => c.MapFrom(composition => composition.Description))
        //            .ReverseMap();

        //        CreateMap<Disease, DiseaseModel>()
        //            .ForMember(p => p.Id, c => c.MapFrom(disease => disease.Id))
        //            .ForMember(p => p.Title, c => c.MapFrom(disease => disease.Title))
        //            .ReverseMap();

        //        CreateMap<Medicine, MedicineModel>()
        //            .ForMember(p => p.Id, c => c.MapFrom(medicine => medicine.Id))
        //            .ForMember(p => p.Group, c => c.MapFrom(medicine => medicine.Group))
        //            .ForMember(p => p.MedicineInteractions, c => c.MapFrom(medicine => medicine.MedicineInteractions))
        //            .ForMember(p => p.Compositions, c => c.MapFrom(medicine => medicine.Compositions))
        //            .ForMember(p => p.CompositionsId, c => c.MapFrom(medicine => medicine.CompositionsId))
        //            .ForMember(p => p.Contraindications, c => c.MapFrom(medicine => medicine.Contraindications))
        //            .ForMember(p => p.ContraindicationsId, c => c.MapFrom(medicine => medicine.ContraindicationsId))
        //            .ForMember(p => p.Name, c => c.MapFrom(medicine => medicine.Name))
        //            .ForMember(p => p.PharmacotherapeuticGroupId, c => c.MapFrom(medicine => medicine.PharmacotherapeuticGroupId))
        //            .ReverseMap();

        //        CreateMap<MedicineComposition, MedicineCompositionModel>()
        //            .ForMember(p => p.CompositionId, c => c.MapFrom(medicinecomposition => medicinecomposition.CompositionId))
        //            .ForMember(p => p.MedicineId, c => c.MapFrom(medicinecomposition => medicinecomposition.MedicineId))
        //            .ForMember(p => p.Composition, c => c.MapFrom(medicinecomposition => medicinecomposition.Composition))
        //            .ForMember(p => p.Medicine, c => c.MapFrom(medicinecomposition => medicinecomposition.Medicine))
        //            .ReverseMap();

        //        CreateMap<MedicineInteraction, MedicineInteractionModel>()
        //            .ForMember(p => p.Description, c => c.MapFrom(medicineinteraction => medicineinteraction.Description))
        //            .ForMember(p => p.CompositionId, c => c.MapFrom(medicineinteraction => medicineinteraction.CompositionId))
        //            .ForMember(p => p.MedicineId, c => c.MapFrom(medicineinteraction => medicineinteraction.MedicineId))
        //            .ForMember(p => p.Composition, c => c.MapFrom(medicineinteraction => medicineinteraction.Composition))
        //            .ForMember(p => p.Medicine, c => c.MapFrom(medicineinteraction => medicineinteraction.Medicine))
        //            .ReverseMap();

        //        CreateMap<PharmacotherapeuticGroup, PharmacotherapeuticGroupModel>()
        //            .ForMember(p => p.Id, c => c.MapFrom(group => group.Id))
        //            .ForMember(p => p.Title, c => c.MapFrom(group => group.Title))
        //            .ReverseMap();

        //        CreateMap<Role, RoleModel>()
        //            .ForMember(p => p.Id, c => c.MapFrom(role => role.Id))
        //            .ForMember(p => p.UserRole, c => c.MapFrom(role => role.UserRole))
        //            .ReverseMap();

        //        CreateMap<User, UserModel>()
        //            .ForMember(p => p.Id, c => c.MapFrom(user => user.Id))
        //            .ForMember(p => p.Email, c => c.MapFrom(user => user.Email))
        //            .ForMember(p => p.FirstName, c => c.MapFrom(user => user.FirstName))
        //            .ForMember(p => p.LastName, c => c.MapFrom(user => user.LastName))
        //            .ForMember(p => p.Pass, c => c.MapFrom(user => user.Pass))
        //            .ForMember(p => p.Patients, c => c.MapFrom(user => user.Patients))
        //            .ForMember(p => p.PatientsId, c => c.MapFrom(user => user.PatientsId))
        //            .ForMember(p => p.Role, c => c.MapFrom(user => user.Role))
        //            .ForMember(p => p.RoleId, c => c.MapFrom(user => user.RoleId))
        //            .ReverseMap();
    }
    }
}