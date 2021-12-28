using ShowcaseApplication.Controls;
using ShowcaseApplication.Controls.OverlayLayerStrategies;

namespace ShowcaseApplication.Core
{
    public class ModalDialogService : IModalDialogService
    {
        private readonly IEnumerable<IOverlayLayerStrategy> _overlayLayerStrategies;
        private ShowcaseApplication.Controls.DialogHost _host;
        private TaskCompletionSource<ModalDialogResult> _tcs;

        public ModalDialogService()
        {
            this._overlayLayerStrategies = new List<IOverlayLayerStrategy>
            {
                new ClassicDesktopStyleStrategy(),
                new SingleViewStyleStrategy(),
            };
        }

        public async Task<ModalDialogResult> Show(ModalDialogViewModalBase viewModel, Action<string> closeCallback)
        {
            this._tcs = new TaskCompletionSource<ModalDialogResult>();

            if (this._host == null)
            {
                this._host = new ShowcaseApplication.Controls.DialogHost();
            }

            var modalDialog = new ModalDialog
            {
                Content = viewModel
            };

            EventHandler<ModalDialogResultArgs> closeEventHandler = null;
            closeEventHandler = (s, e) => 
            {
                modalDialog.Close();
                closeCallback(e.ExitCode.ToString());
                viewModel.Closed -= closeEventHandler;

                this._tcs.TrySetResult(new ModalDialogResult(e.ExitCode));
                this._tcs = null;
                this._host = null;
                modalDialog = null;
            };
            viewModel.Closed += closeEventHandler;

            this._host.Content = modalDialog;

            var overlayLayer = this._overlayLayerStrategies
                .Single(x => x.IsValid())
                .GetOverlayLayer();
            overlayLayer.Children.Add(this._host);

            return await this._tcs.Task;
        }
    }
}
