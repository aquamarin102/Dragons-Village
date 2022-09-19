using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.CustomAnimationManager
{


    [CreateAssetMenu(fileName = "SpriteAnimationConfig", menuName = "Config/SpriteAnimationConfig", order = 1)]

    public class SpriteAnimationConfig : ScriptableObject
    {
        [SerializeField] private List<SpritesSequence> _sequences;

        public List<SpritesSequence> Sequences => _sequences;
    }
}