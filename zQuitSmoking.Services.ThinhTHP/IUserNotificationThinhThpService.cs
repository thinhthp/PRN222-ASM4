using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zQuitSmoking.Repositories.ThinhTHP.Models;

namespace zQuitSmoking.Services.ThinhTHP
{
    public interface IUserNotificationThinhThpService
    {
        Task<List<UserNotificationThinhThp>> GetAllAsync();
        Task<UserNotificationThinhThp> GetByIdAsync(int code);
        Task<List<UserNotificationThinhThp>> SearchAsync(string message, string response, string userName);
        Task<(List<UserNotificationThinhThp> items, int totalCount)> SearchAsync(string message, string response, string userName, int? pageNumber = null, int? pageSize = null);
        Task<int> CreateAsync(UserNotificationThinhThp userNotificationThinhThp);
        Task<int> UpdateAsync(UserNotificationThinhThp userNotificationThinhThp);
        Task<bool> DeleteAsync(int code);
    }
}
