using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KaraEducationManagermentService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "eTeacherService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select eTeacherService.svc or eTeacherService.svc.cs at the Solution Explorer and start debugging.
    public class eTeacherService : IeTeacherService
    {
        public void DoWork()
        {
        }

        public TreeviewDataType GetListClass()
        {
            throw new NotImplementedException();
        }

        public bool RegisterTeacher(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
