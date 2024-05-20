using Backend.Db;
using Backend.Dto;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{

    public interface ISessionService
    {
        Task<List<MsUserDto>> GetUser();
        Task<bool> ValidateUser(string username, string password);
    }
    public class SessionService : ISessionService
    {
        private readonly TestDbContext dbContext;
        public SessionService(TestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<MsUserDto>> GetUser()
        {
            List<MsUserDto> ListData = new List<MsUserDto>();
            var result = await dbContext.MsUsers.AsNoTracking().ToListAsync();

            foreach (var item in result)
            {
                MsUserDto dto = new MsUserDto
                {
                    UserId = item.UserId,
                    UserName = item.UserName,
                    IsActive = item.IsActive
                };
                ListData.Add(dto);
            }
            return ListData;
        }

        public async Task<bool> ValidateUser(string username, string password)
        {
            var users = await dbContext.MsUsers.AsNoTracking().ToListAsync();
            var user = users.FirstOrDefault(u => u.UserName == username && u.Password == password);
            return user != null;
        }
    }
}
