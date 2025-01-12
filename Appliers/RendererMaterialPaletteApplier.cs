using UnityEngine;

namespace k.PaletteService.Appliers
{
    [RequireComponent(typeof(Renderer))]
    public class RendererMaterialPaletteApplier : BasePaletteApplier<Renderer>
    {
        public override void Apply()
        {
            base.Apply();
            if (!TryGetPaletteObject(out var paletteObject)) return;
            if (!TryGetObject(out var obj)) return;
            obj.material = paletteObject.Material;
        }
    }
}