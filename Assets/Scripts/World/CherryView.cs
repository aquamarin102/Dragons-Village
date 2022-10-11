using System;
using Scripts.Player;
using UnityEngine;

namespace Scripts.World
{
    public class CherryView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        
        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        
        public Action<CherryView> OnLevelObjectContact { get; set; }
        
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            var levelObject = collider.gameObject.GetComponent<CharacterView>();
            
            if(levelObject != null)
            OnLevelObjectContact?.Invoke(this);
        }
    }
}