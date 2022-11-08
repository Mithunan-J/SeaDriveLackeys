using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteInputs : MonoBehaviour
{
    public AnimationClip backButton;
    public AnimationClip upButton;
    public AnimationClip downButton;
    public AnimationClip leftButton;
    public AnimationClip rightButton;
    public AnimationClip confirmButton;
    public AnimationClip rewindButton;
    public AnimationClip fastForwardButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<Animation>().Play(backButton.ToString());
            //GetComponent<Animator>().Play(backButton);
        }
    }
}
