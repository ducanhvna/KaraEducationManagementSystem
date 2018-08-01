using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace KaraMongoModelNS
{
    public  class School
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public string Name { get; set; }

        public string AcademicYear { get; set; }


        [BsonIgnore]
        public ObservableCollection<EduClass> ListClass { get; set; }

        [BsonIgnore]
        public ObservableCollection<EduSubject> ListSubject { get; set; }

        [BsonIgnore]
        public ObservableCollection<EduClassRoom> ListClassRoom { get; set; }

        [BsonIgnore]
        public ObservableCollection<EduTeacher> Teachers { get; set; }

        public EduTimeTable TimeTable { get; set; }
    }
}
