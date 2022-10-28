using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CMD.Doctors.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IDoctorService
    {

        
        [OperationContract]
        bool ValidateDoctor(String emailId, String password);
    
        [OperationContract(IsInitiating = true, IsTerminating = false)]
        bool AddDoctor(Doctor doctor); //at time of sign up

        [OperationContract(IsInitiating = false, IsTerminating = false)]
        List<Doctor> GetAllDoctors();

        [OperationContract(IsInitiating = false, IsTerminating = false)]
        Doctor GetDoctorByNpiNo(String npiNo);

        [OperationContract(IsInitiating = false, IsTerminating = false)]
        bool UpdateDoctor(Doctor doctor, String npiNo);

        [OperationContract(IsInitiating = false, IsTerminating = false)]
        bool RemoveDoctor(String npiNo);

        [OperationContract(IsInitiating = false, IsTerminating = true)]
        bool SignOut();
    }
}
