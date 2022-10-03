using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponHandler : WeaponHandler
{
    [SerializeField] private Transform _weaponParent;

    private Enemy _enemy;


    public override void Initialize(GameObject owner)
    {
        base.Initialize(owner);

        _enemy = owner.GetComponent<Enemy>();
    }

    public override void HandleWeapon()
    {
        base.HandleWeapon();
        UpdateAimDirection();
        Debug.Log("enemy handle weapon!");
    }

    public override void Fire()
    {
        Weapon?.TriggerHeld();
    }

    public override void KnockBack(Vector2 force)
    {
        _enemy.EnemyRigidbody.AddForce(force);
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
        AimDirection = _enemy.WeaponHandler._weaponParent.right;
    }
}
