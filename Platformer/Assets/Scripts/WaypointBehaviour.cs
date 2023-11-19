using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaformBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] wp;
    private int CurrentWPIndex = 0;
    [SerializeField] private float Speed = 2.0f;



    
    private void Update()
    {
        if (Vector2.Distance(wp[CurrentWPIndex].transform.position, transform.position) < .1f)
        {
            CurrentWPIndex++;
            if(CurrentWPIndex >= wp.Length)
            {
                CurrentWPIndex = 0;
            }
        }


        transform.position = Vector2.MoveTowards(transform.position, wp[CurrentWPIndex].transform.position, Time.deltaTime * Speed);
    }
}
