using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float knockbackForce = 5f;
    [SerializeField] private float respawnDelay = 0.5f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
                rb.linearVelocity = knockbackDirection * knockbackForce;
            }

            Invoke(nameof(RespawnPlayer), respawnDelay);
        }
    }

    private void RespawnPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = respawnPoint.position;
        }
    }
}
