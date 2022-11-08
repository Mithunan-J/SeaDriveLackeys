using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VN_Controller : MonoBehaviour
{
    public Image background;
    public GameObject fastforwardIcon;
    public GameObject rewindIcon;
    public List<Frame> frames;
    public Frame currentFrame;
    public Frame nextFrame;
    public int frameCounter = 0;
    public int selection = 0;
    public Sprite currentFrameSprite;
    public List<GameObject> choiceBoxes;
    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;
    public GameObject _slider;
    public bool paused = false;
    public bool enableSkip = false;
    int useSlideSwitch = 0; //0 = null, 1 = required, 2 = done
    // Start is called before the first frame update
    void Start()
    {
        currentFrame = frames[0];
        background.sprite = frames[0].frameSprites[0];
        choiceBoxes.Add(choice1);
        choiceBoxes.Add(choice2);
        choiceBoxes.Add(choice3);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D) && currentFrame.CanProceed() == true)
        {
            NextFrame();
        }
        if(Input.GetKeyDown(KeyCode.S) && currentFrame.useSlideSwitch == true)
        {
            NextFrame();
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            PreviousFrame();
        }

        if(currentFrame.dialogueChoice == true)
        {
            float sliderValue = _slider.GetComponent<Slider>().value;
            if(sliderValue <= 0.33f)
            {
                selection = 0;
                choiceBoxes[0].SetActive(true);
                choiceBoxes[1].SetActive(false);
                choiceBoxes[2].SetActive(false);
            }
            if(sliderValue > 0.33f && sliderValue <= 0.66f)
            {
                selection = 1;
                choiceBoxes[0].SetActive(false);
                choiceBoxes[1].SetActive(true);
                choiceBoxes[2].SetActive(false);
            }
            if (sliderValue > 0.66f && sliderValue <= 1f)
            {
                selection = 2;
                choiceBoxes[0].SetActive(false);
                choiceBoxes[1].SetActive(false);
                choiceBoxes[2].SetActive(true);
            }

        }
    }

    public void NextFrame()
    {
        if((frameCounter + 1) >= 0 && (frameCounter + 1) < frames.Count)
        {
            if (currentFrame.dialogueChoice == true)
            {
                LED_Controller.instance.ToggleGreenLED();
            }
            frameCounter++;
            nextFrame = frames[frameCounter];
            if (nextFrame.frameSprites.Count > 1) //checks for multi choice response
            {
                currentFrameSprite = nextFrame.frameSprites[selection];
            }
            else
            {
                currentFrameSprite = nextFrame.frameSprites[0];
            }

            if (nextFrame.dialogueChoice == true)
            {
                for (int i = 0; i < choiceBoxes.Count; i++)
                {
                    //choiceBoxes[i].SetActive(true);
                    choiceBoxes[i].GetComponentInChildren<TextMeshProUGUI>().text = nextFrame.choiceTexts[i];
                }
            }
            else
            {
                for (int i = 0; i < choiceBoxes.Count; i++)
                {
                    choiceBoxes[i].SetActive(false);
                }
            }
            UpdateFrame();
        }
        else
        {
            enableSkip = false;
            fastforwardIcon.SetActive(false);
        }
    }

    public void PreviousFrame()
    {
        if ((frameCounter - 1) >= 0 && (frameCounter - 1) < frames.Count)
        {
            frameCounter--;
            nextFrame = frames[frameCounter];
            if (nextFrame.frameSprites.Count > 1) //checks for multi choice response
            {
                currentFrameSprite = nextFrame.frameSprites[selection];
            }
            else
            {
                currentFrameSprite = nextFrame.frameSprites[0];
            }

            if (nextFrame.dialogueChoice == true)
            {
                for (int i = 0; i < choiceBoxes.Count; i++)
                {
                    choiceBoxes[i].SetActive(true);
                    choiceBoxes[i].GetComponentInChildren<TextMeshProUGUI>().text = nextFrame.choiceTexts[i];
                }
            }
            else
            {
                for (int i = 0; i < choiceBoxes.Count; i++)
                {
                    choiceBoxes[i].SetActive(false);
                }
            }
            UpdateFrame();
        }
        else
        {
            enableSkip = false;
            rewindIcon.SetActive(false);
        }
        
    }

    public void UpdateFrame()
    {
        currentFrame = nextFrame;
        if(currentFrame.dialogueChoice == true)
        {
            LED_Controller.instance.ToggleGreenLED();
        }
        if(currentFrame._clip != null)
        {
            SoundManager.instance.PlaySoundEffect(currentFrame._clip);
        }
        background.sprite = currentFrameSprite;
    }

    private IEnumerator SkipFramesForward()
    {
        while(enableSkip == true)
        {
            if (currentFrame.dialogueChoice == true || currentFrame.useSlideSwitch == true)
            {
                enableSkip = false;
                fastforwardIcon.SetActive(false);
                yield return null;
            }
            else
            {
                if (currentFrame.CanProceed() == true)
                {
                    NextFrame();
                    yield return new WaitForSeconds(1f);
                }
            }
        }                    
    }
    
    public void FastForward()
    {
        if(enableSkip == true)
        {
            enableSkip = false;
            fastforwardIcon.SetActive(false);
        }
        else
        {
            enableSkip = true;
            fastforwardIcon.SetActive(true);
            StartCoroutine(SkipFramesForward());            
        }

    }

    private IEnumerator SkipFramesBackward()
    {
        while (enableSkip == true)
        {
            PreviousFrame();
            yield return new WaitForSeconds(1f);
        }
    }

    public void Rewind()
    {
        if (enableSkip == true)
        {
            enableSkip = false;
            rewindIcon.SetActive(false);
        }
        else
        {
            enableSkip = true;
            rewindIcon.SetActive(true);
            StartCoroutine(SkipFramesBackward());
        }
    }
}
