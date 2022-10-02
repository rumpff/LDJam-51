using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "LD-Jam/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField] private float _cooldownDuration = 0.1f;
    [SerializeField] private int _bulletAmount = 1;
    [SerializeField] private float _timeBetweenShots = 0;
    [SerializeField] private GameObject _weaponPrefab = null;
    [SerializeField] private GameObject _bulletPrefab = null;

    public float CooldownDuration => _cooldownDuration;
    public int BulletAmount => _bulletAmount;
    public float TimeBetweenShots => _timeBetweenShots;
    public GameObject WeaponPrefab => _weaponPrefab;
    public GameObject BulletPrefab => _bulletPrefab;
}
