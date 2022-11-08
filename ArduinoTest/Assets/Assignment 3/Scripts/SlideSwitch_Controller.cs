using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideSwitch_Controller : MonoBehaviour
{
    public static SlideSwitch_Controller instance;
    public GameObject offTab;
    public GameObject onTab;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSwitch()
    {
        offTab.SetActive(!offTab.activeSelf);
        onTab.SetActive(!onTab.activeSelf);
    }

}
