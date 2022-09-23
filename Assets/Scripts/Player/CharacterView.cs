using UnityEngine;

namespace Scripts.Player
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody2D;
        [SerializeField]
        private Collider2D _collider2D;
         
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [Header("Settings")] 
        [SerializeField] private float _walkSpeed = 1f;
        [SerializeField] private float _animationSpeed = 3f;
        [SerializeField] private float _jumpForce = 350f;
        [SerializeField] private float _jumpTresh = 0.1f;
        [SerializeField] private float _movingTresh = 0.1f;
        [SerializeField] private float _flyTresh = 1f;


        public float WalkSpeed => _walkSpeed;
        public float AnimationSpeed => _animationSpeed;
        public float JumpForce => _jumpForce;
        public float JumpTresh => _jumpTresh;
        public float MovingTresh => _movingTresh;
        public float FlyTresh => _flyTresh;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public Collider2D Collider2D => _collider2D;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
    }
}