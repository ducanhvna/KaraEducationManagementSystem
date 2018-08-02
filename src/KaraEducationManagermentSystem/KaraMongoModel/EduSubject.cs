using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KaraMongoModelNS
{
    public class EduSubject
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public string Title { get; set; }
        public string ShortName { get; set; }
        public string Color { get; set; }
        public string Picture { get; set; }

        [BsonIgnore]
        public School school { get; set; }
    }
}