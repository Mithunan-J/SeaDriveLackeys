using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject led_light;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            led_light.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            led_light.SetActive(false);
        }
    }
}
