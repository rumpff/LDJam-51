using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public bool AutoInitialize = false;
    public WeaponScriptableObject Weapon;
    [SerializeField] private Transform _modelParent;

    public void Initialize()
    {
        Instantiate(Weapon.WeaponPrefab, _modelParent);
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
    }

    public void PickedUp()
    {
        Destroy(gameObject);
    }
}
