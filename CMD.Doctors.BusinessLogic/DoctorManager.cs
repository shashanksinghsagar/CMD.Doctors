using AutoMapper;
using CMD.Doctors.DTOs;
using CMD.Doctors.Models;
using CMD.Doctors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Doctors.BusinessLogic
{
    public class DoctorManager
    {
        DbManager dbManager = new DbManager();
        public bool AddDoctor(DoctorDTO doctorDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, Doctor>());
            var mapper = new Mapper(config);
            Doctor doctor = mapper.Map<Doctor>(doctorDTO);

            return dbManager.AddDoctor(doctor);
        }

        public bool deleteDoctor(String npiNo)
        {
            bool isDeleted = false;
            long idToBeSearched = getDoctorIdUsingNpiNo(npiNo);

            if (dbManager.deleteDoctorById(idToBeSearched))
            {
                isDeleted = true;
            }

            return isDeleted;
        }

        public List<DoctorDTO> getAllDoctors()
        {
            List<Doctor> doctors = dbManager.getAllDoctors();
            List<DoctorDTO> allDoctors = new List<DoctorDTO>();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>());
            var mapper = new Mapper(config);
            for (int i = 0; i < doctors.Count(); i++)
            {
                DoctorDTO doctor = mapper.Map<DoctorDTO>(doctors[i]);
                allDoctors.Add(doctor);
            }
            return allDoctors;
        }

        public DoctorDTO getDoctorByNpiNo(string npiNo)
        {
            long npiNoToBeSearched = getDoctorIdUsingNpiNo(npiNo);
            Doctor doc = dbManager.getDoctorById(npiNoToBeSearched);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>());
            var mapper = new Mapper(config);
            DoctorDTO doctor = mapper.Map<DoctorDTO>(doc);

            return doctor;
        }

        public bool updateDoctor(DoctorDTO doctorDTO, String npiNo)
        {
            bool isUpdated = false;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, Doctor>());
            var mapper = new Mapper(config);
            Doctor doctor = mapper.Map<Doctor>(doctorDTO);

            long idToBeSearched = getDoctorIdUsingNpiNo(npiNo);
            if (dbManager.updateDoctor(doctor, idToBeSearched))
            {
                isUpdated = true;
            }
            return isUpdated;
        }

        public bool validateDoctorForSignIn(string emailId, string password)
        {
            bool isValid = false;
            if (dbManager.validateDoctorForSignIn(emailId, password))
            {
                isValid = true;
            }

            return isValid;
        }

        private long getDoctorIdUsingNpiNo(string npiNo)
        {
            long idToBeSearched = 0;
            List<DoctorDTO> docList = getAllDoctors();
            foreach (DoctorDTO doctorDTO in docList)
            {
                if (doctorDTO.NpiNo.Equals(npiNo))
                {
                    idToBeSearched = doctorDTO.Id;
                }
            }
            return idToBeSearched;
        }
    }
}
