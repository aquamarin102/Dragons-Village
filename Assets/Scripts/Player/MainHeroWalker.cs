using Scripts.CustomAnimationManager;
using Scripts.World;
using UnityEngine;
namespace Scripts.Player
{
    public class MainHeroWalker
    {
        private const string Horizontal = nameof(Horizontal);
        private const string Vertical = nameof(Vertical);

     
        private CharacterView _characterView;
        private SpriteAnimator _spriteAnimator;
        private ContactsPoller _contactsPoller;

        public MainHeroWalker(CharacterView characterView, SpriteAnimator spriteAnimator)
        {
            _characterView = characterView;
            _spriteAnimator = spriteAnimator;
            _contactsPoller = new ContactsPoller(_characterView.Collider2D);
        }

        public void FixedUpdate()
        {
            var doJump = Input.GetAxis(Vertical) > 0;
            var xAxisInput = Input.GetAxis(Horizontal);
            
            _contactsPoller.Update();
            
            var isGoSideWay = Mathf.Abs(xAxisInput) > _characterView.MovingTresh;
            var newVelocity = 0f;
            
            

            if (isGoSideWay)
                _characterView.SpriteRenderer.flipX = xAxisInput < 0;

            if (isGoSideWay && 
                (xAxisInput < 0 || !_contactsPoller.HasRightContacts) &&
                (xAxisInput > 0 || !_contactsPoller.HasLeftContacts))
            {
                newVelocity = Time.fixedDeltaTime * _characterView.WalkSpeed * (xAxisInput < 0 ? -1 : 1);
            }

            _characterView.Rigidbody2D.velocity = _characterView.Rigidbody2D.velocity.Change(x: newVelocity);

            if (_contactsPoller.IsGrounded && doJump &&
                Mathf.Abs(_characterView.Rigidbody2D.velocity.y) <= _characterView.JumpForce)
            {
                _characterView.Rigidbody2D.AddForce(Vector3.up * _characterView.JumpForce);
            }

            if (_contactsPoller.IsGrounded)
            {
                var track = isGoSideWay ? Track.walk : Track.idle;
                _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, track, true, _characterView.AnimationSpeed);
            }
            else if (Mathf.Abs(_characterView.Rigidbody2D.velocity.y) > _characterView.FlyTresh)
            {
                var track = Track.jump;
                _spriteAnimator. StartAnimation(_characterView.SpriteRenderer, track, true, _characterView.AnimationSpeed);
            }
            



        }
    }

}