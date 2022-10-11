using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.CustomAnimationManager
{
    [Serializable]
    public class SpritesSequence
    {
        public Track Track;
        public List<Sprite> Sprites = new List<Sprite>();
    }
}