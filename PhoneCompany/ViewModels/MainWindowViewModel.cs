using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;
using PhoneCompany.Business.Models;
using PhoneCompany.Common.Interfaces;
using PhoneCompany.Data.Entities;
using PhoneCompany.UI.Commands;
using PhoneCompany.UI.ViewModels.Base;
using PhoneCompany.UI.Views;

namespace PhoneCompany.UI.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
       
        private readonly IAbonentService _abonentService;
        private readonly CollectionViewSource _abonentsView;
        
        public ICollectionView FilteredView => _abonentsView.View;


        public MainWindowViewModel(IAbonentService abonents
           )
        {
            _abonentService = abonents;
            
            _abonentsView = new CollectionViewSource();
            _abonentsView.Filter += Filtering;

        }



        #region Свойства
        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _title = "PhoneCompany";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _title; set => Set(ref _title, value); }

        #endregion

        #region Abonents : ObservableCollection<Abonent> - Коллекция абонентов

        /// <summary>Коллекция абонентов</summary>
        private ObservableCollection<AbonentFromViewModel>? _abonents;

        /// <summary>Коллекция абонентов</summary>
        public ObservableCollection<AbonentFromViewModel>? Abonents { get => _abonents; set => Set(ref _abonents, value); }

        #endregion

        #region Filter : string - Строка фильтрации

        /// <summary>Строка фильтрации</summary>
        private string _filter = string.Empty;

        /// <summary>Строка фильтрации</summary>
        public string Filter
        {
            get => _filter;
            set
            {
                Set(ref _filter, value);
                FilteredView.Refresh();
            }
        }

        #endregion

        #region IsNameFiltered : bool - Фильтрация по имени

        /// <summary>Фильтрация по имени</summary>
        private bool _isNameFiltered;

        /// <summary>Фильтрация по имени</summary>
        public bool IsNameFiltered
        {
            get => _isNameFiltered;
            set
            {
                Set(ref _isNameFiltered, value);
                FilteredView.Refresh();
            }
        }

        #endregion

        #region IsLastNameFiltered : bool - Фильтрация по фамилии

        /// <summary>Фильтрация по фамилии</summary>
        private bool _isLastNameFiltered = true;

        /// <summary>Фильтрация по фамилии</summary>
        public bool IsLastNameFiltered
        {
            get => _isLastNameFiltered;
            set
            {
                Set(ref _isLastNameFiltered, value);
                FilteredView.Refresh();
            }
        }

        #endregion

        #region IsPatronymicFiltered : bool - Фильтрация по отчеству

        /// <summary>Фильтрация по отчеству</summary>
        private bool _isPatronymicFiltered;

        /// <summary>Фильтрация по отчеству</summary>
        public bool IsPatronymicFiltered
        {
            get => _isPatronymicFiltered;
            set
            {
                Set(ref _isPatronymicFiltered, value);
                FilteredView.Refresh();
            }
        }

        #endregion

        #region IsStreetFiltered : bool - Фильтрация по улице

        /// <summary>Фильтрация по улице</summary>
        private bool _isStreetFiltered;

        /// <summary>Фильтрация по улице</summary>
        public bool IsStreetFiltered
        {
            get => _isStreetFiltered;
            set
            {
                Set(ref _isStreetFiltered, value);
                FilteredView.Refresh();
            }
        }

        #endregion

        #region IsNumberHouseFiltered : bool - Фильтрация по номеру дома

        /// <summary>Фильтрация по номеру дома</summary>
        private bool _isNumberHouseFiltered;

        /// <summary>Фильтрация по номеру дома</summary>
        public bool IsNumberHouseFiltered
        {
            get => _isNumberHouseFiltered;
            set
            {
                Set(ref _isNumberHouseFiltered, value);
                FilteredView.Refresh();
            }
        }

        #endregion

        #region IsHomePhoneFiltered : bool - Фильтрация по домашнему телефону

        /// <summary>Фильтрация по домашнему телефону</summary>
        private bool _isHomePhoneFiltered;

        /// <summary>Фильтрация по домашнему телефону</summary>
        public bool IsHomePhoneFiltered
        {
            get => _isHomePhoneFiltered;
            set
            {
                Set(ref _isHomePhoneFiltered, value);
                FilteredView.Refresh();
            }
        }

        #endregion

        #region IsWorkPhoneFiltered : bool - Фильтрация по рабочему телефону

        /// <summary>Фильтрация по рабочему телефону</summary>
        private bool _isWorkPhoneFiltered;

        /// <summary>Фильтрация по рабочему телефону</summary>
        public bool IsWorkPhoneFiltered
        {
            get => _isWorkPhoneFiltered;
            set
            {
                Set(ref _isWorkPhoneFiltered, value);
                FilteredView.Refresh();
            }
        }

        #endregion

        #region IsMobilPhoneFiltered : bool - Фильтрация по мобильному телефону

        /// <summary>Фильтрация по мобильному телефону</summary>
        private bool _isMobilPhoneFiltered;

        /// <summary>Фильтрация по мобильному телефону</summary>
        public bool IsMobilPhoneFiltered
        {
            get => _isMobilPhoneFiltered;
            set
            {
                Set(ref _isMobilPhoneFiltered, value);
                FilteredView.Refresh();
            }
        }

        #endregion 
        #endregion

        #region Методы

        private void Filtering(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Filter)) return;
            if (e.Item is not AbonentFromViewModel filteredItem) return;

            if (IsNameFiltered && !filteredItem.Name.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                e.Accepted = false;

            if (IsLastNameFiltered && !filteredItem.LastName.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                e.Accepted = false;

            if (string.IsNullOrWhiteSpace(filteredItem.Patronymic)) e.Accepted = false;
            else if (IsPatronymicFiltered && !filteredItem.Patronymic.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    e.Accepted = false;

            if (IsStreetFiltered && !filteredItem.Street.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                e.Accepted = false;

            if (IsNumberHouseFiltered && !filteredItem.NumberHouse.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                e.Accepted = false;

            if (IsHomePhoneFiltered && !filteredItem.HomePhone.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                e.Accepted = false;

            if (IsWorkPhoneFiltered && !filteredItem.WorkPhone.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                e.Accepted = false;

            if (IsMobilPhoneFiltered && !filteredItem.MobilPhone.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                e.Accepted = false;


        }

        private AbonentFromViewModel CreateAbonentFromViewModel(Abonent abonent)
        {
            return new AbonentFromViewModel()
            {
                Id = abonent.Id,
                Name = abonent.Name,
                LastName = abonent.LastName,
                Patronymic = abonent.Patronymic,
                Street = abonent.Address.Street.Name,
                NumberHouse = abonent.Address.NumberHouse,
                HomePhone = abonent.PhoneNumbers.HomePhone,
                MobilPhone = abonent.PhoneNumbers.MobilPhone,
                WorkPhone = abonent.PhoneNumbers.WorkPhone
            };
        }

        private void CsvFileSave(ICollection<AbonentFromViewModel> abonents, string filePath)
        {
            var csv = new StringBuilder();
            
            csv.AppendLine("Id,Name,LastName,Patronymic,Street,NumberHouse,HomePhone,WorkPhone,MobilPhone");

            foreach (var abonent in abonents)
            {
                var newLine = string.Format(
                    "{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                    abonent.Id,
                    abonent.Name,
                    abonent.LastName,
                    abonent.Patronymic,
                    abonent.Street,
                    abonent.NumberHouse,
                    abonent.HomePhone,
                    abonent.WorkPhone,
                    abonent.MobilPhone
                );
                csv.AppendLine(newLine);

                File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);
            }
        }

        #endregion

        #region Команды

        #region Command FindAbonentCommand - Команда для загрузки данных из репозитория

        /// <summary> Команда для загрузки данных из репозитория </summary>
        private ICommand? _loadDataCommand;

        /// <summary> Команда для загрузки данных из репозитория </summary>
        public ICommand LoadDataCommand => _loadDataCommand
            ??= new LambdaCommand(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        /// <summary> Проверка возможности выполнения - Команда для загрузки данных из репозитория </summary>
        private bool CanLoadDataCommandExecute() => true;

        /// <summary> Логика выполнения - Команда для загрузки данных из репозитория </summary>
        private void OnLoadDataCommandExecuted()
        {
            var collection = _abonentService.Abonents.Select(CreateAbonentFromViewModel);

            Abonents = new ObservableCollection<AbonentFromViewModel>(collection);
            _abonentsView.Source = Abonents;
            OnPropertyChanged(nameof(FilteredView));
           
        }
        #endregion

        #region Command FindAbonentCommand - Команда для поиска абонентов

        /// <summary> Команда для поиска абонентов </summary>
        private ICommand? _findAbonentCommand;

        /// <summary> Команда для поиска абонентов </summary>
        public ICommand FindAbonentCommand => _findAbonentCommand
            ??= new LambdaCommand(OnFindAbonentCommandExecuted, CanFindAbonentCommandExecute);

        /// <summary> Проверка возможности выполнения - Команда для поиска абонентов </summary>
        private bool CanFindAbonentCommandExecute() => true;

        /// <summary> Логика выполнения - Команда для поиска абонентов </summary>
        private void OnFindAbonentCommandExecuted()
        {

            var window = new FindWindow
            {
                DataContext = new FindWindowViewModel(Abonents!)
            };
            window.ShowDialog();

        }
        #endregion

        #region Command StreetReportCommand - Команда для списка улиц

        /// <summary> Команда для списка улиц </summary>
        private ICommand? _streetReportCommand;

        /// <summary> Команда для поиска аббонентов </summary>
        public ICommand StreetReportCommand => _streetReportCommand
            ??= new LambdaCommand(OnStreetReportCommandExecuted, CanStreetReportCommandExecute);

        /// <summary> Проверка возможности выполнения - Команда для списка улиц </summary>
        private bool CanStreetReportCommandExecute() => true;

        /// <summary> Логика выполнения - Команда для списка улиц </summary>
        private void OnStreetReportCommandExecuted()
        {

            var window = new StreetWindow
            {
                DataContext = new StreetWindowsViewModel(Abonents)
            };
            window.ShowDialog();

        }
        #endregion

        #region Command CreateReportCommand - Команда для списка улиц

        /// <summary> Команда для списка улиц </summary>
        private ICommand? _createReportCommand;

        /// <summary> Команда для поиска аббонентов </summary>
        public ICommand CreateReportCommand => _createReportCommand
            ??= new LambdaCommand(OnCreateReportCommandExecuted, CanCreateReportCommandExecute);

        /// <summary> Проверка возможности выполнения - Команда для списка улиц </summary>
        private bool CanCreateReportCommandExecute() => true;

        /// <summary> Логика выполнения - Команда для списка улиц </summary>
        private void OnCreateReportCommandExecuted()
        {

            var collection = FilteredView.OfType<AbonentFromViewModel>().ToList();
            var filePath = $"report_{DateTime.Now.ToShortDateString()}_{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}.csv";
            CsvFileSave(collection, filePath);
            MessageBox.Show($"Отчет {filePath} успешно сформирован"  , "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion


        #endregion
    }
}
