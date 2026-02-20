using UnityEngine;

public class RespawnSC : MonoBehaviour
{
    [Header("Setting")]
    public Vector3 respawnPoint;

    private CharacterController controller;
    private Rigidbody rb;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        if (controller != null)
        {
            controller.enabled = false;
        }

        transform.position = respawnPoint;

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero; 
            rb.angularVelocity = Vector3.zero; 
        }

        if (controller != null)
        {
            controller.enabled = true;
        }

        Debug.Log("Respawned to: " + respawnPoint);
    }
}