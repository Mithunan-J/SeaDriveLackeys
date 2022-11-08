using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{
    public int choice = 0;

    public void ReturnChoice()
    {
        GameObject vn_canvas = GameObject.Find("VN_Canvas");
        vn_canvas.GetComponent<VN_Controller>().selection = choice;
        vn_canvas.GetComponent<VN_Controller>().NextFrame();
    }
}
