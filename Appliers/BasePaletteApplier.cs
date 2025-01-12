using k.PaletteService.Common;
using k.PaletteService.Enums;
using UnityEngine;

namespace k.PaletteService.Appliers
{
    public class BasePaletteApplier<T> : MonoBehaviour where T : Component
    {
        [SerializeField] protected PaletteItem _paletteItem;
        private T _object;

        private void OnEnable()
        {
            var service = PaletteService.Instance;
            if (service == null) return;
            service.OnPaletteUpdate.AddListener(Apply);
            Apply();
        }

        private void OnDisable()
        {
            var service = PaletteService.Instance;
            if (service == null) return;
            service.OnPaletteUpdate.RemoveListener(Apply);
        }

        public virtual void Apply()
        {
        }

        protected bool TryGetObject(out T obj)
        {
            if (_object == null) _object = GetComponent<T>();
            obj = _object;
            return obj != null;
        }
        
        protected bool TryGetPaletteObject(out PaletteObject paletteObject)
        {
            var service = PaletteService.Instance;
            if (service == null)
            {
                paletteObject = null;
                return false;
            }

            return service.TryGetPaletteObject(_paletteItem, out paletteObject);
        }
    }
}