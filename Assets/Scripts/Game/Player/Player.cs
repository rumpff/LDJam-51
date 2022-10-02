using System.Collections;
using System.Collections.Generic;
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
}
