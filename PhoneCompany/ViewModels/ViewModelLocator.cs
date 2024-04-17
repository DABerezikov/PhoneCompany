using Microsoft.Extensions.DependencyInjection;

namespace PhoneCompany.UI.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
        
    }
}
