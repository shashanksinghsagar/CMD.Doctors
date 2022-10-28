using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temporary
{
    public class Program
    {
        static void Main(string[] args)
        {
            CMD.Doctors.Models.Doctor doctor = new CMD.Doctors.Models.Doctor();
            //automapper and passing
            doctor.Name = "roanoaZoro";
            doctor.PracticeLocation = "Japan";
            doctor.PhoneNo = "1234567890";
            //doctor.ImageURL = "test";
            doctor.Speciality = "ThreeStyleSword";
            //doctor.Title = "SwordsMan";
            doctor.NpiNo = "0987654321";
            //doctor.userName = "test";
            doctor.Password = "password";
            doctor.Gender = "male";
            doctor.EmailId = "test@gmail.com";
            CMD.Doctors.Repository.DbManager dbManager = new CMD.Doctors.Repository.DbManager();
            if (dbManager.AddDoctor(doctor))
            {
                Console.WriteLine("Added");
            }
        }
    }
}
