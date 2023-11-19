using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCounter : MonoBehaviour
{
    private int CherryCounter = 0;
    private int OrangeCounter = 0;
    [SerializeField] private Text CherriesText;
    [SerializeField] private Text OrangesText;

    [SerializeField] private Text PineapplesText;

    [SerializeField] private AudioSource CollectItem;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private HintController hintController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
            {
            Destroy(collision.gameObject);
            CherryCounter++;
            CherriesText.text = "Cherries: " + CherryCounter;
            CollectItem.Play();

        }

        if (collision.gameObject.CompareTag("Orange"))
        {
            Destroy(collision.gameObject);
            OrangeCounter++;
            OrangesText.text = "Oranges: " + OrangeCounter;
            CollectItem.Play();
            playerMovement.CollectOrange();
            hintController.ShowOrangeHint();
        }

        

    }
}
