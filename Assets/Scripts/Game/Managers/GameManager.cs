using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _weaponPickupPrefab;
    public Player Player => _player;
    public GameObject WeaponPickupPrefab => _weaponPickupPrefab;
}
