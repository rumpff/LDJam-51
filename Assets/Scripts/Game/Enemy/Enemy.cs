using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public WeaponScriptableObject TEST;

    [SerializeField] private AIPath _aiPath;
    [SerializeField] private AIDestinationSetter _destinationSetter;
    [SerializeField] private EnemyWeaponHandler _weaponHandler;
    [SerializeField] private Rigidbody2D _rigidbody;

    private IEnemyState _state;

    public EnemyWeaponHandler WeaponHandler => _weaponHandler;
    public AIPath AiPath => _aiPath;
    public AIDestinationSetter DestinationSetter => _destinationSetter;
    public Rigidbody2D EnemyRigidbody => _rigidbody;

    void Start()
    {
        Initialize(TEST);

    }

    // Start is called before the first frame update
    void Initialize(WeaponScriptableObject weapon)
    {
        _weaponHandler.Initialize(gameObject);
        _weaponHandler.WeaponPickup(new EnemyArmedState(), weapon);
        SwitchState(new EnemyAliveState());

        _aiPath.endReachedDistance = weapon.AiDesiredPlayerDistance;
    }

    // Update is called once per frame
    void Update()
    {
        _state?.OnUpdate();
    }

    public void SwitchState(IEnemyState state)
    {
        _state?.OnExit();
        _state = state;
        _state.OnEnter(this);
    }

    public void BulletHit()
    {
        gameObject.SetActive(false);
    }
}
