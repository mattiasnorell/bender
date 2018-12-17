
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BenderApi.Business.Database;
using BenderApi.Business.Deploy;
using BenderApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BenderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IDeployHandler deployHandler;
        private readonly IDatabaseRepository databaseRepository;

        public ProjectsController(IDeployHandler deployHandler, IDatabaseRepository databaseRepository){
            this.deployHandler = deployHandler;
            this.databaseRepository = databaseRepository;
        }
        
        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("getall")]
        public ActionResult<IEnumerable<Project>> Get(){

            var projects = this.databaseRepository.GetAllProjects();
            
            return projects.ToList();
        }

        [HttpPost]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("deploy")]
        public async Task<ActionResult<List<string>>> Deploy(string id)
        {
            var buildSteps = new List<BuildStep>{
                new BuildStep(){
                    Application = "git",
                    Arguments = "clone --single-branch -b master https://github.com/mattiasnorell/couchpotato.git /Users/mattiasnorell/Documents/test/couchpotato"
                },
                new BuildStep(){
                    Application = "dotnet",
                    Arguments = "publish /Users/mattiasnorell/Documents/test/couchpotato --framework netcoreapp2.1 --runtime osx.10.11-x64 --output /Users/mattiasnorell/Documents/test/couchpotato/compiled"
                },
                new BuildStep(){
                    Application = "mv",
                    Arguments = "/Users/mattiasnorell/Documents/test/couchpotato/compiled/* /Users/mattiasnorell/Documents/test/couchpotato/site"
                }
            };

            var result = new List<string>();

            foreach(var step in buildSteps){
                var buildStepResult = await this.deployHandler.RunDeployStep(step.Application, step.Arguments);
                result.Add(buildStepResult);

                
            }

            return result;
        }

    }
}
