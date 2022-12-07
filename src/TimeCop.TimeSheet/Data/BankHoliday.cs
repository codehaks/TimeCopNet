using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCop.TimeSheet.Data;

public class BankHoliday
{
    public int Id { get; set; }
    public LocalDate Date { get; set; }
    public required string Name { get; set; }
}
