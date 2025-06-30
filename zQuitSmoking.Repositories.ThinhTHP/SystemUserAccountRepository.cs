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
    public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
    {
        public SystemUserAccountRepository() { }
        public SystemUserAccountRepository(SE18_PRN222_SE1809_G6_QuitSmokingDBContext context) => _context = context;

        public async Task<SystemUserAccount> GetUserAccount(string username, string password)
        {
            return await _context.SystemUserAccounts
                .FirstOrDefaultAsync(x => x.UserName == username && x.Password == password && x.IsActive == true);
        }

        public async Task<List<SystemUserAccount>> GetAllAsync()
        {
            var item = await _context.SystemUserAccounts
                .ToListAsync();
            return item ?? new List<SystemUserAccount>();
        }
    }
}
