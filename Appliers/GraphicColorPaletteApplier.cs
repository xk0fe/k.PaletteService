using UnityEngine;
using UnityEngine.UI;

namespace k.PaletteService.Appliers
{
    [RequireComponent(typeof(Graphic))]
    public class GraphicColorPaletteApplier : BasePaletteApplier<Graphic>
    {
        public override void Apply()
        {
            base.Apply();
            if (!TryGetPaletteObject(out var paletteObject)) return;
            if (!TryGetObject(out var obj)) return;
            obj.color = paletteObject.Color;
        }
    }
}