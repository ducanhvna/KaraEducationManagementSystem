using KaraMongoModelNS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraEducationManagermentSystem.ViewModel
{
    interface IManageSchoolBase
    {
        /// <summary>
        /// School Object
        /// </summary>
        School SchoolObject { get; set; }
        KaraMongodbModel EduModel { get; set; }
    }
}
