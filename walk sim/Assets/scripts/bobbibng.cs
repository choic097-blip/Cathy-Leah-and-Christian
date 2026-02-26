using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    public float speed = 2f; 
    public float height = 1f; 
    private float startY;

    void Start()
    {
        startY = transform.position.y;
        speed = Random.Range(0.5f,1f);
    }

    void Update()
    {
        float newY = startY + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}