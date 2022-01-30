using Microsoft.EntityFrameworkCore;
using TollPassing.Context;
using TollPassing.Models;

namespace TollPassing.Repositories
{
    public interface IPassingRepository
    {
        Task<TollPassingModel> CreateAsync(TollPassingModel entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TollPassingModel>> GetAllAsync();
        Task<int> CountPlateInCurrentMonthAsync(string plate);
        Task<TollPassingModel> GetAsync(int id);
        Task<TollPassingModel> UpdateAsync(TollPassingModel entity);
    }
    public class PassingRepository : IPassingRepository
    {
        private readonly PostgresContext _postgresContext;

        public PassingRepository(PostgresContext postgresContext)
        {
            _postgresContext = postgresContext;
        }

        public async Task<TollPassingModel> CreateAsync(TollPassingModel entity)
        {
            try
            {
                await _postgresContext.Passing.AddAsync(entity);
                await _postgresContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                throw new Exception($"Impossible to create passing => {e.Message}");
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var passing = await _postgresContext.Passing.FindAsync(id);
                if (passing == null)
                    throw new Exception("not found");

                _postgresContext.Passing.Remove(passing);
                await _postgresContext.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception($"Impossible to delete passing => {e.Message}");
            }

        }
        public async Task<IEnumerable<TollPassingModel>> GetAllAsync()
        {
            try
            {
                

                return await _postgresContext
                    .Passing
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Impossible to find passing => {e.Message}");
            }
        }

        public async Task<int> CountPlateInCurrentMonthAsync(string plate)
        {
            DateTime currentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 01).ToUniversalTime();
            return await _postgresContext.Passing.Where(w => w.LicensePlate == plate && w.DateTime >= currentMonth).CountAsync();
        }
        public async Task<TollPassingModel> GetAsync(int id)
        {
            try
            {
                return await _postgresContext.Passing.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Impossible to find passing => {e.Message}");
            }
        }
        public async Task<TollPassingModel> UpdateAsync(TollPassingModel entity)
        {
            try
            {
                var passing = await _postgresContext.Passing.FindAsync(entity.Id);

                if (passing == null)
                    throw new Exception($"not found");

                passing = entity;

                await _postgresContext.SaveChangesAsync();

                return passing;
            }
            catch (Exception e)
            {
                throw new Exception($"Impossible to update passing => {e.Message}");
            }
        }

    }
}
