using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeStory.WebAPI.BusinessEntities
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }

    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
    public class EmployeeDatabaseSettings : IEmployeeDatabaseSettings  
    {  
        public string EmployeesCollectionName { get; set; }  
        public string ConnectionString { get; set; }  
        public string DatabaseName { get; set; }  
    }  
  
    public interface IEmployeeDatabaseSettings  
    {  
        public string EmployeesCollectionName { get; set; }  
        public string ConnectionString { get; set; }  
        public string DatabaseName { get; set; }  
    }  
}
