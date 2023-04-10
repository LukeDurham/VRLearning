using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable : MonoBehaviour
{


    /* Unmerged change from project 'Assembly-CSharp.Player'
    Before:
        public string varName;
    After:
        private string varName;
    */
    [SerializeField]
    private string varName;
    [SerializeField]
    private string value;
    [SerializeField]
    private string type;

    public string VarName { get => varName; set => varName = value; }
    public string Value { get => value; set => this.value = value; }
    public string Type { get => type; set => type = value; }


}
