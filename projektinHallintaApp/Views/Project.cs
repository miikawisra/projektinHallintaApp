using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projektinHallintaApp.Views;
using SQLite;

namespace projektinHallintaApp.Views
{
    public class Project
    {
        [PrimaryKey, AutoIncrement] // Tietokannan pääavain
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime Deadline { get; set; }
    }
}
