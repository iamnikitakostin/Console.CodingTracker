using CodeReviews.Console.CodingTracker.Controllers;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Spectre.Console;

namespace CodeReviews.Console.CodingTracker.Data
{
    public class DbConnection : ConsoleController
    {
        private static SqliteConnection _connection;

        private DbConnection() { }

        public static SqliteConnection GetConnection(bool isStart = false)
        {


            if (_connection == null)
            {
                try
                {
                    var configuration = new ConfigurationBuilder()
                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .Build();

                    string? dbPath = configuration["DatabaseSettings:DatabasePath"];
                    _connection = new SqliteConnection($"Data Source={dbPath}");
                    _connection.Open();
                    SuccessMessage("The database has been connected.");

                    if (isStart)
                    {
                        DbConnection.CreateTable("Sessions");
                        //DbConnection.SeedData();
                    }


                    _connection.Close();
                }
                catch (Exception ex) {
                    ErrorMessage("An error has been received:" + ex.Message);
                }
               
            }
            return _connection;
        }

        public static void CloseConnection()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
                SuccessMessage("The database connection has been closed.");
            }
        }

        public static void CreateTable(string name)
        {
            try
            {
                var command = _connection.CreateCommand();
                if (name == "Sessions")
                {
                    command.CommandText =
                    @"
                        CREATE TABLE IF NOT EXISTS Sessions (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            StartTime TEXT NOT NULL,
                            EndTime TEXT,
                            Duration INTEGER
                        )
                    ";
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                ErrorMessage("Error creating table: " + ex.Message);
            }

        }


        // ADD SEEDING LATER
        //public static void SeedData()
        //{
        //    bool create = false;
        //    using (var command = _connection.CreateCommand())
        //    {
        //        command.CommandText = "SELECT COUNT(*) FROM Habits";
        //        long habitCount = (long)command.ExecuteScalar();

        //        if (habitCount == 0)
        //        {
        //            create = true;
        //            Console.WriteLine("Seeding data into the Habits table.");
        //            var random = new Random();

        //            for (int i = 0; i < 100; i++)
        //            {
        //                string habitName = $"Habit {i + 1}";
        //                Frequency frequency = (Frequency)random.Next(0, 3); 
        //                string frequencyString = frequency.ToString(); 
        //                int timesPerPeriod = random.Next(1, 5);
        //                string startDate = DateTime.Now.AddDays(-random.Next(0, 100)).ToString("yyyy-MM-dd");

        //                command.CommandText =
        //                @"
        //            INSERT INTO Habits (Name, Frequency, TimesPerPeriod, StartDate)
        //            VALUES (@habitName, @frequency, @timesPerPeriod, @startDate)
        //        ";

        //                command.Parameters.Clear();
        //                command.Parameters.AddWithValue("@habitName", habitName);
        //                command.Parameters.AddWithValue("@frequency", frequencyString);
        //                command.Parameters.AddWithValue("@timesPerPeriod", timesPerPeriod);
        //                command.Parameters.AddWithValue("@startDate", startDate);

        //                command.ExecuteNonQuery();
        //            }
        //        }
        //    }

        //    if (create)
        //    {
        //        using (var command = _connection.CreateCommand())
        //        {
        //            command.CommandText = "SELECT Id, Name FROM Habits";
        //            using (var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    int habitId = reader.GetInt32(0);
        //                    string habitName = reader.GetString(1);

        //                    using (var insertCommand = _connection.CreateCommand())
        //                    {
        //                        for (int j = 0; j < 10; j++)
        //                        {
        //                            string habitDate = DateTime.Now.AddDays(-new Random().Next(0, 30)).ToString("yyyy-MM-dd");

        //                            insertCommand.CommandText =
        //                            @"
        //                        INSERT INTO Records (Name, HabitDate, HabitId)
        //                        VALUES (@habitName, @habitDate, @habitId)
        //                    ";

        //                            insertCommand.Parameters.Clear();
        //                            insertCommand.Parameters.AddWithValue("@habitName", habitName);
        //                            insertCommand.Parameters.AddWithValue("@habitDate", habitDate);
        //                            insertCommand.Parameters.AddWithValue("@habitId", habitId);

        //                            insertCommand.ExecuteNonQuery();
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}


    }
}
