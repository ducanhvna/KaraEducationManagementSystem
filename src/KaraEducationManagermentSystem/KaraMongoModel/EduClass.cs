using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.ObjectModel;

namespace KaraMongoModelNS
{
    public class EduClass
    {

        [BsonId]
        public ObjectId _id { get; set; }

        /// <summary>
        /// Class Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short name
        /// </summary>
        public string ShortName { get; set; }

        public string Color { get; set; }

        /// <summary>
        /// teacher Id
        /// </summary>
        public short teacherId { get; set; }

        /// <summary>
        /// Custorm Field
        /// </summary>
        public ObservableCollection<CustomField> CustomFields { get; set; }

        public ObservableCollection<EduStudent> Students { get; set; }

        [BsonIgnore]
        public EduTeacher Teacher { get; set; }

        [BsonIgnore]
        public School Parent { get; set; }

    }
}