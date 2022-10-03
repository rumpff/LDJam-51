using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _muzzleEnd;

    private WeaponScriptableObject _weaponScriptable;
    private WeaponHandler _weaponHandler;

    private float _detonateTimer = 10;
    private float _cooldownTimer;

    public float NormalizedCooldown
    {
        get { return Mathf.Clamp01(_cooldownTimer / _weaponScriptable.CooldownDuration); }
    }

    public void Initialize(WeaponScriptableObject weaponScriptable, WeaponHandler weaponHandler)
    {
        _weaponScriptable = weaponScriptable;
        _weaponHandler = weaponHandler;
    }

    public void UpdateWeapon()
    {
        UpdateTimers();
    }

    void UpdateTimers()
    {
        if (_weaponHandler.ExplodingWeapons)
        {
            _detonateTimer -= Time.deltaTime;

            if (_detonateTimer < 0)
                Explode();
        }

        if (_cooldownTimer > 0)
            _cooldownTimer -= Time.deltaTime;

        DebugText.Instance.AddText($"Cooldown: {NormalizedCooldown}");
    }

    public void Explode()
    {

    }

    public void TriggerHeld()
    {
        if (_cooldownTimer <= 0)
            StartCoroutine(Shoot());
    }

    protected virtual IEnumerator Shoot()
    {
        int shotCount = _weaponScriptable.BulletAmount;
        while (shotCount > 0)
        {
            // Shoot a bullet
            var bObject = Instantiate(_weaponScriptable.BulletPrefab, _muzzleEnd.position, Quaternion.identity);
            Bullet bullet = bObject.GetComponent<Bullet>();
            bullet.Initialize(_weaponScriptable.BulletBehaviour, _weaponHandler.AimAngle);
            _weaponHandler.KnockBack(_weaponHandler.AimDirection * _weaponScriptable.KnockbackForce *-1);

            shotCount--;
            _cooldownTimer = _weaponScriptable.CooldownDuration;
            yield return new WaitForSeconds(_weaponScriptable.TimeBetweenShots);
        }

        // Prepare for next shot
        _cooldownTimer = _weaponScriptable.CooldownDuration;
    }
}
