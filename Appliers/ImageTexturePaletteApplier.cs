using k.PaletteService.Common;
using UnityEngine;
using UnityEngine.UI;

namespace k.PaletteService.Appliers
{
    [RequireComponent(typeof(Image))]
    public class ImageTexturePaletteApplier : BasePaletteApplier<Image>
    {
        protected override void Apply(PaletteObject paletteObject, Image obj)
        {
            base.Apply(paletteObject, obj);
            obj.material = paletteObject.Material;
        }
    }
}