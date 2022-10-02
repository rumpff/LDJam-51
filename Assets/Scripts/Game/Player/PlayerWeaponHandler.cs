using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeaponHandler : WeaponHandler
{
    public Vector2 AimDirection { get; private set; }

    public float AimAngle
    {
        get
        {
            Vector2 playerPos = (Vector2)_player.transform.position;
            return Mathf.Atan2(AimDirection.y - playerPos.y, AimDirection.x - playerPos.x);
        }
    }

    private Player _player;

    public override void Initialize(GameObject owner)
    {
        base.Initialize(owner);

        AimDirection = Vector2.zero;

        _player = owner.GetComponent<Player>();
        UnArm();
    }

    public override void HandleWeapon()
    {
        base.HandleWeapon();
        UpdateAimDirection();
    }

    public override void Fire()
    {

    }

    // Read and apply mouse aim
    public void UpdateAimDirection()
    {
        Vector3 aimPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        aimPos = Camera.main.ScreenToWorldPoint(aimPos);
        AimDirection = aimPos - _player.transform.position;

        Debug.Log(AimAngle * Mathf.Rad2Deg);
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
