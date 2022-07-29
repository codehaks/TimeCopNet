using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.NetworkInformation;
using TimeCop.Identity;
using TimeCop.Identity.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace TimeCop.Web.Areas.Admin.Pages.Users;

public class Input
{
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
}
public class CreateModel : PageModel
{
    private readonly IUserService _userService;
    private readonly ILogger<CreateModel> _logger;

    public CreateModel(IUserService userService, ILogger<CreateModel> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [BindProperty]
    public Input Input { get; set; }
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid == false)
        {
            RedirectToPage();
        }

        var suceeded = await _userService.CreateUser(Input.UserName, Input.Email);

        if (suceeded)
        {

            return RedirectToPage("./index");
        }

        _logger.LogInformation("User added");
        return RedirectToPage("./index");
    }



}
