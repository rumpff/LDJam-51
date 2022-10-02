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

        _rigidbody.drag = behaviour.Drag;

        StartCoroutine(LifetimeKill(behaviour.Lifetime));
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                {
                    if (_behaviour.DestroyOnKill)
                        Kill();
                }
                break;

            case "Enemy":
                {
                    if (_behaviour.DestroyOnKill)
                        Kill();
                }
                break;

            default:
                {
                    if(_behaviour.DestroyOnImpact)
                        Kill();
                }
                break;
        }
    }

    private IEnumerator LifetimeKill(float length)
    {
        yield return new WaitForSeconds(length);
        Kill();
    }
}
