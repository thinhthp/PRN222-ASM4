using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zQuitSmoking.Repositories.ThinhTHP.DBContext;

namespace zQuitSmoking.Repositories.ThinhTHP
{
    public interface IUnitOfWork : IDisposable
    {
        SystemUserAccountRepository SystemUserAccountRepository { get; }
        UserNotificationThinhThpRepository UserNotificationThinhThpRepository { get; }
        NotificationThinhThpRepository NotificationThinhThpRepository { get; }
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SE18_PRN222_SE1809_G6_QuitSmokingDBContext _context;
        private SystemUserAccountRepository _systemUserAccountRepository;
        private UserNotificationThinhThpRepository _userNotificationThinhThpRepository;
        private NotificationThinhThpRepository _notificationThinhThpRepository;
        public UnitOfWork()
        {
            _context ??= new SE18_PRN222_SE1809_G6_QuitSmokingDBContext();
        }

        public SystemUserAccountRepository SystemUserAccountRepository
        {
            get
            {
                return _systemUserAccountRepository ??= new SystemUserAccountRepository(_context);
            }
        }
        public UserNotificationThinhThpRepository UserNotificationThinhThpRepository
        {
            get
            {
                return _userNotificationThinhThpRepository ??= new UserNotificationThinhThpRepository(_context);
            }
        }
        public NotificationThinhThpRepository NotificationThinhThpRepository
        {
            get
            {
                return _notificationThinhThpRepository ??= new NotificationThinhThpRepository(_context);
            }
        }

        public int SaveChanges()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        public async Task<int> SaveChangesAsync()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}