using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace KaraEducationManagermentService
{
    [ServiceContract]
    public interface ITeacherService
    {
        [OperationContract]
        bool RegisterTeacher(string username, string password);

        [OperationContract]
        TreeviewDataType GetListClass();


    }
}