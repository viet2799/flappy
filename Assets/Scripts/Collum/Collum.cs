using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collum : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    float deadZone;

    private void Start()
    {
        deadZone = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        CollumMove();
    }
   

    void CollumMove()
    {
        transform.position += Vector3.left * Time.deltaTime;
        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
