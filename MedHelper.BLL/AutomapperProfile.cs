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
            CreateMap<Patient, PatientModel>()
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

            

        }
    }
}