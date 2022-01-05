using ShowcaseApplication.Controls;

namespace SalesApp.ViewModels
{
    public class DialogViewModelArgs : ModalDialogArgs
    {
        public int UserId { get; }
        
        public DialogViewModelArgs(int userId)
        {
            this.UserId = userId;   
        }
    }
}
