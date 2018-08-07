using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraMongoModelNS
{
    /// <summary>
    /// Edu lesson
    /// </summary>
    public class EduLesson
    {
        /// <summary>
        /// Teacher Id
        /// </summary>
        public string TeacherId { get; set; }

        [BsonIgnore]
        public EduTeacher Teacher { get; set; }

        /// <summary>
        /// Class Name
        /// </summary>
        public string ClassName { get; set; }
        [BsonIgnore]
        public EduClass Class { get; set; }

        /// <summary>
        /// Custom Fields
        /// </summary>
        ObservableCollection<CustomField> CustomFields { get; set; }

        /// <summary>
        /// Lesson Type
        /// </summary>
        public int Lessontype { get; set; }

    }
}
