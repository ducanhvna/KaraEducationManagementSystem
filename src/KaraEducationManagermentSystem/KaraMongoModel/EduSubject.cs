using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KaraMongoModelNS
{
    public class EduSubject
    {
        [BsonId]
        public ObjectId _id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Short name
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Picture
        /// </summary>
        public string Picture { get; set; }

        [BsonIgnore]
        public School school { get; set; }
    }
}