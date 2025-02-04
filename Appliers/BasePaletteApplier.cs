using k.PaletteService.Common;
using k.PaletteService.Configs;
using k.PaletteService.Enums;
using UnityEngine;

namespace k.PaletteService.Appliers {
    public class BasePaletteApplier<T> : MonoBehaviour where T : Component {
        [SerializeField] protected PaletteItem _paletteItem;
        private T _object;

        private void OnEnable() {
            var service = PaletteService.Instance;
            if (service == null) return;
            service.OnPaletteUpdate += PaletteUpdate;
            PaletteUpdate(service.CurrentPalette);
        }

        private void OnDisable() {
            var service = PaletteService.Instance;
            if (service == null) return;
            service.OnPaletteUpdate -= PaletteUpdate;
        }

        protected virtual void PaletteUpdate(PaletteConfig config) {
            if (!config.PaletteObjects.TryGetValue(_paletteItem, out var paletteObject)) return;
            if (!TryGetObject(out var obj)) return;
            Apply(paletteObject, obj);
        }

        protected virtual void Apply(PaletteObject paletteObject, T obj) {
        }

        protected bool TryGetObject(out T obj) {
            if (_object == null) _object = GetComponent<T>();
            obj = _object;
            return obj != null;
        }

        protected bool TryGetPaletteObject(out PaletteObject paletteObject) {
            var service = PaletteService.Instance;
            if (service == null) {
                paletteObject = null;
                return false;
            }

            return service.TryGetPaletteObject(_paletteItem, out paletteObject);
        }
    }
}