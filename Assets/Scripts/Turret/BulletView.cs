using UnityEngine;

namespace Scripts.Turret
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public void SetVisible(bool visible)
        {
            _spriteRenderer.enabled = visible;
        }
    }
}