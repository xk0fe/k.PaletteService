using System;
using k.PaletteService.Enums;
using UnityEngine;

namespace k.PaletteService.Common {
    [Serializable]
    public class PaletteObject {
        [SerializeField] private PaletteItem _item;
        [SerializeField] private Material _material;
        [SerializeField] private Color _color;
        [SerializeField] private Texture _texture;

        public PaletteItem Item => _item;
        public Material Material => _material;
        public Color Color => _color;
        public Texture Texture => _texture;
    }
}