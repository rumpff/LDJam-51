using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "LD-Jam/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField] private float _cooldownDuration = 0.1f;
    [SerializeField] private int _bulletAmount = 1;
    [SerializeField] private float _timeBetweenShots = 0;
    [SerializeField] private float _knockbackForce = 0;
    [SerializeField] private BulletBehaviour _bulletBehaviour;
    [Space(5)]
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private GameObject _bulletPrefab;
    [Space(5)] 
    [SerializeField] private float _aiDesiredPlayerDistance;
    [SerializeField] private float _aiShootingDistance;


    public float CooldownDuration => _cooldownDuration;
    public int BulletAmount => _bulletAmount;
    public float TimeBetweenShots => _timeBetweenShots;
    public float KnockbackForce => _knockbackForce;

    public BulletBehaviour BulletBehaviour => _bulletBehaviour;
    public GameObject WeaponPrefab => _weaponPrefab;
    public GameObject BulletPrefab => _bulletPrefab;

    public float AiDesiredPlayerDistance => _aiDesiredPlayerDistance;
    public float AiShootingDistance => _aiShootingDistance;
}
