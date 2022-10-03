using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public WeaponScriptableObject Weapon;
    [SerializeField] private Transform _modelParent;

    void Start()
    {

    }

    void Update()
    {

    }

    public void PickedUp()
    {
        Destroy(gameObject);
    }
}
