using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugText : MonoBehaviour
{
    private TextMeshPro _textMesh;
    public static DebugText Instance;
    private string _debugText;

    void Start()
    {
        Instance = this;
        _textMesh = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        _textMesh.text = _debugText;
        _debugText = "";
    }
    public void AddText(string text)
    {
        _debugText += (text + "\n");
    }
}
