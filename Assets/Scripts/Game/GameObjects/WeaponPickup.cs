using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public bool AutoInitialize = false;
    public bool IsDetonating = false;
    public float DetonateTimer;
    public WeaponScriptableObject Weapon;
    [SerializeField] private Transform _modelParent;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _triggerCollider;

    public void Initialize()
    {
        Instantiate(Weapon.WeaponPrefab, _modelParent);
        StartCoroutine(DisableTriggerForASec());
    }

    public void Initialize(float detonateTime)
    {
        Instantiate(Weapon.WeaponPrefab, _modelParent);

        IsDetonating = true;
        DetonateTimer = detonateTime;

        StartCoroutine(DisableTriggerForASec());
    }

    void Start()
    {
        if(AutoInitialize)
            Initialize();
    }

    void Update()
    {
        _modelParent.localPosition = new Vector3()
        {
            z = Mathf.Cos(Time.time * 2) * 0.25f
        };

        if (IsDetonating)
        {
            if(DetonateTimer < 0)
                Explode();

            DetonateTimer -= Time.deltaTime;
        }
    }

    public void AddForce(Vector2 force)
    {
        _rigidbody.AddForce(force);
    }

    public void PickedUp()
    {
        Destroy(gameObject);
    }

    public void Explode()
    {
        Destroy(gameObject);
    }

    IEnumerator DisableTriggerForASec()
    {
        _triggerCollider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        _triggerCollider.enabled = true;
    }
}
