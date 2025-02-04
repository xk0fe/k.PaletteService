using k.PaletteService.Common;
using UnityEngine;

namespace k.PaletteService.Appliers {
    public class CameraColorApplier : BasePaletteApplier<Camera> {
        protected override void Apply(PaletteObject paletteObject, Camera obj) {
            base.Apply(paletteObject, obj);
            obj.backgroundColor = paletteObject.Color;
        }
    }
}