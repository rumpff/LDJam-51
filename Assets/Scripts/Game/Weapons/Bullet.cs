using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private BulletBehaviour _behaviour;
    public void Initialize(BulletBehaviour behaviour, float aimAngle)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _behaviour = behaviour;

        // Apply Behaviour
        float speed = _behaviour.InitialSpeed + Random.Range(-_behaviour.SpeedRandom, _behaviour.SpeedRandom);
        float angle = aimAngle + Random.Range(-_behaviour.AimRandom, _behaviour.AimRandom);

        _rigidbody.velocity = new Vector2()
        {
            x = Mathf.Cos(angle) * speed,
            y = Mathf.Sin(angle) * speed
        };
    }
}
