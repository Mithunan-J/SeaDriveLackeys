using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateRemoteInput : MonoBehaviour
{
    public Animator animator;
    public GameObject led_light;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log(this.gameObject.name);
        string buttonName = this.gameObject.name;
        switch(buttonName)
        {
            case "Back Button":
                animator.SetTrigger("back_pushed");
                break;
            case "Up Button":
                animator.SetTrigger("up_pushed");
                break;
            case "Down Button":
                animator.SetTrigger("down_pushed");
                break;
            case "Right Button":
                animator.SetTrigger("right_pushed");
                break;
            case "Left Button":
                animator.SetTrigger("left_pushed");
                break;
            case "Confirmation Button":
                animator.SetTrigger("confirmation_pushed");
                break;
            case "Rewind Button":
                animator.SetTrigger("rewind_pushed");
                break;
            case "Fast Forward Button":
                animator.SetTrigger("fastforward_pushed");
                break;
        }
        StartCoroutine(LightUp());
    }

    IEnumerator LightUp()
    {        
        led_light.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        led_light.SetActive(false);        
    }
}
