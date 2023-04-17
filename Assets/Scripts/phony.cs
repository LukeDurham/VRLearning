using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class phony : MonoBehaviour
{

    [SerializeField]
    private TextMeshPro _textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeText() {

        _textMeshPro.text = "Compiler Error";

    }
} 

