using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dead Zone that handle when the player loose his life
/// </summary>
public class DeadZone : MonoBehaviour
{
    [SerializeField]
    Transform _respawnPosition;

    /// <summary>
    /// When the player hit the dead zone, loose a life.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Player hittenPlayer = other.GetComponent<Player>();
        if (hittenPlayer != null)
        {
            // Player loose a life
            hittenPlayer.Damage();

            // Before moving the player on start we NEED to
            // set the character velocity to zero, otherwise
            // we continue to fall down to quickly
            CharacterController cc = hittenPlayer.GetComponent<CharacterController>();
            if (cc)
            {
                // WE LOCK THE PLAYER MOTION
                cc.enabled = false;

                // We re-enable the player cc after 1 second
                StartCoroutine(ReEnablePlayerCC(cc));

            }

            // Move the player on the start position
            hittenPlayer.transform.position = _respawnPosition.position;

            

        }
    }

    // Coroutine that re-enable the player CharacterController after 1 second.
    IEnumerator ReEnablePlayerCC(CharacterController controller)
    {
        // Skip one frame
        yield return null;

        // Wait half second
        yield return new WaitForSeconds(0.5f);

        controller.enabled = true;
    }

}
