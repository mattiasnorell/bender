using System.Collections.Generic;

namespace BenderApi.Models{
    public class Enviroment{
        public string Id { get ;set; }
        public string Name {get ;set;}
        public string Destination{ get;set;}
        public IEnumerable<BuildConfiguration> BuildConfiguration { get;set;}
    }
}