using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextInputUpdator : MonoBehaviour
{
    private Text _textDisplay;

    private void Awake()
    {
        _textDisplay = GetComponent<Text>();    
    }

    public void UpdateText(string newText)
    {
        _textDisplay.text = newText;
    }

    public string GetString()
    {
        return _textDisplay.text;
    }

}
