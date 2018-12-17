using System.Collections.Generic;
using System.Threading.Tasks;
using BenderApi.Models;

namespace BenderApi.Business.Database{
    public interface IDatabaseRepository {
        IEnumerable<Project> GetAllProjects();
    }
}