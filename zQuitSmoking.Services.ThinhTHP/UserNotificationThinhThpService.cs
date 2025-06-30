using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zQuitSmoking.Repositories.ThinhTHP;
using zQuitSmoking.Repositories.ThinhTHP.Models;

namespace zQuitSmoking.Services.ThinhTHP
{
    public class UserNotificationThinhThpService : IUserNotificationThinhThpService
    {
        //private readonly UserNotificationThinhThpRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserNotificationThinhThpService()
        {
            //_repository = new UserNotificationThinhThpRepository();
            _unitOfWork = new UnitOfWork();
        }

        public async Task<int> CreateAsync(UserNotificationThinhThp userNotificationThinhThp)
        {
            return await _unitOfWork.UserNotificationThinhThpRepository.CreateAsync(userNotificationThinhThp);
        }

        public async Task<bool> DeleteAsync(int code)
        {
            var item = await _unitOfWork.UserNotificationThinhThpRepository.GetByIdAsync(code);
            if (item != null)
            {
                return await _unitOfWork.UserNotificationThinhThpRepository.RemoveAsync(item);
            }
            return false;
        }

        public async Task<List<UserNotificationThinhThp>> GetAllAsync()
        {
            return await _unitOfWork.UserNotificationThinhThpRepository.GetAllAsync();
        }

        public async Task<UserNotificationThinhThp> GetByIdAsync(int code)
        {
            return await _unitOfWork.UserNotificationThinhThpRepository.GetByIdAsync(code);
        }

        public async Task<List<UserNotificationThinhThp>> SearchAsync(string message, string response, string userName)
        {
            return await _unitOfWork.UserNotificationThinhThpRepository.SearchAsync(message, response, userName);
        }

        public async Task<(List<UserNotificationThinhThp> items, int totalCount)> SearchAsync(string message, string response, string userName, int? pageNumber = null, int? pageSize = null)
        {
            return await _unitOfWork.UserNotificationThinhThpRepository.SearchAsync(message, response, userName, pageNumber, pageSize);
        }

        public Task<int> UpdateAsync(UserNotificationThinhThp userNotificationThinhThp)
        {
            return _unitOfWork.UserNotificationThinhThpRepository.UpdateAsync(userNotificationThinhThp);
        }
    }
}
