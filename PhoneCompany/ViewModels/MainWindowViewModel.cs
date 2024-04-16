using PhoneCompany.Common.Interfaces;
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
    }
}
