using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Collectable object for the player, like Coins
/// </summary>
public class Coin : MonoBehaviour
{
    // Handle collisions with 3D objects
    private void OnTriggerEnter(Collider other)
    {
        Player hittenPlayer = other.GetComponent<Player>();
        if (hittenPlayer != null)
        {
            // Add a coint to the player
            hittenPlayer.AddCoin();

            // Destroy myselft
            Destroy(this.gameObject);
        }
    }
}
