using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;
using Avalonia.Xaml.Interactivity;

namespace SalesApp.Behaviors
{
    /// <summary>
    /// This behavior only make sense for Linux dut to the fact on this platform is not possible yet to center the window into the screen.
    /// </summary>
    public class CenterScreenBehavior : Behavior<Window>
    {
        protected override async void OnAttached()
        {
            base.OnAttached();

            if (this.AssociatedObject == null)
            {
                return;
            }

            Screen? screen = null;
            while (screen == null) 
            {
                await Task.Delay(1);
                screen = this.AssociatedObject.Screens.ScreenFromVisual(this.AssociatedObject);
            }

            if (this.AssociatedObject.WindowStartupLocation == WindowStartupLocation.CenterScreen)
            {
                var x = (int)Math.Floor(screen.Bounds.Width / 2 - this.AssociatedObject.Bounds.Width / 2);
                var y = (int)Math.Floor(screen.Bounds.Height / 2 - (this.AssociatedObject.Bounds.Height + 30) / 2);

                this.AssociatedObject.Position = new PixelPoint(x, y);
            }
        }
    }
}