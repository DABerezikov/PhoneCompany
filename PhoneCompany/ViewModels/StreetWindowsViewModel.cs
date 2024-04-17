using PhoneCompany.Business.Models;
using PhoneCompany.UI.Commands;
using PhoneCompany.UI.ViewModels.Base;

namespace PhoneCompany.UI.ViewModels
{
    internal class StreetWindowsViewModel (ICollection<AbonentFromViewModel>? abonents) : ViewModel
    {
        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _title = "Улицы";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _title; set => Set(ref _title, value); }

        #endregion

        #region Streets : ObservableCollection<StreetFromViewModel> - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private ObservableCollection<StreetFromViewModel> _streets = [];

        /// <summary>Заголовок окна</summary>
        public ObservableCollection<StreetFromViewModel> Streets { get => _streets; set => Set(ref _streets, value); }

        #endregion

        #region Command LoadDataCommand - Команда для загрузки данных

        /// <summary> Команда для загрузки данных </summary>
        private ICommand? _loadDataCommand;

        /// <summary> Команда для загрузки данных </summary>
        public ICommand LoadDataCommand => _loadDataCommand
            ??= new LambdaCommand(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        /// <summary> Проверка возможности выполнения - Команда для загрузки данных </summary>
        private bool CanLoadDataCommandExecute() => true;

        /// <summary> Логика выполнения - Команда для загрузки данных </summary>
        private void OnLoadDataCommandExecuted()
        {

            var collection = abonents!
                .GroupBy(a=>a.Street)
                .Select(s=> new StreetFromViewModel()
                {
                    Name = s.Key,
                    Count = s.Count()
                });
            Streets = new ObservableCollection<StreetFromViewModel>(collection);
        }
        #endregion
    }
}
