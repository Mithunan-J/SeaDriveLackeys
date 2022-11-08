using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdrityDebugScript : MonoBehaviour
{
    // Invoked when a line of data is received from the serial device.
    int counter = 0;
    void OnMessageArrived(string msg)
    {
        counter++;
        Debug.Log(counter);
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        //if(success)
        //{
        //    Debug.Log("It worked.");
        //}
        //else
        //{
        //    Debug.Log("It didn't work.");
        //}
        
    }
}
