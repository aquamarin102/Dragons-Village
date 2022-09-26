using UnityEngine;

namespace Scripts.Turret
{
    public class Bullet
    {
        private BulletView _bulletView;

        public Bullet(BulletView bulletView)
        {
            _bulletView = bulletView;
            _bulletView.SetVisible(false);
        }

       

        public void Throw(Vector3 position, Vector3 velocity)
        {
            _bulletView.SetVisible(false);
            _bulletView.transform.position = position;
            _bulletView.Rigidbody2D.velocity = Vector2.zero;
            _bulletView.Rigidbody2D.angularVelocity = 0;
            _bulletView.Rigidbody2D.AddForce(velocity, ForceMode2D.Impulse);
            _bulletView.SetVisible(true);
        }
        
      
    }
}