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

        private void Filtering(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Filter)) return;
            if (e.Item is not AbonentFromViewModel filteredItem) return;

            if (!filteredItem.Name.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                e.Accepted = false;
            
            if (!filteredItem.LastName.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                e.Accepted = false;
            
            if (string.IsNullOrWhiteSpace(filteredItem.Patronymic) || !filteredItem.Patronymic.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                e.Accepted = false;
            
            if (!filteredItem.Street.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                e.Accepted = false;
            
            if (!filteredItem.NumberHouse.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                e.Accepted = false;
            
            if (!filteredItem.HomePhone.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                e.Accepted = false;
            
            if (!filteredItem.WorkPhone.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                e.Accepted = false;
            
            if (!filteredItem.MobilPhone.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                e.Accepted = false;
            

        }

        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "PhoneCompany";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        #region Abonents : ObservableCollection<Abonent> - Коллекция абонентов

        /// <summary>Коллекция абонентов</summary>
        private ObservableCollection<AbonentFromViewModel> _Abonents ;

        /// <summary>Коллекция абонентов</summary>
        public ObservableCollection<AbonentFromViewModel> Abonents { get => _Abonents; set => Set(ref _Abonents, value); }

        #endregion

        #region Filter : string - Заголовок окна

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
