
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public ProjectsController(IDeployHandler deployHandler){
            this.deployHandler = deployHandler;
        }
        
        [HttpGet]
        [Route("getall")]
        public ActionResult<IEnumerable<Project>> Get(){
            var project = new Project(){
                Id = "couchpotato-master",
                Name = "Couchpotato",
                BranchName = "couchpotato-master",
                Version = "1.0.23",
                RepositoryUrl = "https://github.com/mattiasnorell/feedbag.git",
                LastDeployDateTime = DateTime.Now,
                Enviroments = new List<Enviroment>(){
                    new Enviroment
                    {
                        Id = "prod",
                        Name = "Production"
                    }
                }
            };

            return new List<Project>() { project };
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
