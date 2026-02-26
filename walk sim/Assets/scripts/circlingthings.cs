using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;


public class circlingthings : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    public float radius = 1f;
    public float angle = 0f;
    void Start() 
    {
        angle = Random.Range(1f,360f);
        speed = Random.Range(0.9f, 1.5f);
    }
    void Update()
    {
        float x = target.position.x;
        float y = target.position.y + Mathf.Cos(angle) * radius;
        float z = target.position.z + Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, y, z);

        angle += speed * Time.deltaTime;
    }
}
