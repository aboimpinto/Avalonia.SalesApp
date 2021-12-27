using Avalonia;
using Avalonia.Controls;

namespace ShowcaseApplication.Controls
{
    public class ModalDialog : ContentControl
    {
        public static readonly AvaloniaProperty IsOpenProperty = 
            AvaloniaProperty.Register<ModalDialog, bool>(nameof(IsOpen));

        public bool IsOpen 
        {  
            get => (bool)GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }

        public ModalDialog()
        {
            PseudoClasses.Set(":open", false);
        }

        protected override void OnPropertyChanged<T>(AvaloniaPropertyChangedEventArgs<T> change)
        {
            switch(change.Property.Name)
             {
                 case nameof(IsVisible):
                    PseudoClasses.Set(":open", this.IsVisible);
                    break;
             }


            base.OnPropertyChanged(change);
        }

    }
}
