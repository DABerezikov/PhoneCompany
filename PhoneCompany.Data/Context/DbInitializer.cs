using System.Data.SQLite;
using Dapper;

namespace PhoneCompany.Data.Context
{
    public class DbInitializer(string? connectionString) :IDisposable
    {
        public SQLiteConnection? Connection { get; private set; }

        public void Initialize()
        {
            Connection = new SQLiteConnection(connectionString);
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

            Connection?.Execute(sqlCreateTables);
        }

        private void UpdateTables()
        {
            const string sqlUpdateTables = @"
                                            INSERT INTO Streets (Name)
                                            VALUES  ('Тверская улица'),
                                                    ('Арбат'),
                                                    ('Ленинградский проспект'),
                                                    ('Варшавское шоссе'),
                                                    ('Ленинский проспект'),
                                                    ('Пресненская набережная'),
                                                    ('Кутузовский проспект'),
                                                    ('Каширское шоссе'),
                                                    ('Рублевское шоссе'),
                                                    ('Профсоюзная улица');
                                            
                                            INSERT INTO Addresses (StreetId, NumberHouse)
                                            VALUES  (1, '12'),
                                                    (2, '34'),
                                                    (3, '56'),
                                                    (4, '78'),
                                                    (5, '90'),
                                                    (6, '123'),
                                                    (7, '45'),
                                                    (8, '67'),
                                                    (9, '89'),
                                                    (10, '10б');
                                            
                                            INSERT INTO PhoneNumbers (HomePhone, WorkPhone, MobilPhone)
                                            VALUES  ('495-123-45-67', '495-234-56-78', '916-123-45-67'),
                                                    ('495-345-67-89', '495-456-78-90', '916-234-56-78'),
                                                    ('495-567-89-01', '495-678-90-12', '916-345-67-89'),
                                                    ('495-789-01-23', '495-890-12-34', '916-456-78-90'),
                                                    ('495-901-23-45', '495-012-34-56', '916-567-89-01'),
                                                    ('495-123-45-67', '495-234-56-78', '916-678-90-12'),
                                                    ('495-345-67-89', '495-456-78-90', '916-789-01-23'),
                                                    ('495-567-89-01', '495-678-90-12', '916-890-12-34'),
                                                    ('495-789-01-23', '495-890-12-34', '916-901-23-45'),
                                                    ('495-901-23-45', '495-012-34-56', '916-012-34-56'),
                                                    ('495-101-23-45', '495-202-34-56', '916-303-45-67'),
                                                    ('495-404-56-78', '495-202-34-56', '916-505-67-89'),
                                                    ('495-606-78-90', '495-202-34-56', '916-707-89-01'),
                                                    ('495-808-90-12', '495-909-01-23', '916-010-12-34'),
                                                    ('495-111-23-45', '495-212-34-56', '916-313-45-67'),
                                                    ('495-414-56-78', '495-515-67-89', '916-616-78-90'),
                                                    ('495-717-89-01', '495-818-90-12', '916-919-01-23'),
                                                    ('495-020-12-34', '495-121-23-45', '916-222-34-56'),
                                                    ('495-323-45-67', '495-424-56-78', '916-525-67-89'),
                                                    ('495-626-78-90', '495-727-89-01', '916-828-90-12');
                                            
                                            INSERT INTO Abonents (AddressId, PhoneNumberId, Name, LastName, Patronymic)
                                            VALUES  (1, 1, 'Алексей', 'Смирнов', 'Владимирович'),
                                                    (2, 2, 'Михаил', 'Иванов', 'Петрович'),
                                                    (3, 3, 'Елена', 'Петрова', 'Александровна'),
                                                    (4, 4, 'Ольга', 'Сидорова', 'Николаевна'),
                                                    (5, 5, 'Дмитрий', 'Кузнецов', 'Олегович'),
                                                    (6, 6, 'Ирина', 'Попова', NULL),
                                                    (7, 7, 'Сергей', 'Васильев', 'Андреевич'),
                                                    (8, 8, 'Анна', 'Соколова', 'Ивановна'),
                                                    (9, 9, 'Николай', 'Лебедев', 'Сергеевич'),
                                                    (10, 10, 'Татьяна', 'Козлова', 'Васильевна'),
                                                    (1, 11, 'Анатолий', 'Жуков', 'Михайлович'),
                                                    (2, 12, 'Виктор', 'Федоров', 'Алексеевич'),
                                                    (3, 13, 'Марина', 'Морозова', 'Владимировна'),
                                                    (4, 14, 'Надежда', 'Волкова', 'Сергеевна'),
                                                    (5, 15, 'Георгий', 'Алексеев', NULL),
                                                    (6, 16, 'Людмила', 'Лебедева', 'Анатольевна'),
                                                    (6, 17, 'Олег', 'Горбунов', 'Владимирович'),
                                                    (7, 18, 'Екатерина', 'Киселева', 'Максимовна'),
                                                    (6, 19, 'Александр', 'Макаров', 'Игоревич'),
                                                    (7, 20, 'Дарья', 'Андреева', 'Константиновна');
                                            ";
            Connection?.Execute(sqlUpdateTables);
        }


        public void Dispose()
        {
            Connection?.Close();
        }
    }
}
