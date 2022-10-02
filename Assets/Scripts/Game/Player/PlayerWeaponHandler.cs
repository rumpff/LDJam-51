using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeaponHandler : WeaponHandler
{
    [SerializeField] private Transform _weaponParent;
    [SerializeField] private WeaponScriptableObject test;

    private Player _player;

    public override void Initialize(GameObject owner)
    {
        base.Initialize(owner);

        AimDirection = Vector2.zero;

        _player = owner.GetComponent<Player>();
        UnArm();
        WeaponPickup(new PlayerWieldingState(_player), test);
    }

    public override void HandleWeapon()
    {
        base.HandleWeapon();
        UpdateAimDirection();

        DebugText.Instance.AddText($"AimAngle: {AimAngle}");
    }

    public override void Fire()
    {
        Weapon?.TriggerHeld();
    }
    public override void NewWeaponInstance(WeaponScriptableObject weapon)
    {
        base.NewWeaponInstance(weapon);

        var weaponGameObject = Instantiate(weapon.WeaponPrefab, _weaponParent);
        Weapon = weaponGameObject.GetComponent<Weapon>();
        Weapon.Initialize(weapon, this);
    }

    // Read and apply mouse aim
    public void UpdateAimDirection()
    {
        Vector3 aimPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        aimPos = Camera.main.ScreenToWorldPoint(aimPos);
        AimDirection = aimPos - _player.transform.position;
    }

    /// <summary>
    /// GetKey left mouse button
    /// </summary>
    /// <returns></returns>
    public bool CheckShootInput()
    {
        return Input.GetKey(KeyCode.Mouse0);
    }

    /// <summary>
    /// GetKeyDown right mouse button
    /// </summary>
    /// <returns></returns>
    public bool CheckThrowInput()
    {
        return Input.GetKeyDown(KeyCode.Mouse1);
    }
}
