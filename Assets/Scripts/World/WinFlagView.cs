using System;
using Scripts.Player;
using UnityEngine;

namespace Scripts.World
{
    public class WinFlagView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        
        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        
        public Action<WinFlagView> OnLevelObjectContact { get; set; }
        
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            var levelObject = collider.gameObject.GetComponent<CharacterView>();
            if(levelObject != null)
                OnLevelObjectContact?.Invoke(this);
        }
        
    }
}