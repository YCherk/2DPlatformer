using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMusicController : MonoBehaviour
{
    public AudioSource backgroundMusic; 
    public Button muteButton; 
    public Font buttonFont;
    private bool isMuted = false;

    
    void Start()
    {
        
        UpdateMuteButton();

        
        if (muteButton != null)
        {
            muteButton.onClick.AddListener(ToggleMute);
        }
    }

    public void ToggleMute()
    {
        // Toggle background music
        isMuted = !isMuted;
        backgroundMusic.mute = isMuted;

        // Updatemute/unmute button text
        UpdateMuteButton();
    }

    private void UpdateMuteButton()
    {
        // Update mute/unmute button's text based on the mute state
        if (muteButton != null)
        {
            Text buttonText = muteButton.GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                buttonText.text = isMuted ? "Unmute" : "Mute";
                buttonText.font = buttonFont;
            }
        }
    }
}
