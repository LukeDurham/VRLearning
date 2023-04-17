using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Linq;

public class CompilerDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshPro displayText;
    private ArrayList masterArray = new ArrayList();

    public void AddText(string str) {
        masterArray.Add(str);
    }

    public void NewLine() {
        masterArray.Add("\n");
    }
    
    public void RemoveAt(int position) {
        masterArray.RemoveAt(position);
    }

    public void Remove(string str) {
        masterArray.Remove(str);
    }

    public void UpdateText() {

        string[] strings = masterArray.Cast<string>().ToArray();

        displayText.text = string.Join("", strings);;
    }

}
