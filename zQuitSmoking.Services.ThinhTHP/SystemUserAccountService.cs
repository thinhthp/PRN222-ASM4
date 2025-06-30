using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zQuitSmoking.Repositories.ThinhTHP.Models;
using zQuitSmoking.Repositories.ThinhTHP;

namespace zQuitSmoking.Services.ThinhTHP
{
    public class SystemUserAccountService
    {
        private readonly SystemUserAccountRepository _repository;
        public SystemUserAccountService()
        {
            _repository = new SystemUserAccountRepository();
        }

        public async Task<SystemUserAccount> GetUserAccountAsync(string username, string password)
        {
            return await _repository.GetUserAccount(username, password);
        }

        public async Task<List<SystemUserAccount>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
