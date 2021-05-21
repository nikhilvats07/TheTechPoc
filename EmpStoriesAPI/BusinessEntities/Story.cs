using System;
using EmployeeStory.WebAPI.DAL.Repositiry;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EmployeeStory.BusinessEntities
{
    [BsonCollection("Story")]
    public class Story: MongoDocument
    {
       
        public string StoryId { get; set; }
        public string ReceiverEmployee { get; set; }
        public string SenderEmployee { get; set; }
        public DateTime? StoryCreatedDateTime { get; set; }
        public string StoryText { get; set; }
        
    }
}
