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
    public class NotificationThinhThpRepository : GenericRepository<NotificationThinhThp>
    {
        public NotificationThinhThpRepository() { }
        public NotificationThinhThpRepository(SE18_PRN222_SE1809_G6_QuitSmokingDBContext context) => _context = context;
    }
}
