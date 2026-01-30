using UnityEngine;

public class signeds : MonoBehaviour
{
    
    public GameObject playerCam; //Reference to the player camera for the object to rotatate towards.
    public Transform lookTarget;


    void Start()
    {
        playerCam = GameObject.Find("Player Camera");//Assigns gameobject with the name "Player Camera" 
        lookTarget = playerCam.transform;
        // cameraStuff = Camera.main.transform;
    }

    void LateUpdate()
    {
        // transform.LookAt(transform.position + cameraStuff.rotation * Vector3.forward, cameraStuff.rotation * Vector3.up);
    }
    public void Update()
    {
        transform.LookAt(lookTarget, Vector3.left);

        
    }
}