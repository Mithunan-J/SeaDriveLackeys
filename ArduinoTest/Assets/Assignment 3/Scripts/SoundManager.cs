using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip lightSwitch;
    public AudioClip partyHorn;
    public AudioClip happyBirthday;
    public AudioClip lightSwitchAndPartyHorn;
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

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayLightSFX()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = lightSwitch;
        audioSource.Play();
    }

    public void PlayPartyHornSFX()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = partyHorn;
        audioSource.Play();
    }

    public void PlayHappyBirthdaySFX()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = happyBirthday;
        audioSource.Play();
    }

    public void PlayLightSwitchAndPartyHornSFX()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = lightSwitchAndPartyHorn;
        audioSource.Play();
    }

    public void PlaySoundEffect(AudioClip _clip)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = _clip;
        audioSource.Play();
    }
}
