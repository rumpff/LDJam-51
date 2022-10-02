using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletBehaviour", menuName = "LD-Jam/BulletBehaviour")]
public class BulletBehaviour : ScriptableObject
{
    [SerializeField] private float _initialSpeed;
    [SerializeField] private float _lifetime;
    [SerializeField] private float _drag;
    [Space(5)] 
    [SerializeField] private float _aimRandom;
    [SerializeField] private float _speedRandom;
    [Space(5)]
    [SerializeField] private bool _destroyOnKill = true;
    [SerializeField] private bool _destroyOnImpact = true;

    public float InitialSpeed => _initialSpeed;
    public float Lifetime => _lifetime;
    public float AimRandom => (_aimRandom * Mathf.Deg2Rad);
    public float SpeedRandom => _speedRandom;
    public float Drag => _drag;
    public bool DestroyOnKill => _destroyOnKill;
    public bool DestroyOnImpact => _destroyOnImpact;
}
