using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Components
    public PlayerMovementHandler PlayerMovement { get; private set; }
    public WeaponHandler PlayerWeapon { get; private set; }
    public Rigidbody2D PlayerRigidbody { get; private set; }
    public PlayerAnimationController PlayerAnimationController { get; private set; }
    private IPlayerState _state;

    void Start()
    {
        // Get all components   
        PlayerMovement = GetComponent<PlayerMovementHandler>();
        PlayerWeapon = GetComponent<WeaponHandler>();
        PlayerRigidbody = GetComponent<Rigidbody2D>();

        // Initialize components
        PlayerMovement.Initialize(this);
        PlayerWeapon.Initialize(gameObject);
    }

    public void Initialize()
    {

    }

    void Update()
    {
        //_state.OnUpdate();
        PlayerWeapon.HandleWeapon();
        
    }

    void FixedUpdate()
    {
        //_state.OnFixedUpdate();
        PlayerMovement.HandleMovement();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WeaponPickup")
        {
            DebugText.Instance.AddText("WE ARE IN PICKUP!!!");
            if (PlayerWeapon.State.GetType() == typeof(PWeaponUnArmedState))
            {
                WeaponPickup wPickup = collision.gameObject.GetComponent<WeaponPickup>();
                PlayerWeapon.WeaponPickup(new PWeaponWieldingState(this), wPickup.Weapon);
                wPickup.PickedUp();
            }
        }
    }
}
