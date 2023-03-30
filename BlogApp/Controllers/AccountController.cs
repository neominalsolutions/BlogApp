using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
  public class AccountController : Controller
  {
    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Login(LoginInputModel model)
    {
      // 1. apiya bağlanıp token al
      // 2. token parse et
      // 3. access token store et
      // 4. cookie based auth ile login ol

      return View();
    }
  }
}
