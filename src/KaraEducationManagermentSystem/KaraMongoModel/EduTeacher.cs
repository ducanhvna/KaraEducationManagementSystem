
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.ObjectModel;

namespace KaraMongoModelNS
{
    public class EduTeacher
    {
        /// <summary>
        /// Teacher full Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Teacher Short name
        /// </summary>
        public string ShortName { get; set; }


        /// <summary>
        /// Gender
        /// </summary>
        public bool Male { get; set; }

   
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Title { get; set; }

        [BsonIgnore]
        public ObservableCollection<EduClass> ClassTeacherForClass { get; set; }      
        
        [BsonIgnore]
        public ObservableCollection<EduClassRoom> ClassRooms { get; set; }
        public string Color { get; set; }
        public ObservableCollection<CustomField> CustomFields { get; set; }

        public  ObservableCollection<TimeOff> TimeOffs { get; set; }

    }
}