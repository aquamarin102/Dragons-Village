using System.Collections.Generic;
using Scripts.CustomAnimationManager;
using Scripts.Player;
using Scripts.Turret;
using Scripts.World;
using UnityEngine;

namespace Scripts {

public class Root : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _backgrond;
    [SerializeField] private GameObject _middlegrond;

    [SerializeField] private CharacterView _characterView;
    [SerializeField] private SpriteAnimationConfig _spriteAnimationConfig;

    [SerializeField] private CannonView _cannonView;
    [SerializeField] private List<BulletView> _bullets;

    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimator;
    private MainHeroWalker _mainHeroWalker;
    private AimingMuzzle _aimingMuzzle;
    private BulletEmitter _bulletEmitter;
    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _backgrond.transform, _middlegrond.transform);
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        _mainHeroWalker = new MainHeroWalker(_characterView, _spriteAnimator);
        _aimingMuzzle = new AimingMuzzle(_cannonView.transform, _characterView.transform);
        _bulletEmitter = new BulletEmitter(_bullets, _cannonView.MuzzleTransform);
    }

    private void Update()
    {
        _paralaxManager.Update();
        _spriteAnimator.Update();
        _aimingMuzzle.Update();
        _bulletEmitter.Update();
        
    }

    private void FixedUpdate()
    {
        _mainHeroWalker.FixedUpdate();
    }

    private void OnDestroy()
    {
        
    }
}
}
