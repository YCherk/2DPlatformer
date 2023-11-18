using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlText : MonoBehaviour
{
    [SerializeField] private Text hintText;
    [SerializeField] private float hintDisplayTime = 3.0f;

    private bool isDisplayingHint = false;
    private float hintDisplayTimer = 0.0f;

    private void Start()
    {
        // Hide the hint text initially
        hintText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isDisplayingHint)
        {
            hintDisplayTimer += Time.deltaTime;

            if (hintDisplayTimer >= hintDisplayTime)
            {
                // Hide the hint text after the specified time
                hintText.gameObject.SetActive(false);
                isDisplayingHint = false;
                hintDisplayTimer = 0.0f;
            }
        }
    }

    public void ShowOrangeHint()
    {
        // Set the hint text
        hintText.text = "Virtual Guy: You lost Birdy again??? Get to the checkpoint to look for him in the next Pixel World. Dont forget to get him fruits. Good Luck!";

        // Show the hint text
        hintText.gameObject.SetActive(true);

        isDisplayingHint = true;
    }

   
}
