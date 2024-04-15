using PhoneCompany.Common.Interfaces;


namespace PhoneCompany.Business.Services
{
    public class UserDialog : IUserDialog
    {
       

        public FileInfo? OpenFile(string title,
            string filter =
                "Исходные файлы (*.pdf, *.xls, *.xlsx)|*.pdf; *.xls; *.xlsx| PDF(*.pdf)|*.pdf| Excel(*.xls,*.xlsx)|*.xls;*.xlsx| Все файлы (*.*)|*.*",
            string? defaultFilePath = null)
        {
            throw new NotImplementedException();
        }

        public FileInfo? SaveFile(string title, string filter = "Все файлы (*.*)|*.*", string? defaultFilePath = null)
        {
            throw new NotImplementedException();
        }

        public bool YesNoQuestion(string text, string title = "Вопрос...")
        {
            throw new NotImplementedException();
        }

        public bool OkCancelQuestion(string text, string title = "Вопрос...")
        {
            throw new NotImplementedException();
        }

        public void Information(string text, string title = "Вопрос...")
        {
            throw new NotImplementedException();
        }

        public void Warning(string text, string title = "Вопрос...")
        {
            throw new NotImplementedException();
        }

        public void Error(string text, string title = "Вопрос...")
        {
            throw new NotImplementedException();
        }
    }
}
