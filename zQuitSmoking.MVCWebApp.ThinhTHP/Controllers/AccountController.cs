using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zQuitSmoking.Repositories.ThinhTHP;
using zQuitSmoking.Repositories.ThinhTHP.Models;
using zQuitSmoking.Services.ThinhTHP;

public class AccountController : Controller
{
    private readonly SystemUserAccountService _userService;

    public AccountController(SystemUserAccountService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        SystemUserAccount user = await _userService.GetUserAccountAsync(model.Username, model.Password);
        if (user != null)
        {
            Response.Cookies.Append("Username", user.UserName, new CookieOptions { HttpOnly = true });
            Response.Cookies.Append("Role", user.RoleId == 1 ? "Admin" : "User", new CookieOptions { HttpOnly = true });
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Invalid username or password.");
        return View(model);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var existingUser = await _userService.GetUserAccountAsync(model.Username, model.Password);
        if (existingUser != null)
        {
            ModelState.AddModelError("", "Username already exists.");
            return View(model);
        }

        var systemUserAccount = new SystemUserAccount
        {
            UserName = model.Username,
            Email = model.Email,
            Password = PasswordHelper.HashPassword(model.Password),
        };

        await _userService.CreateAsync(systemUserAccount); // Fixed method invocation
        Response.Cookies.Append("Username", systemUserAccount.UserName, new CookieOptions { HttpOnly = true });
        Response.Cookies.Append("Role", "Admin", new CookieOptions { HttpOnly = true });
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
        Response.Cookies.Delete("Username");
        Response.Cookies.Delete("Role");
        return RedirectToAction("Login");
    }
}
