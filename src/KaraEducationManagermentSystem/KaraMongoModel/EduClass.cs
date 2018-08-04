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
        /// teacher Id
        /// </summary>
        public short teacherId { get; set; }

        public ObservableCollection<EduStudent> Students { get; set; }

        [BsonIgnore]
        public EduTeacher Teacher { get; set; }

        [BsonIgnore]
        public School Parent { get; set; }

    }
}