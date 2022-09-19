using Scripts.CustomAnimationManager;
using UnityEngine;

namespace Scripts {

public class Root : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _backgrond;
    [SerializeField] private GameObject _middlegrond;

    [SerializeField] private CharacterView _characterView;
    [SerializeField] private SpriteAnimationConfig _spriteAnimationConfig;

    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimator;
    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _backgrond.transform, _middlegrond.transform);
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.idle, true, 10);
    }

    private void Update()
    {
        _paralaxManager.Update();
        _spriteAnimator.Update();
    }

    private void FixedUpdate()
    {
        
    }

    private void OnDestroy()
    {
        
    }
}
}
