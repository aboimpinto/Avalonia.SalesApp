using Avalonia.Controls.Primitives;

namespace ShowcaseApplication.Controls.OverlayLayerStrategies
{
    public interface IOverlayLayerStrategy
    {
        bool IsValid();

        OverlayLayer GetOverlayLayer();
    }
}
