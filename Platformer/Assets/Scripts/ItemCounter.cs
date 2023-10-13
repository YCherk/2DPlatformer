using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCounter : MonoBehaviour
{
    private int CherryCounter = 0;
    private int OrangeCounter = 0;
    private int PineappleCounter = 0;
    [SerializeField] private Text CherriesText;
    [SerializeField] private Text OrangesText;
    [SerializeField] private Text PineapplesText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
            {
            Destroy(collision.gameObject);
            CherryCounter++;
            CherriesText.text = "Cherries: " + CherryCounter;

        }

        if (collision.gameObject.CompareTag("Orange"))
        {
            Destroy(collision.gameObject);
            OrangeCounter++;
            OrangesText.text = "Oranges: " + OrangeCounter;

        }

        if (collision.gameObject.CompareTag("Pineapple"))
        {
            Destroy(collision.gameObject);
            PineappleCounter++;
            PineapplesText.text = "Pinepples: " + PineappleCounter;

        }

    }
}
