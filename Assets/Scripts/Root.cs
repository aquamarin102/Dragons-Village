using System.Collections.Generic;
using Pathfinding;
using Scripts.CustomAnimationManager;
using Scripts.Enemy;
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
    [SerializeField] private List<CherryView> _cherres;
    [SerializeField] private List<TrapsLoseView> _trapsLoseViews;
    [SerializeField] private List<WinFlagView> _winFlagView;

    [Header("Protector AI")]
    [SerializeField] private AIDestinationSetter _protectorAIDestinationSetter;
    [SerializeField] private AIPatrolPath _protectorAIPatrolPath;
    [SerializeField] private LevelObjectTrigger _protectedZoneTrigger;
    [SerializeField] private Transform[] _protectorWaypoints;
    
    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimator;
    private MainHeroWalker _mainHeroWalker;
    private AimingMuzzle _aimingMuzzle;
    private BulletEmitter _bulletEmitter;
    private CherryManager _сherryManager;
    private WinLoseManager _winLoseManager;
    private ProtectorAI _protectorAI;
    private ProtectedZone _protectedZone;
    
    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _backgrond.transform, _middlegrond.transform);
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        _mainHeroWalker = new MainHeroWalker(_characterView, _spriteAnimator);
        _aimingMuzzle = new AimingMuzzle(_cannonView.transform, _characterView.transform);
        _bulletEmitter = new BulletEmitter(_bullets, _cannonView.MuzzleTransform);
        //_сherryManager = new CherryManager( _cherres, _spriteAnimator);
        _winLoseManager = new WinLoseManager(_trapsLoseViews, _winFlagView);

        _protectorAI = new ProtectorAI(_characterView, new PatrolAIModel(_protectorWaypoints),
            _protectorAIDestinationSetter, _protectorAIPatrolPath);
        _protectorAI.Init();

        _protectedZone = new ProtectedZone(_protectedZoneTrigger, new List<IProtector> { _protectorAI });
        _protectedZone.Init();
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
        _protectorAI.Deinit();
        _protectedZone.Deinit();
        //_сherryManager.Dispose();
        _winLoseManager.Dispose();
    }
}
}
