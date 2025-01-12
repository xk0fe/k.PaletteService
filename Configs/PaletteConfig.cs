using System.Collections.Generic;
using k.PaletteService.Common;
using k.PaletteService.Enums;
using UnityEngine;

namespace k.PaletteService.Configs
{
    [CreateAssetMenu(menuName = "k/Services/Palette/" + nameof(PaletteConfig), fileName = nameof(PaletteConfig), order = 0)]
    public class PaletteConfig : ScriptableObject
    {
        [SerializeField] private PaletteObject[] _paletteObjects;
     
        private Dictionary<PaletteItem, PaletteObject> _paletteDictionary;
        
        public Dictionary<PaletteItem, PaletteObject> PaletteObjects
        {
            get
            {
                if (_paletteDictionary != null) return _paletteDictionary;
                _paletteDictionary = new Dictionary<PaletteItem, PaletteObject>();
                if (_paletteObjects == null || _paletteObjects.Length == 0) return _paletteDictionary;
                foreach (var paletteObject in _paletteObjects)
                {
                    if (!_paletteDictionary.TryAdd(paletteObject.Item, paletteObject))
                    {
                        Debug.LogError("Duplicate palette item found: " + paletteObject.Item + ". Skipping.");
                    }
                }

                return _paletteDictionary;
            }
        }
    }
}