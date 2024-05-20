using Backend.Db;
using Backend.Dto;

namespace Backend.Services
{
    public interface ILocationService
    {
        Task<List<MsStorageLocationDto>> GetLocation();
    }
    public class LocationService : ILocationService
    {
        private readonly TestDbContext dbContext;
        public LocationService(TestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<MsStorageLocationDto>> GetLocation()
        {
            List<MsStorageLocationDto> ListData = new List<MsStorageLocationDto>();
            var result = await dbContext.MsStorageLocations.AsNoTracking().ToListAsync();

            foreach (var item in result)
            {
                MsStorageLocationDto dto = new MsStorageLocationDto
                {
                    LocationId = item.LocationId,
                    LocationName = item.LocationName
                };
                ListData.Add(dto);
            }
            return ListData;
        }
    }
}
