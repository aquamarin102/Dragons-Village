using System;
using Scripts.Player;
using UnityEngine;

namespace Scripts.World
{
    public class TrapsLoseView : MonoBehaviour
    {
        public Action<TrapsLoseView> OnLevelObjectContact { get; set; }
        
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            var levelObject = collider.gameObject.GetComponent<CharacterView>();
            
            if(levelObject != null)
                OnLevelObjectContact?.Invoke(this);
        }
    }
}