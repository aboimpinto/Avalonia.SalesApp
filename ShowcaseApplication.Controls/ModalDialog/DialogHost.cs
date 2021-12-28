using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Styling;

namespace ShowcaseApplication.Controls
{
    public class DialogHost : ContentControl, IStyleable
    {
        Type IStyleable.StyleKey => typeof(OverlayPopupHost);

        private IDisposable _rootBoundsWatcher;

        public DialogHost()
        {
            Background = null;
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center;
        }

        protected override Size MeasureOverride(Size availableSize)
		{
			_ = base.MeasureOverride(availableSize);

			if (this.VisualRoot is TopLevel tl)
			{
				return tl.ClientSize;
			}
			else if (VisualRoot is IControl c)
			{
				return c.Bounds.Size;
			}

			return Size.Empty;
		}

		protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
		{
			base.OnAttachedToVisualTree(e);
			if (e.Root is IControl wb)
			{
				// OverlayLayer is a Canvas, so we won't get a signal to resize if the window
				// bounds change. Subscribe to force update
				_rootBoundsWatcher = wb.GetObservable(BoundsProperty).Subscribe(_ => OnRootBoundsChanged());
			}
		}

		protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
		{
			base.OnDetachedFromVisualTree(e);
			_rootBoundsWatcher?.Dispose();
			_rootBoundsWatcher = null;
		}

		private void OnRootBoundsChanged()
		{
			InvalidateMeasure();
		}
    }
}
