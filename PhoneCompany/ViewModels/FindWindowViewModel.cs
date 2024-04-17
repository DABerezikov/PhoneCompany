using PhoneCompany.Business.Models;
using PhoneCompany.UI.Commands;
using PhoneCompany.UI.ViewModels.Base;

namespace PhoneCompany.UI.ViewModels
{
    internal class FindWindowViewModel (ICollection<AbonentFromViewModel> abonentsRepository) : ViewModel
    {
       
        
        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _title = "Поиск по номеру";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _title; set => Set(ref _title, value); }

        #endregion

        #region Abonents : ObservableCollection<> - Коллекция абонентов

        /// <summary>Коллекция абонентов</summary>
        private ObservableCollection<AbonentFromViewModel> _abonents = new (abonentsRepository);

        /// <summary>Коллекция абонентов</summary>
        public ObservableCollection<AbonentFromViewModel> Abonents { get => _abonents; set => Set(ref _abonents, value); }

        #endregion

        #region FindAbonents : ObservableCollection<> - Коллекция найденных абонентов

        /// <summary>Коллекция найденных абонентов</summary>
        private ObservableCollection<AbonentFromViewModel> _findAbonents = [];

        /// <summary>Коллекция найденных абонентов</summary>
        public ObservableCollection<AbonentFromViewModel> FindAbonents { get => _findAbonents; set => Set(ref _findAbonents, value); }

        #endregion

        #region FindingNumber : string - Коллекция абонентов

        /// <summary>Заголовок окна</summary>
        private string _findingNumber = "Введите номер";

        /// <summary>Заголовок окна</summary>
        public string FindingNumber { get => _findingNumber; set => Set(ref _findingNumber, value); }

        #endregion

        #region Command SearchCommand - Команда для поиска абонентов

        /// <summary> Команда для поиска абонентов </summary>
        private ICommand? _searchCommand;

        /// <summary> Команда для поиска абонентов </summary>
        public ICommand SearchCommand => _searchCommand
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
