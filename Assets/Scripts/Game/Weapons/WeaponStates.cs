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

public class PWeaponWieldingState : IWeaponState
{
    private Player _player;
    private PlayerWeaponHandler _weaponHandler;
    private WeaponScriptableObject _equippedWeapon;


    public PWeaponWieldingState(Player p)
    {
        _player = p;
    }

    public void OnEnter(WeaponHandler weaponHandler, WeaponScriptableObject equippedWeapon)
    {
        _weaponHandler = weaponHandler as PlayerWeaponHandler;
        _equippedWeapon = equippedWeapon;
    }

    public void OnUpdate()
    {
        if(_weaponHandler.CheckThrowInput())
            _weaponHandler.UnArm();

        if(_weaponHandler.CheckShootInput())
            OnFire();
    }

    public void OnFire()
    {
        // Check if able to shoot
        _weaponHandler.Fire();
    }

    public void OnExit()
    {
        // throw
    }
}
public class PWeaponUnArmedState : IWeaponState
{
    protected WeaponScriptableObject EquippedWeapon;
    private PlayerWeaponHandler _weaponHandler;

    public void OnEnter(WeaponHandler weaponHandler, WeaponScriptableObject equippedWeapon)
    {
        _weaponHandler = weaponHandler as PlayerWeaponHandler;
        EquippedWeapon = equippedWeapon;
    }

    public void OnUpdate()
    {

        if (_weaponHandler.CheckShootInput())
            OnFire();
    }

    public void OnFire()
    {
        // Check if able to shoot
        _weaponHandler.Fire();
    }

    public void OnExit()
    {

    }
}

public class EWeaponArmedState : IWeaponState
{
    protected WeaponScriptableObject EquippedWeapon;
    private EnemyWeaponHandler _weaponHandler;

    public void OnEnter(WeaponHandler weaponHandler, WeaponScriptableObject equippedWeapon)
    {
        _weaponHandler = weaponHandler as EnemyWeaponHandler;
        EquippedWeapon = equippedWeapon;
    }

    public void OnUpdate()
    {
        float distanceToPlayer = Vector2.Distance(_weaponHandler.transform.position,
            Managers.Instance.GameManager.Player.transform.position);

        if(distanceToPlayer <= EquippedWeapon.AiShootingDistance)
            OnFire();

        DebugText.Instance.AddText($"Distance to player: {distanceToPlayer}");
    }

    public void OnFire()
    {
        // Check if able to shoot
        _weaponHandler.Fire();
    }

    public void OnExit()
    {

    }
}