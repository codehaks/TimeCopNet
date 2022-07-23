using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCop.TimeSheet.Models;

public class Job
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }

    public string Note { get; set; }

    public DateTime TimeStart { get; set; }
    public DateTime? TimeEnd { get; set; }

}
