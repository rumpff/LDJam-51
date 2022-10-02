using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponState
{
    void OnEnter(WeaponHandler weaponHandler, WeaponScriptableObject equippedWeapon);
    void OnUpdate();
    void OnFire();
    void OnExit();
}

public class PlayerWieldingState : IWeaponState
{
    private Player _player;
    private PlayerWeaponHandler weaponHandler;
    private WeaponScriptableObject _equippedWeapon;

    public PlayerWieldingState(Player p)
    {
        _player = p;
    }

    public void OnEnter(WeaponHandler weaponHandler, WeaponScriptableObject equippedWeapon)
    {
        weaponHandler = this.weaponHandler;
        _equippedWeapon = equippedWeapon;
    }

    public void OnUpdate()
    {
        if(weaponHandler.CheckShootInput())
            weaponHandler.UnArm();

        if(weaponHandler.CheckShootInput())
            OnFire();
    }

    public void OnFire()
    {
        // Check if able to shoot
        weaponHandler.Fire();
    }

    public void OnExit()
    {
        // throw
    }
}
public class PlayerUnArmedState : IWeaponState
{
    protected WeaponScriptableObject EquippedWeapon;

    public void OnEnter(WeaponHandler weaponHandler, WeaponScriptableObject equippedWeapon)
    {
        EquippedWeapon = equippedWeapon;
    }

    public void OnUpdate()
    {
        
    }

    public void OnFire()
    {

    }

    public void OnExit()
    {

    }
}