using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KaraEducationManagermentService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IeTeacherService" in both code and config file together.
    [ServiceContract]
    public interface IeTeacherService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        bool RegisterTeacher(string username, string password);

        [OperationContract]
        TreeviewDataType GetListClass();
    }
}
