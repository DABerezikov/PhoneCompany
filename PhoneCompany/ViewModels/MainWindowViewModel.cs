using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using PhoneCompany.Business.Models;
using PhoneCompany.Common.Interfaces;
using PhoneCompany.Data.Entities;
using PhoneCompany.UI.Commands;
using PhoneCompany.UI.ViewModels.Base;

namespace PhoneCompany.UI.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private IUserDialog _userDialog;
        private readonly IAbonentService _abonents;
        private readonly CollectionViewSource _abonentsView;
        
        public ICollectionView FilteredView => _abonentsView.View;


        public MainWindowViewModel(IAbonentService abonents,
            IUserDialog dialog)
        {
            _abonents = abonents;
            _userDialog = dialog;
            _abonentsView = new CollectionViewSource();
            _abonentsView.Filter += Filtering;

        }



        #region Свойства
        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "PhoneCompany";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        #region Abonents : ObservableCollection<Abonent> - Коллекция абонентов

        /// <summary>Коллекция абонентов</summary>
        private ObservableCollection<AbonentFromViewModel> _Abonents;

        /// <summary>Коллекция абонентов</summary>
        public ObservableCollection<AbonentFromViewModel> Abonents { get => _Abonents; set => Set(ref _Abonents, value); }

        #endregion

        #region Filter : string - Строка фильтрации

        /// <summary>Строка фильтрации</summary>
        private string _Filter = string.Empty;

        /// <summary>Строка фильтрации</summary>
        public string Filter
        {
            get => _Filter;
            set
            {
                Set(ref _Filter, value);
                FilteredView.Refresh();
            }
        }

        #endregion

        #region IsNameFiltered : bool - Фильтрация по имени

        /// <summary>Фильтрация по имени</summary>
        private bool _IsNameFiltered;

        /// <summary>Фильтрация по имени</summary>
        public bool IsNameFiltered
        {
            get => _IsNameFiltered;
            set
            {
                Set(ref _IsNameFiltered, value);
                FilteredView.Refresh();
            }
        }

        #endregion

        #region IsLastNameFiltered : bool - Фильтрация по фамилии

        /// <summary>Фильтрация по фамилии</summary>
        private bool _IsLastNameFiltered = true;

        /// <summary>Фильтрация по фамилии</summary>
        public bool IsLastNameFiltered
        {
            get => _IsLastNameFiltered;
            set
            {
                Set(ref _IsLastNameFiltered, value);
                FilteredView.Refresh();
            }
        }

        #endregion

        #region IsPatronymicFiltered : bool - Фильтрация по отчеству

        /// <summary>Фильтрация по отчеству</summary>
        private bool _IsPatronymicFiltered;

        /// <summary>Фильтрация по отчеству</summary>
        public bool IsPatronymicFiltered
        {
            get => _IsPatronymicFiltered;
            set
            {
                Set(ref _IsPatronymicFiltered, value);
                FilteredView.Refresh();
            }
        }

        #endregion

        #region IsStreetFiltered : bool - Фильтрация по улице

        /// <summary>Фильтрация по улице</summary>
        private bool _IsStreetFiltered;

        /// <summary>Фильтрация по улице</summary>
        public bool IsStreetFiltered
        {
            get => _IsStreetFiltered;
            set
            {
                Set(ref _IsStreetFiltered, value);
                FilteredView.Refresh();
            }
        }

        #endregion

        #region IsNumberHouseFiltered : bool - Фильтрация по номеру дома

        /// <summary>Фильтрация по номеру дома</summary>
        private bool _IsNumberHouseFiltered;

        /// <summary>Фильтрация по номеру дома</summary>
        public bool IsNumberHouseFiltered
        {
            get => _IsNumberHouseFiltered;
            set
            {
                Set(ref _IsNumberHouseFiltered, value);
                FilteredView.Refresh();
            }
        }

        #endregion

        #region IsHomePhoneFiltered : bool - Фильтрация по домашнему телефону

        /// <summary>Фильтрация по домашнему телефону</summary>
        private bool _IsHomePhoneFiltered;

        /// <summary>Фильтрация по домашнему телефону</summary>
        public bool IsHomePhoneFiltered
        {
            get => _IsHomePhoneFiltered;
            set
            {
                Set(ref _IsHomePhoneFiltered, value);
                FilteredView.Refresh();
            }
        }

        #endregion

        #region IsWorkPhoneFiltered : bool - Фильтрация по рабочему телефону

        /// <summary>Фильтрация по рабочему телефону</summary>
        private bool _IsWorkPhoneFiltered;

        /// <summary>Фильтрация по рабочему телефону</summary>
        public bool IsWorkPhoneFiltered
        {
            get => _IsWorkPhoneFiltered;
            set
            {
                Set(ref _IsWorkPhoneFiltered, value);
                FilteredView.Refresh();
            }
        }

        #endregion

        #region IsMobilPhoneFiltered : bool - Фильтрация по мобильному телефону

        /// <summary>Фильтрация по мобильному телефону</summary>
        private bool _IsMobilPhoneFiltered;

        /// <summary>Фильтрация по мобильному телефону</summary>
        public bool IsMobilPhoneFiltered
        {
            get => _IsMobilPhoneFiltered;
            set
            {
                Set(ref _IsMobilPhoneFiltered, value);
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
        #endregion

        #region Команды

        #region Command LoadDataCommand - Команда для загрузки данных из репозитория

        /// <summary> Команда для загрузки данных из репозитория </summary>
        private ICommand _LoadDataCommand;




        /// <summary> Команда для загрузки данных из репозитория </summary>
        public ICommand LoadDataCommand => _LoadDataCommand
            ??= new LambdaCommand(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        /// <summary> Проверка возможности выполнения - Команда для загрузки данных из репозитория </summary>
        private bool CanLoadDataCommandExecute() => true;

        /// <summary> Логика выполнения - Команда для загрузки данных из репозитория </summary>
        private void OnLoadDataCommandExecuted()
        {
            var collection = _abonents.Abonents.Select(CreateAbonentFromViewModel);

            Abonents = new ObservableCollection<AbonentFromViewModel>(collection);
            _abonentsView.Source = Abonents;
            OnPropertyChanged(nameof(FilteredView));
           
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
        #endregion
        #endregion
    }
}
