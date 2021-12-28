using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Primitives;

namespace ShowcaseApplication.Controls.OverlayLayerStrategies
{
    public class SingleViewStyleStrategy : IOverlayLayerStrategy
    {
        public OverlayLayer GetOverlayLayer()
        {
            var singleStyleApp = Application.Current?.ApplicationLifetime as ISingleViewApplicationLifetime;

            var ol = OverlayLayer.GetOverlayLayer(singleStyleApp?.MainView);
            if (ol == null)
            {
                throw new InvalidOperationException();
            }

            return ol;
                
        }

        public bool IsValid()
        {
            if (Application.Current?.ApplicationLifetime is ISingleViewApplicationLifetime)
            {
                return true;
            }

            return false;
        }
    }
}
