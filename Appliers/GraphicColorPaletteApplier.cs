using k.PaletteService.Common;
using UnityEngine;
using UnityEngine.UI;

namespace k.PaletteService.Appliers {
    [RequireComponent(typeof(Graphic))]
    public class GraphicColorPaletteApplier : BasePaletteApplier<Graphic> {
        protected override void Apply(PaletteObject paletteObject, Graphic obj) {
            base.Apply(paletteObject, obj);
            obj.color = paletteObject.Color;
        }
    }
}