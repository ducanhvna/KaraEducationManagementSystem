using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraMongoModelNS
{
    public class EduStudent
    {
        /// <summary>
        /// Student full Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Student Short name
        /// </summary>
        public string ShortName { get; set; }


        /// <summary>
        /// Gender
        /// </summary>
        public bool Male { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        [BsonIgnore]
        public ObservableCollection<EduClass> ClassTeacherForClass { get; set; }

        [BsonIgnore]
        public ObservableCollection<EduClassRoom> ClassRooms { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        public string Color { get; set; }
        public ObservableCollection<CustomField> CustomFields { get; set; }

        /// <summary>
        /// Time off
        /// </summary>
        public ObservableCollection<TimeOff> TimeOffs { get; set; }


    }
}
