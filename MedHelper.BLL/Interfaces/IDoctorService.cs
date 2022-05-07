using MedHelper.BLL.Dto.Doctor;
using MedHelper.BLL.Dto.Responses;
using MedHelper.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.BLL.Interfaces
{
    public interface IDoctorService
    {

        Task<DoctorResponse> GetByIdAsync(int id);
        Task UpdateAsync(UpdateDoctorDto model);
        List<Patient> GetPatients(int id, string search);
    }
}
