using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using projektinHallintaApp.Views;

namespace projektinHallintaApp
{
    public class DatabaseService
    {
        private readonly SQLiteConnection _database;

        public DatabaseService()
        {
            // Luo tai avaa tietokantatiedosto
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "projects.db");
            _database = new SQLiteConnection(dbPath);

            // Luo taulun, jos sitä ei ole
            _database.CreateTable<Project>();
        }

        // Hae kaikki projektit
        public List<Project> GetProjects() => _database.Table<Project>().ToList();

        // Lisää tai tallenna projekti
        public void SaveProject(Project project)
        {
            _database.Insert(project);
        }

        // Poista projekti
        public void DeleteProject(Project project)
        {
            _database.Delete(project);
        }
    }
}
