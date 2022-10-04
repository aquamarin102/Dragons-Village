using System;
using Scripts.CustomAnimationManager;
using UnityEngine;

namespace Scripts.World
{
    public class ObjectView : MonoBehaviour
    {
        [SerializeField]
        private Collider2D _collider2D;
        
        [SerializeField]
        private Rigidbody2D _rigidbody2D;
        
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        
        private Transform _transform;

        public Transform Transform => _transform;

        public Collider2D Collider2D => _collider2D;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        
    }
}