using PhoneCompany.Business.Models;
using PhoneCompany.UI.Commands;
using PhoneCompany.UI.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PhoneCompany.UI.ViewModels
{
    internal class StreetWindowsViewModel (ICollection<AbonentFromViewModel> abonents) : ViewModel
    {
        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Улицы";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        #region Streets : ObservableCollection<StreetFromViewModel> - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private ObservableCollection<StreetFromViewModel> _Streets = [];

        /// <summary>Заголовок окна</summary>
        public ObservableCollection<StreetFromViewModel> Streets { get => _Streets; set => Set(ref _Streets, value); }

        #endregion

        #region Command LoadDataCommand - Команда для загрузки данных

        /// <summary> Команда для загрузки данных </summary>
        private ICommand _LoadDataCommand;

        /// <summary> Команда для загрузки данных </summary>
        public ICommand LoadDataCommand => _LoadDataCommand
            ??= new LambdaCommand(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        /// <summary> Проверка возможности выполнения - Команда для загрузки данных </summary>
        private bool CanLoadDataCommandExecute() => true;

        /// <summary> Логика выполнения - Команда для загрузки данных </summary>
        private void OnLoadDataCommandExecuted()
        {

            var collection = abonents
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
