using ShowcaseApplication.Controls;
using ShowcaseApplication.Controls.OverlayLayerStrategies;

namespace ShowcaseApplication.Core
{
    public class ModalDialogService : IModalDialogService
    {
        private readonly IEnumerable<IOverlayLayerStrategy> _overlayLayerStrategies;
        private ShowcaseApplication.Controls.DialogHost _host;

        public ModalDialogService()
        {
            this._overlayLayerStrategies = new List<IOverlayLayerStrategy>
            {
                new ClassicDesktopStyleStrategy(),
                new SingleViewStyleStrategy(),
            };
        }

        public async Task<ModalDialogResult> Show(
            ModalDialogViewModalBase viewModel, 
            ModalDialogArgs args)
        {
            var tcs = new TaskCompletionSource<ModalDialogResult>();

            if (this._host == null)
            {
                this._host = new ShowcaseApplication.Controls.DialogHost();
            }

            viewModel.SetArgs(args);
            var modalDialog = new ModalDialog
            {
                Content = viewModel
            };

            EventHandler<ModalDialogResult> closeEventHandler = null;
            closeEventHandler = (s, e) => 
            {
                modalDialog.Close();
                viewModel.Closed -= closeEventHandler;

                tcs.TrySetResult(new ModalDialogResult(e.ExitCode));
                tcs = null;
                this._host = null;
                modalDialog = null;
            };
            viewModel.Closed += closeEventHandler;

            this._host.Content = modalDialog;

            var overlayLayer = this._overlayLayerStrategies
                .Single(x => x.IsValid())
                .GetOverlayLayer();
            overlayLayer.Children.Add(this._host);

            return await tcs.Task;
        }

        public async Task<ModalDialogResult<TResult>> Show<TResult>(
            ModalDialogViewModalBase<TResult> viewModel, 
            ModalDialogArgs args)
        {
            var tcsWithResult = new TaskCompletionSource<ModalDialogResult<TResult>>();

            if (this._host == null)
            {
                this._host = new ShowcaseApplication.Controls.DialogHost();
            }

            viewModel.SetArgs(args);
            var modalDialog = new ModalDialog
            {
                Content = viewModel
            };

            EventHandler<ModalDialogResult<TResult>> closeEventHandler = null;
            closeEventHandler = (s, e) => 
            {
                modalDialog.Close();
                viewModel.Closed -= closeEventHandler;

                tcsWithResult.TrySetResult(e);
                tcsWithResult = null;
                this._host = null;
                modalDialog = null;
            };
            viewModel.Closed += closeEventHandler;

            this._host.Content = modalDialog;

            var overlayLayer = this._overlayLayerStrategies
                .Single(x => x.IsValid())
                .GetOverlayLayer();
            overlayLayer.Children.Add(this._host);

            return await tcsWithResult.Task;
        }
    }
}
