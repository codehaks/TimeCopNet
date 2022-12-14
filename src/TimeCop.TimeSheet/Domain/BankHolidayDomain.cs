using Ardalis.GuardClauses;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace TimeCop.TimeSheet.Domain;

public class BankHolidayDomain
{
    public bool IsValid()
    {
        return BrokenRules().Count() > 0;
    }

    public IEnumerable<string> BrokenRules()
    {
        if (string.IsNullOrEmpty(Name))   
            yield return "Name can not be null or empty";
  

        if (Date <= LocalDate.FromDateTime(DateTime.Now))  
            yield return "Date can not be in the past";
     
    }
    
    public LocalDate Date { get; set; }
    public string Name { get; set; }
}
