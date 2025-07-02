using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using zQuitSmoking.MVCWebApp.ThinhTHP.Models;
using zQuitSmoking.Repositories.ThinhTHP.DBContext;
using zQuitSmoking.Repositories.ThinhTHP.Models;
using zQuitSmoking.Services.ThinhTHP;

namespace zQuitSmoking.MVCWebApp.ThinhTHP.Controllers
{
    public class UserNotificationThinhThpsController : Controller
    {
        //private readonly SE18_PRN222_SE1809_G6_QuitSmokingDBContext _context;
        private readonly IServiceProviders _context;

        public UserNotificationThinhThpsController(IServiceProviders context)
        {
            _context = context;
        }

        // GET: UserNotificationThinhThps
        public async Task<IActionResult> Index1()
        {
            //var sE18_PRN222_SE1809_G6_QuitSmokingDBContext = _context.UserNotificationThinhThps.Include(u => u.NotificationThinhThp).Include(u => u.UserAccount);
            //return View(await sE18_PRN222_SE1809_G6_QuitSmokingDBContext.ToListAsync());

            var items = await _context.UserNotificationThinhThpService.GetAllAsync();
            return View(items);
        }

        // GET: UserNotificationThinhThps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var userNotificationThinhThp = await _context.UserNotificationThinhThps
            //    .Include(u => u.NotificationThinhThp)
            //    .Include(u => u.UserAccount)
            //    .FirstOrDefaultAsync(m => m.UserNotificationThinhThpid == id);

            var userNotificationThinhThp = await _context.UserNotificationThinhThpService.GetByIdAsync(id.Value);
            if (userNotificationThinhThp == null)
            {
                return NotFound();
            }

            return View(userNotificationThinhThp);
        }

        // GET: UserNotificationThinhThps/Create
        public async Task<IActionResult> Create()
        {
            var bang1 = await _context.NotificationThinhThpService.GetAllAsync();
            var bang2 = await _context.SystemUserAccountService.GetAllAsync();
            ViewData["NotificationThinhThpid"] = new SelectList(bang1, "NotificationThinhThpid", "Message");
            ViewData["UserAccountId"] = new SelectList(bang2, "UserAccountId", "Email");
            return View();
        }

        // POST: UserNotificationThinhThps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserNotificationThinhThpid,UserAccountId,NotificationThinhThpid,SentDate,IsRead,Response,Status,AttemptCount,LastAttemptDate")] UserNotificationThinhThp userNotificationThinhThp)
        {
            var bang1 = await _context.NotificationThinhThpService.GetAllAsync();
            var bang2 = await _context.SystemUserAccountService.GetAllAsync();
            if (ModelState.IsValid)
            {
                await _context.UserNotificationThinhThpService.CreateAsync(userNotificationThinhThp);
                return RedirectToAction(nameof(Index));
            }
            ViewData["NotificationThinhThpid"] = new SelectList(bang1, "NotificationThinhThpid", "Message", userNotificationThinhThp.NotificationThinhThpid);
            ViewData["UserAccountId"] = new SelectList(bang2, "UserAccountId", "Email", userNotificationThinhThp.UserAccountId);
            return View(userNotificationThinhThp);
        }

        // GET: UserNotificationThinhThps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var bang1 = await _context.NotificationThinhThpService.GetAllAsync();
            var bang2 = await _context.SystemUserAccountService.GetAllAsync();
            if (id == null)
            {
                return NotFound();
            }

            var userNotificationThinhThp = await _context.UserNotificationThinhThpService.GetByIdAsync(id.Value);
            if (userNotificationThinhThp == null)
            {
                return NotFound();
            }
            ViewData["NotificationThinhThpid"] = new SelectList(bang1, "NotificationThinhThpid", "Message", userNotificationThinhThp.NotificationThinhThpid);
            ViewData["UserAccountId"] = new SelectList(bang2, "UserAccountId", "Email", userNotificationThinhThp.UserAccountId);
            return View(userNotificationThinhThp);
        }

        // POST: UserNotificationThinhThps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserNotificationThinhThpid,UserAccountId,NotificationThinhThpid,SentDate,IsRead,Response,Status,AttemptCount,LastAttemptDate")] UserNotificationThinhThp userNotificationThinhThp)
        {
            var bang1 = await _context.NotificationThinhThpService.GetAllAsync();
            var bang2 = await _context.SystemUserAccountService.GetAllAsync();
            if (id != userNotificationThinhThp.UserNotificationThinhThpid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UserNotificationThinhThpService.UpdateAsync(userNotificationThinhThp);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await UserNotificationThinhThpExists(userNotificationThinhThp.UserNotificationThinhThpid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["NotificationThinhThpid"] = new SelectList(bang1, "NotificationThinhThpid", "Message", userNotificationThinhThp.NotificationThinhThpid);
            ViewData["UserAccountId"] = new SelectList(bang2, "UserAccountId", "Email", userNotificationThinhThp.UserAccountId);
            return View(userNotificationThinhThp);
        }

        // GET: UserNotificationThinhThps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var userNotificationThinhThp = await _context.UserNotificationThinhThps
            //    .Include(u => u.NotificationThinhThp)
            //    .Include(u => u.UserAccount)
            //    .FirstOrDefaultAsync(m => m.UserNotificationThinhThpid == id);
            var userNotificationThinhThp = await _context.UserNotificationThinhThpService.GetByIdAsync(id.Value);
            if (userNotificationThinhThp == null)
            {
                return NotFound();
            }

            return View(userNotificationThinhThp);
        }

        // POST: UserNotificationThinhThps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var userNotificationThinhThp = await _context.UserNotificationThinhThps.FindAsync(id);
            var userNotificationThinhThp = await _context.UserNotificationThinhThpService.GetByIdAsync(id);
            if (userNotificationThinhThp != null)
            {
                //_context.UserNotificationThinhThps.Remove(userNotificationThinhThp);
                await _context.UserNotificationThinhThpService.DeleteAsync(id);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> UserNotificationThinhThpExists(int id)
        {
            var entity = await _context.UserNotificationThinhThpService.GetByIdAsync(id);
            return entity != null;
        }




        public async Task<IActionResult> Index(string message, string response, string userName, int? pageNumber, int? pageSize)
        {
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 3; // Default to 10 items per page

            var result = await _context.UserNotificationThinhThpService.SearchAsync(message, response, userName, currentPage, currentPageSize);

            var viewModel = new UserNotificationThinhThpIndexViewModel
            {
                Items = result.items,
                TotalCount = result.totalCount,
                CurrentPage = currentPage,
                PageSize = currentPageSize,
                Message = message,
                Response = response,
                UserName = userName
            };

            return View(viewModel);
        }
    }
}
