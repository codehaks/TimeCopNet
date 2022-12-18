using Ardalis.GuardClauses;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace TimeCop.TimeSheet.Domain.Models;

public interface IValidator<T>
{
    bool IsValid(T entity);
    IEnumerable<string> BrokenRules(T entity);
}

public class BankHolidayDomainValidator : IValidator<BankHolidayDomain>
{
    public IEnumerable<string> BrokenRules(BankHolidayDomain entity)
    {
        if (string.IsNullOrEmpty(entity.Name))
            yield return "Name can not be null or empty";


        if (entity.Date <= LocalDate.FromDateTime(DateTime.Now))
            yield return "Date can not be in the past";
    }

    public bool IsValid(BankHolidayDomain entity)
    {
        return BrokenRules(entity).Count() > 0;
    }
}

public class BankHolidayDomain
{
    public BankHolidayDomain(LocalDate date, string name)
    {
        Date = date;
        Name = name;
    }

    public LocalDate Date { get; }
    public string Name { get; }
}
