using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cnl_conference.Services
{
    public class ConferenceInMemoryServices : IConferenceServices
    {
        private readonly List<ConferenceModel> conferences = new List<ConferenceModel>();
        public ConferenceInMemoryServices()
        {
                conferences.Add(new ConferenceModel { Id = 1, Name="Security",Presenter="Vijay", Location="chennai", Start= new DateTime(2022, 4, 12), AttendeeTotal = 200});
                conferences.Add(new ConferenceModel { Id = 2, Name = "Kubernetes", Presenter = "Khaja", Location = "Hyderabad", Start = new DateTime(2022, 5, 4), AttendeeTotal = 100 });

        }
        public Task Add(ConferenceModel model)
        {
            model.Id = conferences.Max(c=>c.Id) + 1;
            conferences.Add(model);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ConferenceModel>> GetAll()
        {
            return Task.Run(() => conferences.AsEnumerable());
        }

        public Task<ConferenceModel> GetById(int id)
        {
            return Task.Run(() => conferences.First(c => c.Id == id));
        }
    }
}
