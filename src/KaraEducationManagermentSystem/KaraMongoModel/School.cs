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
        public School() { }
        [BsonId]
        public ObjectId _id { get; set; }

        public string Name { get; set; }

        public string AcademicYear { get; set; }


        public ObservableCollection<EduClass> ListClass { get; set; }


        public ObservableCollection<EduSubject> ListSubject { get; set; }

        public ObservableCollection<EduClassRoom> ListClassRoom { get; set; }

        public ObservableCollection<EduTeacher> Teachers { get; set; }


        public ObservableCollection<EduStudent> UnassignStudent { get; set; }

        public ObservableCollection<EduTestingTerm> TestingTerms { get; set; }

        public EduTimeTable TimeTable { get; set; }
    }
}
