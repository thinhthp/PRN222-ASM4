using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zQuitSmoking.Repositories.ThinhTHP;
using zQuitSmoking.Repositories.ThinhTHP.Models;

namespace zQuitSmoking.Services.ThinhTHP
{
    public class NotificationThinhThpService
    {
        private readonly NotificationThinhThpRepository _repository;

        public NotificationThinhThpService()
        {
            _repository = new NotificationThinhThpRepository();
        }

        public async Task<List<NotificationThinhThp>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
