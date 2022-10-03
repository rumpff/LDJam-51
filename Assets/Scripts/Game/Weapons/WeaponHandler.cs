using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Weapon Weapon { get; protected set; }
    public Vector2 AimDirection { get; protected set; }
    public float AimAngle
    {
        get
        {
            return Mathf.Atan2(AimDirection.y, AimDirection.x);
        }
    }


    [SerializeField] protected WeaponScriptableObject UnarmedScriptableObject;
    [SerializeField] protected bool _explodingWeapons;
    protected IWeaponState _weaponState;

    public bool ExplodingWeapons => _explodingWeapons;

    public virtual void Initialize(GameObject owner)
    {
        Weapon = null;
        AimDirection = Vector2.zero;
    }

    public virtual void HandleWeapon()
    {
        _weaponState?.OnUpdate();
        Weapon.UpdateWeapon();
    }

    public virtual void Fire()
    {
        
    }

    public virtual void KnockBack(Vector2 force)
    {

    }

    public void WeaponPickup(IWeaponState state, WeaponScriptableObject weapon)
    {
        _weaponState?.OnExit();
        _weaponState = state;

        NewWeaponInstance(weapon);
        _weaponState.OnEnter(this, weapon);
    }

    public void UnArm(IWeaponState state, WeaponScriptableObject weapon)
    {
        _weaponState?.OnExit();
        _weaponState = state;

        NewWeaponInstance(weapon);
        _weaponState.OnEnter(this, weapon);
    }

    public virtual void NewWeaponInstance(WeaponScriptableObject weapon)
    {
        if(Weapon != null)
            Destroy(Weapon.gameObject);
    }

    /// <summary>
    /// Unarm with default unarmed scriptable object
    /// </summary>
    public void UnArm()
    {
        UnArm(new PlayerUnArmedState(), UnarmedScriptableObject);
    }
}
