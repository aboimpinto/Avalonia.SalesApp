using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Xaml.Interactivity;

namespace SalesApp.Behaviors
{
    public class WindowCloseBehavior : Behavior<Window>
    {
        public bool CloseTrigger
        {
            get { return (bool)GetValue(CloseTriggerProperty); }
            set { SetValue(CloseTriggerProperty, value); }
        }

        public static readonly AvaloniaProperty CloseTriggerProperty =
            AvaloniaProperty.Register<WindowCloseBehavior, bool>(
                "CloseTrigger");

        static WindowCloseBehavior()
        {
            CloseTriggerProperty.Changed.Subscribe(OnCloseTriggerChanged);
        }

        private static void OnCloseTriggerChanged(AvaloniaPropertyChangedEventArgs obj)
        {
            var behavior = obj.Sender as WindowCloseBehavior;
            if (behavior == null)
            {
                return;
            }

            behavior.OnCloseTriggerChanged();
        }

        private void OnCloseTriggerChanged()
        {
            // when closetrigger is true, close the window
            if (this.CloseTrigger)
            {
                // this.AssociatedObject.Close();
                Environment.Exit(0);
            }
        }
    }
}
