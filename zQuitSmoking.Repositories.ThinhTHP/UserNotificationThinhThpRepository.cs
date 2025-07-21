using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zQuitSmoking.Repositories.ThinhTHP.Basic;
using zQuitSmoking.Repositories.ThinhTHP.DBContext;
using zQuitSmoking.Repositories.ThinhTHP.Models;

namespace zQuitSmoking.Repositories.ThinhTHP
{
    public class UserNotificationThinhThpRepository : GenericRepository<UserNotificationThinhThp>
    {
        public UserNotificationThinhThpRepository() { }

        public UserNotificationThinhThpRepository(SE18_PRN222_SE1809_G6_QuitSmokingDBContext context) => _context = context;

        public async Task<List<UserNotificationThinhThp>> GetAllAsync()
        {
            var item = await _context.UserNotificationThinhThps
                .OrderByDescending(x => x.SentDate)
                .Include(x => x.NotificationThinhThp).Include(x => x.UserAccount)
                .ToListAsync();
            return item ?? new List<UserNotificationThinhThp>();
        }

        public new async Task<UserNotificationThinhThp> GetByIdAsync(int id)
        {
            var item = await _context.UserNotificationThinhThps
                .Include(x => x.NotificationThinhThp).Include(x => x.UserAccount)
                .FirstOrDefaultAsync(x => x.UserNotificationThinhThpid == id);
            return item ?? new UserNotificationThinhThp();
        }

        public async Task<List<UserNotificationThinhThp>> SearchAsync(string message, string response, string userName)
        {
            var items = await _context.UserNotificationThinhThps
                .OrderByDescending(x => x.SentDate)
                .Include(x => x.NotificationThinhThp).Include(x => x.UserAccount)
                .Where(x =>
                (x.NotificationThinhThp.Message.Contains(message) || string.IsNullOrEmpty(message))
                && (x.Response.Contains(response) || string.IsNullOrEmpty(response))
                //&& (userId == 0 || x.UserAccount.UserAccountId == userId))
                && (x.UserAccount.UserName.Contains(userName) || string.IsNullOrEmpty(userName)))
                .ToListAsync();
            return items ?? new List<UserNotificationThinhThp>();
        }

        public async Task<(List<UserNotificationThinhThp> items, int totalCount)> SearchAsync(string message, string response, string userName, int? pageNumber = null, int? pageSize = null)
        {
            var query = _context.UserNotificationThinhThps
                .OrderByDescending(x => x.SentDate)
                .Include(x => x.NotificationThinhThp)
                .Include(x => x.UserAccount)
                .Where(x =>
                    (string.IsNullOrEmpty(message) || x.NotificationThinhThp.Message.Contains(message)) &&
                    (string.IsNullOrEmpty(response) || x.Response.Contains(response)) &&
                    (string.IsNullOrEmpty(userName) || x.UserAccount.UserName.Contains(userName))
                );

            int totalCount = await query.CountAsync();

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            var items = await query.ToListAsync();
            return (items, totalCount);
        }
    }
}
