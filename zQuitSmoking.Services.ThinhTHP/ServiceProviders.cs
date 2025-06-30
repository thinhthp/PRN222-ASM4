using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zQuitSmoking.Services.ThinhTHP
{
    public interface IServiceProviders
    {
        SystemUserAccountService SystemUserAccountService { get; }
        //UserNotificationThinhThpService UserNotificationThinhThpService { get; }
        NotificationThinhThpService NotificationThinhThpService { get; }
        IUserNotificationThinhThpService UserNotificationThinhThpService { get; }
    }
     public class ServiceProviders : IServiceProviders
    {
        private SystemUserAccountService _systemUserAccountService;
        private UserNotificationThinhThpService _userNotificationThinhThpService;
        private NotificationThinhThpService _notificationThinhThpService;
        public ServiceProviders()
        {
            _systemUserAccountService ??= new SystemUserAccountService();
            _userNotificationThinhThpService ??= new UserNotificationThinhThpService();
            _notificationThinhThpService ??= new NotificationThinhThpService();
        }
        public SystemUserAccountService SystemUserAccountService
        {
            get { return _systemUserAccountService ??= new SystemUserAccountService(); }
        }
        public IUserNotificationThinhThpService UserNotificationThinhThpService
        {
            get { return _userNotificationThinhThpService ??= new UserNotificationThinhThpService(); }
        }
        public NotificationThinhThpService NotificationThinhThpService
        {
            get { return _notificationThinhThpService ??= new NotificationThinhThpService(); }
        }
    }
}
