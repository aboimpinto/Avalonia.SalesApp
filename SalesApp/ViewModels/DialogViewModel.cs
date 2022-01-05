using System.Threading.Tasks;
using ShowcaseApplication.Controls;
using ShowcaseApplication.Core;

namespace SalesApp.ViewModels
{
    public class DialogViewModel : ModalDialogViewModalBase<DialogResult>, ILoadable
    {
        private int _userId;

        public void CloseCommand()
        {
            var result = new ModalDialogResult<DialogResult>(new DialogResult(this._userId), 99);

            this.Close(result);
        }

        public Task Load(params object[] parameters)
        {
            this._userId = int.Parse(parameters[0].ToString());

            return Task.CompletedTask;
        }
    }
}
