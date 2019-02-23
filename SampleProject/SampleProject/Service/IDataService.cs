using SampleProject.Model;
using System.Threading.Tasks;

namespace SampleProject.Service
{
    public interface IDataService
    {
        Task<Info> GetInfo();
    }
}
