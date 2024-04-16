using System.Collections.ObjectModel;
using System.Windows.Input;
using PhoneCompany.Business.Models;
using PhoneCompany.Common.Interfaces;
using PhoneCompany.Data.Entities;
using PhoneCompany.UI.Commands;
using PhoneCompany.UI.ViewModels.Base;

namespace PhoneCompany.UI.ViewModels
{
    internal class MainWindowViewModel(
        IAbonentService abonents,
        IUserDialog dialog)
        : ViewModel
    {
        private IAbonentService _abonents = abonents;
        private IUserDialog _userDialog = dialog;
        
        
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
