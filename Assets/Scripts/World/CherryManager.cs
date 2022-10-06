using System;
using System.Collections.Generic;
using Scripts.CustomAnimationManager;
using Object = UnityEngine.Object;

namespace Scripts.World
{
    public class CherryManager : IDisposable
    {
        private const float _animationsSpeed = 10;

        private List<CherryView> _cherryViews;
        private SpriteAnimator _spriteAnimator;


        public CherryManager(List<CherryView> cherryViews, SpriteAnimator spriteAnimator)
        {
            _cherryViews = cherryViews;
            _spriteAnimator = spriteAnimator;

            foreach (var cherryView in cherryViews)
            {
                cherryView.OnLevelObjectContact += OnLevelObjectContact;
                _spriteAnimator.StartAnimation(cherryView.SpriteRenderer, Track.cherry_anim, true, _animationsSpeed);
            }

        }

        private void OnLevelObjectContact(CherryView contactView)
        {
            if (_cherryViews.Contains(contactView))
            {
                _spriteAnimator.StopAnimation(contactView.SpriteRenderer);
                Object.Destroy(contactView.gameObject);
            }
        }

        public void Dispose()
        {
            foreach (var cherryView in _cherryViews)
                cherryView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}