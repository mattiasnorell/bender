
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
                Id = "feedbag-master",
                Name = "Feedbag",
                BranchName = "feedbag-master",
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

        [HttpGet]
        [Route("deploy")]
        public async Task<ActionResult<List<string>>> Deploy(string id)
        {
            var buildSteps = new List<BuildStep>{
                new BuildStep(){
                    Application = "ls",
                    Arguments = ""
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
