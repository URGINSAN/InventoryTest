using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMessager : MonoBehaviour
{
    public static GameMessager instance;
    public GameObject MessageGO;
    public Transform Parent;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void ShowMessage(string message)
    {
        Message messageGO = Instantiate(MessageGO, Parent).GetComponent<Message>();
        messageGO.SetText(message);
    }
}
