using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BmayFinalProject
{
    class States
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("state")]
        public String State { get; set; }
        [BsonElement("capital")]
        public String Capital {get; set;}
        [BsonElement("year")]
        public int Year {get; set;}
        [BsonElement("mammal")]
        public String Mammal {get; set;}
        [BsonElement("bird")]
        public String Bird{get; set;}
        [BsonElement("governor")]
        public String Governor {get; set;}

        public States(string state, string capital, int year, string mammal, string bird, string governor)
        {
            State = state;
            Capital = capital;
            Year = year;
            Mammal = mammal;
            Bird = bird;
            Governor = governor;
        }
    }
}
