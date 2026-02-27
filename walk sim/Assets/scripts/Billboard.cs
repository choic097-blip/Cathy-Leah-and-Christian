using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform mainCameraTransform;

    void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        Vector3 direction = mainCameraTransform.position - transform.position;

        direction.y = 0;


        transform.rotation = Quaternion.LookRotation(-direction);
    }
}