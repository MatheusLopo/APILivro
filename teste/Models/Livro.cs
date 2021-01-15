using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
 
    public class Livro
    {
        
        public int Id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public double price { get; set; }
        public Specifications Specifications { get; set; }
    


    }
    public class Specifications
    {
        public DateTime originallypublished { get; set; }
        public string author { get; set; }
        public int pageCount { get; set; }
        /*[JsonExtensionData]
        public Dictionary<string, object> ExData { get; set; }
        */
        public object genres { get; set; }
        public object illustrator { get; set; }
    }
   
}
