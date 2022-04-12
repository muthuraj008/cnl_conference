using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cnl_conference.Services
{
    public interface IConferenceServices
    {
        Task<IEnumerable<ConferenceModel>> GetAll();
        Task<ConferenceModel> GetById(int id);
        //Task<StatisticsModel> GetStatistics();
        Task Add(ConferenceModel model);
    }
}
