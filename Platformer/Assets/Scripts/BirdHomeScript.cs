using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossBird : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 2.0f;
    public Text displayText;

    private bool isFollowing = false;

    private void Update()
    {
        if (isFollowing)
        {
            FollowPlayer();
           

        }
    }

    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player found the bird, start following
            isFollowing = true;
            displayText.text = "MASKMAN: 'BIRDY! IT'S YOU! FOLLOW ME!'";
            yield return new WaitForSeconds(3.0f);
            displayText.gameObject.SetActive(false);
        }
    }

    private void FollowPlayer()
    {
        Vector3 targetPosition = player.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
