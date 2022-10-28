using AutoMapper;
using CMD.Doctors.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CMD.Doctors.Service
{    
    public class DoctorService : IDoctorService
    {
        BusinessLogic.DoctorManager manager = new BusinessLogic.DoctorManager();

        public bool AddDoctor(Doctor doctor)
        {            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>());
            var mapper = new Mapper(config);
            DoctorDTO doctorDTO = mapper.Map<DoctorDTO>(doctor);

            return manager.AddDoctor(doctorDTO);
        }

        public List<Doctor> GetAllDoctors()
        {
            List<DoctorDTO> doctors = manager.getAllDoctors();
            List<Doctor> allDoctors = new List<Doctor>();
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, Doctor>());
            var mapper = new Mapper(config);

            for (int i = 0; i < doctors.Count; i++)
            {
                Doctor doctor = mapper.Map<Doctor>(doctors[i]);
                allDoctors.Add(doctor);
            }
            return allDoctors;
        }

        public Doctor GetDoctorByNpiNo(string npiNo)
        {
            DoctorDTO doc = manager.getDoctorByNpiNo(npiNo);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, Doctor>());
            var mapper = new Mapper(config);
            Doctor doctor = mapper.Map<Doctor>(doc);

            return doctor;
        }

        public bool RemoveDoctor(string npiNo)
        {
            bool IsRemoved = false;
            if (manager.deleteDoctor(npiNo))
            {
                IsRemoved = true;
            }
            return IsRemoved;
        }

        public bool SignOut()
        {
            throw new NotImplementedException();
        }

        public bool UpdateDoctor(Doctor doctor, string npiNo)
        {
            bool IsUpadated = false;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>());
            var mapper = new Mapper(config);
            DoctorDTO doctorDTO = mapper.Map<DoctorDTO>(doctor);

            if (manager.updateDoctor(doctorDTO, npiNo))
            {
                IsUpadated = true;
            }
            return IsUpadated;
        }

        public bool ValidateDoctor(string emailId, string password)
        {
            bool IsValid = false;
            if (manager.validateDoctorForSignIn(emailId, password))
            {
                IsValid = true;
            }
            return IsValid;
        }
    }
}
