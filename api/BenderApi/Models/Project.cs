using System;
using System.Collections.Generic;

namespace BenderApi.Models{
    public class Project{
        public string Id { get ;set; }
        public string Name {get ;set;}
        public string RepositoryUrl{ get;set;}
        public string BranchName { get;set;}
        public string Version { get;set; }
        public DateTime LastDeployDateTime { get ;set;}
        public IEnumerable<Enviroment> Enviroments{ get; set; }
    }
}