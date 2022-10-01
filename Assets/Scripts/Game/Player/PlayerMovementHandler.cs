using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerMovementHandler : MonoBehaviour
{
    [SerializeField] private float MaxSpeed, Acceleration, DeAcceleration;

    private Player _player;
    private Vector2 _inputVector;

    public void Initialize(Player p)
    {
        _player = p;
    }

    public void HandleMovement()
    {
        ReadInput();
        ApplyVelocity();
    }

    private void ReadInput()
    {
        Vector2 rawInput = new Vector2()
        {
            x = -Convert.ToInt32(Input.GetKey(KeyCode.A)) + Convert.ToInt32(Input.GetKey(KeyCode.D)),
            y = Convert.ToInt32(Input.GetKey(KeyCode.W)) + -Convert.ToInt32(Input.GetKey(KeyCode.S))
        };

        if (rawInput == Vector2.zero)
        {
            _inputVector = Vector2.zero;
        }
        else
        {
            float inputAngle = MathF.Atan2(rawInput.y, rawInput.x);

            _inputVector = new Vector2()
            {
                x = MathF.Cos(inputAngle),
                y = MathF.Sin(inputAngle)
            };
        }
    }

    private void ApplyVelocity()
    {
        Rigidbody2D rigidbody = _player.PlayerRigidbody;
        Vector2 velocity = rigidbody.velocity;

        rigidbody.velocity = Vector2.Lerp(rigidbody.velocity, _inputVector * MaxSpeed, 10 * Time.fixedDeltaTime);
    }
}
