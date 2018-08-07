using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KaraEducationManagermentService
{
    [DataContract]
    public class TreeviewDataType
    {
        [DataMember]
        public int Key;

        [DataMember]
        public string DisplayData;
    }
}