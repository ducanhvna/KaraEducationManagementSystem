using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraMongoModelNS
{
    public class KaraMongodbModel
    {
        // Standard URI format: mongodb://[dbuser:dbpassword@]host:port/dbname
        String uri = "mongodb://localhost:27017";
        private MongoClient client = null;
        private IMongoDatabase db = null;
        private BsonDocument[] seedData;
        private IMongoCollection<School> schoolCollection = null;

        public KaraMongodbModel(string inUri, string dbname)
        {

            client = new MongoClient(uri);
            db = client.GetDatabase("kara_db");
            schoolCollection = db.GetCollection<School>("schools");
        }
        #region School Area
        public async Task AsyncInsertMany(List<School> listSchool)
        {

            if (schoolCollection == null)
            {
                return;
            }
            // Use InsertOneAsync for single BsonDocument insertion.
            await schoolCollection.InsertManyAsync(listSchool);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="school"></param>
        /// <returns></returns>
        public async Task AsyncInsertOne(School school)
        {
            if(school == null)
            {
                return;
            }
            if (schoolCollection == null)
            {
                return;
            }
            
            // Use InsertOneAsync for single BsonDocument insertion.
            await schoolCollection.InsertOneAsync(school);
        }
        #endregion
    }
}
