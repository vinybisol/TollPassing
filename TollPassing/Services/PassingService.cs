using TollPassing.Models;
using TollPassing.Models.InputModel.OutputModel;
using TollPassing.Repositories;

namespace TollPassing.Services
{
    public interface IPassingService
    {
        Task<OutputTollPassingModel> AddPassing(TollPassingModel passing);
    }
    public class PassingService : IPassingService
    {
        private readonly IPassingRepository _passingRepository;

        public PassingService(IPassingRepository passingRepository)
        {
            _passingRepository = passingRepository;
        }

        public async Task<OutputTollPassingModel> AddPassing(TollPassingModel passing)
        {
            var ret = await _passingRepository.CreateAsync(passing);
            var passingCount = await _passingRepository.CountPlateInCurrentMonthAsync(ret.LicensePlate);
            
            ret.UpdatePrice(passingCount, out decimal discountLevel);

            return new OutputTollPassingModel()
            {
                Price = ret.Price,
                Id = ret.Id,
                CountOfPassedInMonth = passingCount,
                DateTime = ret.DateTime.ToLocalTime(),
                LicensePlate = ret.LicensePlate,
                Vehicle = ret.Vehicle,
                DiscountLevel = discountLevel,
            };
        }
    }
}
