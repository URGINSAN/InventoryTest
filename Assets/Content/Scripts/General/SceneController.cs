using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    private EventSystem EventSys;
    public float Timer;
    public float StandbyTime = 60;

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

    private void Update()
    {
        //if (MenuController.instance != null)
        {
            //if (MenuController.instance.WindowType.Equals("Entry") || MenuController.instance.WindowType.Equals(""))
            {
                Timer = 0;
                return;
            }

            Timer += 1 * Time.deltaTime;

            if (Timer > StandbyTime)
            {
                Timer = 0;
            }

            if (Input.GetMouseButton(0))
                Timer = 0;
        }
    }

    public void BlockUI(bool state)
    {
        EventSys.enabled = !state;
    }
}
