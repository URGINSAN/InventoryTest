using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : UIMover
{
    [SerializeField] private Text MessageText;
   
    public void SetText(string _text)
    {
        MessageText.text = _text;
    }
}
