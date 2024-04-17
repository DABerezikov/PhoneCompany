using System.Collections.ObjectModel;
using System.Windows.Input;
using PhoneCompany.Business.Models;
using PhoneCompany.UI.Commands;
using PhoneCompany.UI.ViewModels.Base;

namespace PhoneCompany.UI.ViewModels
{
    internal class FindWindowViewModel (ICollection<AbonentFromViewModel> abonentsRepository) : ViewModel
    {
       
        
        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Поиск по номеру";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        #region Abonents : ObservableCollection<> - Коллекция абонентов

        /// <summary>Коллекция абонентов</summary>
        private ObservableCollection<AbonentFromViewModel> _Abonents = new (abonentsRepository);

        /// <summary>Коллекция абонентов</summary>
        public ObservableCollection<AbonentFromViewModel> Abonents { get => _Abonents; set => Set(ref _Abonents, value); }

        #endregion

        #region FindAbonents : ObservableCollection<> - Коллекция найденных абонентов

        /// <summary>Коллекция найденных абонентов</summary>
        private ObservableCollection<AbonentFromViewModel> _FindAbonents = [];

        /// <summary>Коллекция найденных абонентов</summary>
        public ObservableCollection<AbonentFromViewModel> FindAbonents { get => _FindAbonents; set => Set(ref _FindAbonents, value); }

        #endregion

        #region FindingNumber : string - Коллекция абонентов

        /// <summary>Заголовок окна</summary>
        private string _FindingNumber = "Введите номер";

        /// <summary>Заголовок окна</summary>
        public string FindingNumber { get => _FindingNumber; set => Set(ref _FindingNumber, value); }

        #endregion

        #region Command SearchCommand - Команда для поиска абонентов

        /// <summary> Команда для поиска абонентов </summary>
        private ICommand _SearchCommand;

        /// <summary> Команда для поиска абонентов </summary>
        public ICommand SearchCommand => _SearchCommand
            ??= new LambdaCommand(OnSearchCommandExecuted, CanSearchCommandExecute);

        /// <summary> Проверка возможности выполнения - Команда для поиска абонентов </summary>
        private bool CanSearchCommandExecute() => true;

        /// <summary> Логика выполнения - Команда для поиска абонентов </summary>
        private void OnSearchCommandExecuted()
        {

            var searchCollection = Abonents.Select(m => m)
                .Where(a => a.HomePhone == FindingNumber || a.MobilPhone == FindingNumber || a.WorkPhone == FindingNumber).ToList();
            if (searchCollection.Count == 0)
            {
                MessageBox.Show("Нет абонентов, удовлетворяющих критерию поиска", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            
            FindAbonents = new ObservableCollection<AbonentFromViewModel>(searchCollection);
            OnPropertyChanged(nameof(FindAbonents));
            
        }
        #endregion

    }
}
