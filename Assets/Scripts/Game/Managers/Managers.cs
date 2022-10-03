using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers Instance;
    public GameManager GameManager { get; private set; }

    void Start()
    {
        Instance = this;

        GameManager = GetComponent<GameManager>();
    }
}
