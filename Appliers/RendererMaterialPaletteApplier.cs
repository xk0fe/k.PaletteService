using k.PaletteService.Common;
using UnityEngine;

namespace k.PaletteService.Appliers {
    [RequireComponent(typeof(Renderer))]
    public class RendererMaterialPaletteApplier : BasePaletteApplier<Renderer> {
        protected override void Apply(PaletteObject paletteObject, Renderer obj) {
            base.Apply(paletteObject, obj);
            obj.material = paletteObject.Material;
        }
    }
}