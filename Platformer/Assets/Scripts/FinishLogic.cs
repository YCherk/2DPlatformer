using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLogic : MonoBehaviour
{
    private AudioSource finishlevel;
    void Start()
    {
        finishlevel = GetComponent<AudioSource>();
        
    }
private void OnTriggerEnter2D(Collider2D collision)
{
if (collision.gameObject.name == "Player") //tag for player if they collide with end checkpoint
{
    finishlevel.Play();
    LevelEnd();
}
}
 private void LevelEnd () 
 {
        //loads next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

 }
    
}
