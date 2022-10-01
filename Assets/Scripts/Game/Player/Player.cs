using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Components
    public PlayerMovementHandler PlayerMovement { get; private set; }
    public PlayerWeaponHandler PlayerWeapon { get; private set; }
    public Rigidbody2D PlayerRigidbody { get; private set; }

    private IPlayerState _state;

    void Start()
    {
        // Get all components   
        PlayerMovement = GetComponent<PlayerMovementHandler>();
        PlayerWeapon = GetComponent<PlayerWeaponHandler>();
        PlayerRigidbody = GetComponent<Rigidbody2D>();

        PlayerMovement.Initialize(this);
    }


    void Update()
    {
        //_state.OnUpdate();
        
    }

    void FixedUpdate()
    {
        //_state.OnFixedUpdate();
        PlayerMovement.HandleMovement();
    }
}
