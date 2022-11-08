using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    public Animator animator;
    public VN_Controller vn_controller;
    bool switchOn = false;
    float slideSwitchPoseLeftX = 0f;
    float slideSwitchPoseRightX = -0.02738123f;
    public GameObject slideSwitchComponent;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("controllerV2").GetComponent<Animator>();
        vn_controller = GameObject.Find("VN_Canvas").GetComponent<VN_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() //runs when the mouse clicks on a collider. This script needs to be attached to the object with the collider in order for this function to work.
    {
        Debug.Log(this.gameObject.name);
        string buttonName = this.gameObject.name;
        switch (buttonName)
        {
            case "OK_Button":
                if(vn_controller.paused == false)
                {
                    animator.SetTrigger("ok_pushed");
                    LED_Controller.instance.InterationLED();
                    if (vn_controller.currentFrame.CanProceed() == true)
                    {
                        vn_controller.NextFrame();
                    }
                }                
                break;
            case "Menu_Button":
                vn_controller.paused = !vn_controller.paused;
                pauseMenu.SetActive(vn_controller.paused);
                animator.SetTrigger("menu_pushed");
                LED_Controller.instance.InterationLED();
                break;
            case "Rewind_Button":
                if(vn_controller.paused == false)
                {
                    animator.SetTrigger("reverse_pushed");
                    LED_Controller.instance.InterationLED();
                    //vn_controller.PreviousFrame();
                    vn_controller.Rewind();
                }                
                break;
            case "FastForward_Button":
                if(vn_controller.paused == false)
                {
                    animator.SetTrigger("forward_pushed");
                    LED_Controller.instance.InterationLED();
                    vn_controller.FastForward();
                }                
                break;
            case "SlideSwitch":
                if(vn_controller.paused == false)
                {
                    SlideSwitch_Controller.instance.ToggleSwitch();
                    if (vn_controller.currentFrame.useSlideSwitch == true)
                    {
                        vn_controller.NextFrame();
                    }
                }                
                break;
        }
    }

    public void Rumble()
    {
        animator.SetTrigger("rumble");
    }
}
