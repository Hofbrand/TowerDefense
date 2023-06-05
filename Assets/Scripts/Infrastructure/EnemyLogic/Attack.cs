using Assets.Scripts.Infrastructure.EnemyLogic;
using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.Services;
using System.Linq;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public EnemyAnimator Animator;

    public float AttackCooldown = 3f;
    public float Cleavage = 0.5f;
    public float EffectiveDistance = 1f;

    private IGameFactory _gameFactory;
    private Transform _target;
    private float _attackCooldown;
    private bool _isAttacking;
    private int _layerMask;
    private Collider[] _hits = new Collider[1];
    private bool _isAttackEnabled;

    private void Awake()
    {
        _layerMask = 1 << LayerMask.NameToLayer("Attackable");
        _gameFactory = AllServices.Container.Single<IGameFactory>();
    }

    private void Start()
    {
        OnTargetCreated();
    }

    private void Update()
    {
        if (_attackCooldown > 0)
            _attackCooldown -= Time.deltaTime;

        if (CanAttack())
            StartAttack();
    }
    public void Enable() => _isAttackEnabled = true;
    public void Disable() => _isAttackEnabled = false;

    private bool CanAttack()
    {
        return _isAttackEnabled && !_isAttacking && _attackCooldown <= 0;
    }

    private void StartAttack()
    {
        transform.LookAt(_target);
        Animator.PlayAttack();

        _isAttacking = true;
    }

    private void OnAttack()
    {
        if (Hit(out Collider hit))
        {
            Debug.Log(hit.name);
        }
    }

    private bool Hit(out Collider hit)
    {
        Vector3 startPoint = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z) + transform.forward * EffectiveDistance;
        int hitsCount = Physics.OverlapSphereNonAlloc(startPoint, Cleavage, _hits, _layerMask);

        hit = _hits.FirstOrDefault();

        return hitsCount > 0;
    }

    private void OnAttackEnded()
    {
        _attackCooldown = AttackCooldown;
        _isAttacking = false;
    }

    private void OnTargetCreated() => _target = _gameFactory.TargetTransform.transform;


}
