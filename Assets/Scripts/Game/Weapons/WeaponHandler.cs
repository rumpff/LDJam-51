using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] protected WeaponScriptableObject UnarmedScriptableObject;
    [SerializeField] protected bool _explodingWeapons;
    protected IWeaponState _weaponState;

    public virtual void Initialize(GameObject owner)
    {

    }

    public virtual void HandleWeapon()
    {
        _weaponState?.OnUpdate();
    }

    public virtual void Fire()
    {
        
    }

    public void WeaponPickup(IWeaponState state, WeaponScriptableObject weapon)
    {
        _weaponState?.OnExit();
        _weaponState = state;
        _weaponState.OnEnter(this, weapon);
    }

    public void UnArm(IWeaponState state, WeaponScriptableObject weapon)
    {
        _weaponState?.OnExit();
        _weaponState = state;
        _weaponState.OnEnter(this, weapon);
    }

    /// <summary>
    /// Unarm with default unarmed scriptable object
    /// </summary>
    public void UnArm()
    {
        UnArm(new PlayerUnArmedState(), UnarmedScriptableObject);
    }
}
