using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLogic : MonoBehaviour
{
    ptivate AudioSource finishlevel;
    void Start()
    {
        finishlevel = GetComponent<AudioSource>();
        
    }
private void OnTriggerEnter2D(Collider 2D collision)
{
if (collision.gameObject.name == "Player") 
{
    finishlevel.Play();
    LevelEnd();
}
}
 private void LevelEnd () 
 {

 }
    
}
