using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Linq;
using System;

public class CodeDisplay : MonoBehaviour {
    [SerializeField] static private TextMeshPro displayText;
    TextGenerator textGen = new TextGenerator();
    ArrayList masterArr = new ArrayList();
    int indents = 0;
    string tab = "    ";

    public void UpdateText(List<int> compile, List<Block> blocks) {

        displayText.text = blocks.ToString();

    }
    private void Display() {
        string[] strings = masterArr.Cast<string>().ToArray();
        displayText.text = string.Join("", strings);
    }

    internal void StartBlock() {
        masterArr.Add(String.Concat(Enumerable.Repeat(tab, indents)) + textGen.InitalizeClass());
        indents++;
        masterArr.Add(String.Concat(Enumerable.Repeat(tab, indents)) + textGen.InitalizeMain());
        indents++;
    }

    internal void ColorBlock(Color color) {
        masterArr.Add(String.Concat(Enumerable.Repeat(tab, indents)) + textGen.ColorBlock(color));

    }

    internal void EndBlock(Block block) {
        //throw nmplementedException();
        Display();
    }

    internal void PrintBlock(Block block) {
        throw new NotImplementedException();
    }

    internal void RotateBlock(Block block) {
        throw new NotImplementedException();
    }

    internal void SizeBlock(Block block) {
        throw new NotImplementedException();
    }

    internal void VarBlock(Block block) {
        throw new NotImplementedException();
    }
}
