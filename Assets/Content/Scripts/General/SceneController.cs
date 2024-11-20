using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    private EventSystem EventSys;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        EventSys = FindObjectOfType<EventSystem>();
    }

    void Start()
    {
        Application.targetFrameRate = -1;
    }

    public void BlockUI(bool state)
    {
        EventSys.enabled = !state;
    }
}
