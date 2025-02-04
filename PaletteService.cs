using System;
using k.PaletteService.Common;
using k.PaletteService.Configs;
using k.PaletteService.Enums;
using k.Services;
using UnityEngine;
using Random = UnityEngine.Random;

namespace k.PaletteService {
    [CreateAssetMenu(menuName = "k/Services/Palette/" + nameof(PaletteService), fileName = nameof(PaletteService),
        order = 0)]
    public class PaletteService : GenericScriptableService<PaletteService> {
        [SerializeField] private PaletteConfig _currentPalette;
        [SerializeField] private PaletteConfig[] _availablePalettes;
        [SerializeField] private bool _randomizeOnStart;

        public PaletteConfig CurrentPalette => _currentPalette;
        public Action<PaletteConfig> OnPaletteUpdate;

        public override void Initialize() {
            base.Initialize();
            if (_randomizeOnStart) SetRandomPalette();
        }

        public void SetRandomPalette() {
            if (_availablePalettes == null || _availablePalettes.Length == 0) {
                Debug.LogWarning("No available palettes!");
                return;
            }

            var randomIndex = Random.Range(0, _availablePalettes.Length);
            _currentPalette = _availablePalettes[randomIndex];
            OnPaletteUpdate?.Invoke(_currentPalette);
        }

        public bool TryGetPaletteObject(PaletteItem item, out PaletteObject paletteObject) {
            paletteObject = null;
            if (_currentPalette == null) return false;
            var paletteObjects = _currentPalette.PaletteObjects;
            if (paletteObjects == null) return false;
            return paletteObjects.TryGetValue(item, out paletteObject);
        }
    }
}