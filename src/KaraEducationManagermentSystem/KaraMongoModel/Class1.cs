using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraMongoModelNS
{
    public enum ParentsRelation
    {
        Father, 
        Mother, 
        Brother,
        Sister,
        Other
    }
    public class Symbol
    {
        public string Name { get; set; }
        public ObjectId ID { get; set; }
    }
    public class Class1
    {
       public static void Connect()
        {
            Console.WriteLine("Mongo DB Test Application");
            Console.WriteLine("====================================================");
            Console.WriteLine("Started By:Kailash Chandra Behera");
            Console.WriteLine("Started On: 14 July 2014");
            Console.WriteLine("Configuration Setting: 172.16.1.24:27017");
            Console.WriteLine("====================================================");
            Console.WriteLine("Initializaing connection");
            string connectionString = "mongodb://localhost:27017";


            Console.WriteLine("Creating Client..........");
            MongoClient client = null;
            try
            {
                client = new MongoClient(connectionString);
                Console.WriteLine("Client Created Successfuly........");
                Console.WriteLine("Client: " + client.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Filed to Create Client.......");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Initianting Mongo Db Server.......");
            MongoServer server = null;
            try
            {
                Console.WriteLine("Getting Servicer object......");
                server = client.GetServer();

                Console.WriteLine("Server object created Successfully....");
                Console.WriteLine("Server :" + server.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Filed to getting Server Details");
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("Initianting Mongo Databaser.........");
            MongoDatabase database = null;
            try
            {
                Console.WriteLine("Getting reference of database.......");
                database = server.GetDatabase("kara_db");
                Console.WriteLine("Database Name : " + database.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Get reference of Database");
                Console.WriteLine("Error :" + ex.Message);
            }
            try
            {
                Console.WriteLine("Deleteing Collection Symbol");
                database.DropCollection("Symbol");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to delete collection from Database");
                Console.WriteLine("Error :" + ex.Message);
            }

            Console.WriteLine("Getting Collections from database Database.......");


            MongoCollection symbolcollection = null;
            try
            {
                symbolcollection = database.GetCollection<Symbol>("Symbols");
                Console.WriteLine(symbolcollection.Count().ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Get collection from Database");
                Console.WriteLine("Error :" + ex.Message);
            }
            ObjectId id = new ObjectId();
            Console.WriteLine("Inserting document to collection............");
            try
            {
                Symbol symbol = new Symbol();
                symbol.Name = "Star";
                symbolcollection.Insert(symbol);
                id = symbol.ID;

          

                Console.WriteLine(symbolcollection.Count().ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to insert into collection of Database " + database.Name);
                Console.WriteLine("Error :" + ex.Message);
            }

            try
            {
                //Console.WriteLine("Preparing Query Document............");
                //List<Symbol> query = symbolcollection.AsQueryable<Entity>().Where<Entity>(sb => sb.Name == "Kailash").ToList();

                //Symbol symbol = symbolcollection.AsQueryable<Entity>().Where<Entity>(sb => sb.ID == id).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to query from collection");
                Console.WriteLine("Exception :" + ex.Message);
            }
        
        }
    }
}
