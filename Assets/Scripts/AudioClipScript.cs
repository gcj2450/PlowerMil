using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipScript : MonoBehaviour
{
    public static AudioClipScript UiClip = new AudioClipScript();

    public AudioSource audioSource = new AudioSource();
    public AudioClip buttonAudio, coinAudio, winAudio, loseAudio, startAudio, chestAudio, switchAudio;
    public GameObject awardScreen, coinScreen;
    bool controlMute = false;
    bool controlWin = false;
    bool controlAward = false;
    bool controlLevel = false;
    bool controlLose = false;
    bool controlCoin = false;

    private void Awake()
    {
        UiClip = this;
        
    }

    void Update()
    {
        if (!controlMute)
        {      
            if (UIManager.ui.winScreen.activeInHierarchy && !controlWin)
            {
                audioSource.clip = winAudio;
                audioSource.Play();
                controlWin = true;
            }
            else if (!UIManager.ui.winScreen.activeInHierarchy)
            {
                controlWin = false;
            }

            if (UIManager.ui.loseScreen.activeInHierarchy && !controlLose)
            {
                audioSource.clip = loseAudio;
                audioSource.Play();
                controlLose = true;

            }
            else if (!UIManager.ui.loseScreen.activeInHierarchy)
            {
                controlLose = false;
            }


            if (UIManager.ui.levelScreen.activeInHierarchy && !controlLevel)
            {
                audioSource.clip = startAudio;
                audioSource.Play();
                controlLevel = true;

            }
            else if (!UIManager.ui.levelScreen.activeInHierarchy)
            {
                controlLevel = false;
            }
            if (awardScreen.activeInHierarchy && !controlAward)
            {
                audioSource.clip = winAudio;
                audioSource.Play();
                controlAward = true;
            }
            else if (!awardScreen.activeInHierarchy)
            {
                controlAward = false;
            }

            if (coinScreen.activeInHierarchy && !controlCoin)
            {
                audioSource.clip = coinAudio;
                audioSource.Play();
                controlCoin = true;
            }
            else if (!coinScreen.activeInHierarchy)
            {
                controlCoin = false;
            }
        }
    }
    public void Mute()
    {
        controlMute = true;
    }
    public void Unmute()
    {
        controlMute = false;
    }
    public void ButtonClip()
    {
        if (!controlMute)
        {
            audioSource.clip = buttonAudio;
            audioSource.Play();
        }
    }
    public void CoinClip()
    {
        if (!controlMute)
        {
            audioSource.clip = coinAudio;
            audioSource.Play();
        }

    }
    public void StartClip()
    {
        if (!controlMute)
        {
            audioSource.clip = startAudio;
            audioSource.Play();
        }
    }
    public void LoseClip()
    {
        if (!controlMute)
        {
            audioSource.clip = loseAudio;
            audioSource.Play();
        }
    }
    public void ChestClip()
    {
        if (!controlMute)
        {
            audioSource.clip = chestAudio;
            audioSource.Play();
        }
    }
    public void SwitchClip()
    {
        if (!controlMute)
        {
            audioSource.clip = switchAudio;
            audioSource.Play();
        }
    }


}
