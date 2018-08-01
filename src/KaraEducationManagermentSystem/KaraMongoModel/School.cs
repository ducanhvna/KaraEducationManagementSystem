using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraMongoModelNS
{
    public  class School
    {
        [BsonId]
        public MongoDB.Bson.ObjectId _id { get; set; }

       
        public string schoolId { get; set; }
    }
}
