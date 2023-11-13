using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 2.0f;
    public float flyOffTime = 10.0f;
    public Text displayText;
    public Text display1Text;
    private void Start()
    {
        StartCoroutine(FollowPlayer());
    }

    IEnumerator FollowPlayer()
    {
        while (true)
        {
            Vector3 targetPosition = player.position;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void Update()
    {
        flyOffTime -= Time.deltaTime;

        if (flyOffTime <= 0)
        {
            StartCoroutine(FlyOff());
            displayText.gameObject.SetActive(true);
            displayText.text = "MASK MAN: 'DONT LEAVE ME BIRDY!'";
        }
    }

    IEnumerator FlyOff()
    {
        float elapsedTime = 0f;
        Vector3 startPos = transform.position;

        while (elapsedTime < 1.0f)
        {
            transform.position = Vector3.Lerp(startPos, startPos + new Vector3(10f, 5f, 0f), elapsedTime);
            elapsedTime += Time.deltaTime / 2.0f;
            yield return null;
        }

        yield return new WaitForSeconds(5.0f);
        displayText.gameObject.SetActive(false);
        Destroy(gameObject);
        display1Text.text = "Enter Checkpoint to find Birdy.";
    }
}
