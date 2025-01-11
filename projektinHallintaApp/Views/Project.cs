using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projektinHallintaApp.Views;

namespace projektinHallintaApp.Views
{
    public class Project
    {
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public List<string> DailyGoals { get; set; }
    }
}
