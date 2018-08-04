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
        public string Id { get; set; }

        public string Name { get; set; }

        public ObservableCollection<Parent> Parents { get; set; }

        [BsonIgnore]
        public EduClass Class { get; set; }



    }
}
