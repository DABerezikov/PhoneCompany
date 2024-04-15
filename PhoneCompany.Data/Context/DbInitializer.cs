using System.Data.SQLite;
using Dapper;

namespace PhoneCompany.Data.Context
{
    public class DbInitializer(string connectionString) :IDisposable
    {
        private readonly string _connectionString = connectionString;

        public SQLiteConnection Connection { get; private set; }

        public void Initialize()
        {
            Connection = new SQLiteConnection(_connectionString);
            Connection.Open();

            CreateTables();
            UpdateTables();
        }

        private void CreateTables()
        {
            const string sqlCreateTables = @"
                                            CREATE TABLE Streets (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Name TEXT NOT NULL);

                                            CREATE TABLE Addresses (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            StreetId INTEGER NOT NULL,
                                            NumberHouse TEXT NOT NULL,
                                            FOREIGN KEY (StreetId) REFERENCES Streets(Id));
                                            
                                            CREATE TABLE PhoneNumbers (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            HomePhone TEXT,
                                            WorkPhone TEXT,
                                            MobilPhone TEXT);

                                            CREATE TABLE Abonents (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            AddressId INTEGER NOT NULL,
                                            PhoneNumberId INTEGER NOT NULL,
                                            Name TEXT NOT NULL,
                                            LastName TEXT NOT NULL,
                                            Patronymic TEXT,
                                            FOREIGN KEY (AddressId) REFERENCES Addresses(Id),
                                            FOREIGN KEY (PhoneNumberId) REFERENCES PhoneNumbers(Id));";

            Connection.Execute(sqlCreateTables);
        }

        private void UpdateTables()
        {
            const string sqlUpdateTables = @"
                                            INSERT INTO Streets (Name)
                                            VALUES  ('Street1'),
                                                    ('Street2'),
                                                    ('Street3')
                                            ;

                                            INSERT INTO Addresses (StreetId, NumberHouse)
                                            VALUES  (1, '555'),
                                                    (2, '666'),
                                                    (3, '777'),
                                                    (1, '111'),
                                                    (1, '2222a'),
                                                    (3, '444')
                                            ;
                                            
                                            INSERT INTO PhoneNumbers (HomePhone, WorkPhone, MobilPhone)
                                            VALUES  ('123-123', '234-234', '8-223-345-56-44'),
                                                    ('123-312', '234-546', '8-345-357-56-90'),
                                                    ('123-312', '234-546', '8-345-234-56-56'),
                                                    ('123-882', '567-546', '8-345-890-67-90'),
                                                    ('456-312', '234-567', '8-345-688-56-89'),
                                                    ('163-312', '678-546', '8-456-357-56-90')
                                            ;

                                            INSERT INTO Abonents (AddressId, PhoneNumberId, Name, LastName, Patronymic)
                                            VALUES  (1, 1, 'Иван', 'Иванов', 'Иванович'),
                                                    (2, 2, 'Петр', 'Петров', 'Петрович'),
                                                    (3, 3, 'Ганс-Христиан', 'Андерсон', NULL),
                                                    (4, 4, 'Семен', 'Семенов', 'Иванович'),
                                                    (5, 5, 'Карл', 'Попов', 'Сергеевич'),
                                                    (6, 6, 'Степан', 'Круглов', 'Альбертович')
                                            ;";
            Connection.Execute(sqlUpdateTables);

        }


        public void Dispose()
        {
            Connection.Close();
        }
    }
}
