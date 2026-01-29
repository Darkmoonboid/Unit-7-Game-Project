using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [Tooltip("Target position to teleport to")]
    public Transform targetLocation;

    [Tooltip("Optional: Reset velocity if object has Rigidbody")]
    public bool resetVelocity = true;

    /// <summary>
    /// Teleports the given GameObject to the target location.
    /// </summary>
    public void ForceTeleport(GameObject obj)
    {
        if (targetLocation == null)
        {
            Debug.LogError("No target location assigned for teleport!");
            return;
        }

        // If the object has a Rigidbody, reset velocity if needed
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null && resetVelocity)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        // Move the object instantly
        obj.transform.position = targetLocation.position;
        obj.transform.rotation = targetLocation.rotation;
    }

    // Example: Trigger-based teleport
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Only teleport player
        {
            Debug.Log("force teleport");
            ForceTeleport(other.gameObject);
        }
    }
}
