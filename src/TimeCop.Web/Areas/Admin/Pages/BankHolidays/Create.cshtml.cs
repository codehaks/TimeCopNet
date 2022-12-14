using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NodaTime;
using NodaTime.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using TimeCop.TimeSheet.Services;
using TimeCop.Web.Extensions;

namespace TimeCop.Web.Areas.Admin.Pages.BankHolidays;

public class BankHolidayInput
{
    public string Name { get; set; }
    public DateOnly Date { get; set; }
}

public class BankHolidayValidator : AbstractValidator<BankHolidayInput>
{
    public BankHolidayValidator()
    {
        RuleFor(b => b.Name).NotEmpty().WithMessage("Can not be empty!")
            .MaximumLength(50).WithMessage("Too long!");
        RuleFor(b => b.Name).MinimumLength(5).WithMessage("Too Short!");

        RuleFor(b => b.Date).NotEmpty().NotNull().WithMessage("Select a date!")
            .GreaterThan(DateOnly.FromDateTime(DateTime.Now.AddDays(1)))
            .WithMessage("Can not be in the past!");
    }
}

public class CreateModel : PageModel
{
    private IValidator<BankHolidayInput> _validator;

    private readonly IBankHolidayService _bankHolidayService;

    public CreateModel(IBankHolidayService bankHolidayService, IValidator<BankHolidayInput> validator)
    {
        _bankHolidayService = bankHolidayService;
        _validator = validator;
    }

    [BindProperty]
    public BankHolidayInput Input { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        // Input Validation

        //var validationResult =_validator.Validate(Input);

        //if (validationResult.IsValid == false)
        //{
        //    validationResult.AddErrorsToModelState(this.ModelState);
        //    return Page();
        //}

        // Run inside operation
        await _bankHolidayService.Create(Input.Date.ToLocalDate(),Input.Name);

        return RedirectToPage("./Index");
    }
}
