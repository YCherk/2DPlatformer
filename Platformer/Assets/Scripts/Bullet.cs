using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    private Vector3 bulletDirection;

    void Update()
    {
        // Move the bullet in the specified direction
        transform.Translate(bulletDirection * bulletSpeed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        bulletDirection = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Terrain"))
        {
            Destroy(gameObject);
        }
    }
}