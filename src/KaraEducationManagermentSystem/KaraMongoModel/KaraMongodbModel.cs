using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
        private IMongoCollection<EduClass> classCollection = null;

        #region Constructor
        public KaraMongodbModel(string inUri, string dbname)
        {

            client = new MongoClient(uri);
            db = client.GetDatabase("kara_db");
            schoolCollection = db.GetCollection<School>("schools");
            classCollection = db.GetCollection<EduClass>("classes");
        }

        #endregion
        #region School Area

        public ObservableCollection<School> SchoolCollection
        {
            get
            {
                try
                {
                    ObservableCollection<School> result = new ObservableCollection<School>();
                    foreach (var item in schoolCollection.AsQueryable())
                    {
                        result.Add(item);
                    }
                    return result;
                }
                catch
                {
                    return null;
                }
            }
        }

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

        #region Class Area
        public async Task FindAllClassForSchool(School school)
        {
            var schoolid = school._id.Pid;
            var task =  await   classCollection.FindAsync(x => x.schoolId == schoolid);
            List<EduClass> list = await task.ToListAsync();
            school.ListClass = new ObservableCollection<EduClass>();
            foreach(var item in list)
            {
                school.ListClass.Add(item);
            }
        }

        public async Task AsyncInsertOne(EduClass inclass)
        {
            if (inclass == null)
            {
                return;
            }
            if (classCollection == null)
            {
                return;
            }

            // Use InsertOneAsync for single BsonDocument insertion.
            await classCollection.InsertOneAsync(inclass);
        }
        #endregion
    }
}
