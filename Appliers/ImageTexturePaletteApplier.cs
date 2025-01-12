using UnityEngine;
using UnityEngine.UI;

namespace k.PaletteService.Appliers
{
    [RequireComponent(typeof(Image))]
    public class ImageTexturePaletteApplier : BasePaletteApplier<Image>
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