using UnityEngine;
using System.Collections;


public class SpeedPowerup : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 2f;  // Speed multiplier

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TopDownMovement playerMovement = other.GetComponent<TopDownMovement>();
            if (playerMovement != null)
            {
                playerMovement.IncreaseSpeed(speedMultiplier);  // Increase player speed permanently
            }
            gameObject.SetActive(false);  // Deactivate powerup after collection
        }
    }
}
