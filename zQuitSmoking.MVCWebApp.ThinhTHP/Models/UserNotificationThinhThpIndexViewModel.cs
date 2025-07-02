using zQuitSmoking.Repositories.ThinhTHP.Models;

namespace zQuitSmoking.MVCWebApp.ThinhTHP.Models
{
    public class UserNotificationThinhThpIndexViewModel
    {
        public List<UserNotificationThinhThp> Items { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public string Message { get; set; }
        public string Response { get; set; }
        public string UserName { get; set; }
    }
}
