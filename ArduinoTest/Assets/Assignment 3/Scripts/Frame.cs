using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    public string frameName;
    public List<Sprite> frameSprites;
    public bool dialogueChoice = false;
    public string choice1Text;
    public string choice2Text;
    public string choice3Text;
    public List<string> choiceTexts;
    public bool useSlideSwitch = false;
    public AudioClip _clip;
    // Start is called before the first frame update
    void Start()
    {
        choiceTexts.Add(choice1Text);
        choiceTexts.Add(choice2Text);
        choiceTexts.Add(choice3Text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanProceed()
    {
        if(useSlideSwitch == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
