using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LED_Controller : MonoBehaviour
{
    public static LED_Controller instance;
    public GameObject greenLED;
    public GameObject yellowLED;
    public GameObject redLED;
    bool greenLED_on = false;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }        
    }

    private void Start()
    {
        redLED.SetActive(true);
        greenLED.SetActive(false);
        yellowLED.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.A))
        //{
        //    SlideSwitch_Controller.instance.ToggleSwitch();
        //}
    }

    private IEnumerator TurnOnYellowLight()
    {
        yellowLED.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        yellowLED.SetActive(false);
    }

    private IEnumerator TurnOnGreenight()
    {
        while(greenLED_on == true)
        {
            greenLED.SetActive(true);
            yield return new WaitForSeconds(2f);
            greenLED.SetActive(false);
            yield return new WaitForSeconds(1f);
        }        
    }

    public void InterationLED()
    {
        StartCoroutine(TurnOnYellowLight());
    }

    public void ToggleGreenLED()
    {
        if(greenLED_on == false)
        {
            greenLED_on = true;
            StartCoroutine(TurnOnGreenight());            
        }
        else
        {
            greenLED_on = false;
        }
        
    }
    
    

    
}
