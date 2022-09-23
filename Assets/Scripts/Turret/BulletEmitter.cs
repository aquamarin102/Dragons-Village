using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Turret
{
    public class BulletEmitter
    {
        private const float _delay = 1f;
        private const float _startSpeed = 5f;

        private List<Bullet> _bullets = new List<Bullet>();
        private Transform _transform;

        private int _currentIndex;
        private float _timeTillNextBullet;

        public BulletEmitter(List<BulletView> bulletViews, Transform transform)
        {
            _transform = transform;

            foreach (var bulletView in bulletViews)
            {
                _bullets.Add(new Bullet(bulletView));
            }
        }

        public void Update()
        {
            if (_timeTillNextBullet > 0)
            {
                _timeTillNextBullet -= Time.deltaTime;
            }
            else
            {
                _timeTillNextBullet = _delay;
                _bullets[_currentIndex].Throw(_transform.position,_transform.up * _startSpeed);
                _currentIndex++;

                if (_currentIndex >= _bullets.Count)
                {
                    _currentIndex = 0; 
                }
            }
            
        }
    }
}