using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMusicController : MonoBehaviour
{
    public AudioSource backgroundMusic; // Reference to your background music Audio Source
    public Button muteButton; // Reference to your mute/unmute button
    public Font buttonFont;
    private bool isMuted = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the mute button state based on player preferences
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        UpdateMuteButton();

        // Attach the mute/unmute function to the button's click event
        if (muteButton != null)
        {
            muteButton.onClick.AddListener(ToggleMute);
        }
    }

    public void ToggleMute()
    {
        // Toggle the background music
        isMuted = !isMuted;
        backgroundMusic.mute = isMuted;

        // Save the mute state in player preferences
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        PlayerPrefs.Save();

        UpdateMuteButton();
    }

    private void UpdateMuteButton()
    {
        // Update the mute/unmute button's text or appearance based on the mute state
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
