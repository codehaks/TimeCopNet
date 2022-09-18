using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCop.TimeSheet.Domain;

namespace TimeCop.TimeSheet.Models;

public class Holiday
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Note { get; set; }

    public bool CanOvertime { get; set; }
    public TimeLength OverTimeLimit { get; set; }
    public int OverTimeRate { get; set; }
}
