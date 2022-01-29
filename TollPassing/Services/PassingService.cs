using TollPassing.Models;
using TollPassing.Repositories;

namespace TollPassing.Services
{
    public interface IPassingService
    {
        Task<TollPassingModel> AddPassing(TollPassingModel passing);
    }
    public class PassingService : IPassingService
    {
        private readonly IPassingRepository _passingRepository;

        public PassingService(IPassingRepository passingRepository)
        {
            _passingRepository = passingRepository;
        }

        public async Task<TollPassingModel> AddPassing(TollPassingModel passing)
        {
            passing.Price = 7.90M;
            return await _passingRepository.CreateAsync(passing);
        }
    }
}
