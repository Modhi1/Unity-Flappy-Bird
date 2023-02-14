using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class id responsible of the movement of the woods on the x axis
public class Woods : MonoBehaviour
{
    private Transform top;
    private Transform bottom;

    // speed of the wood prefab when moving 
    [SerializeField]
    private float speed = 5f;

    // a reference to destroy the wood prefab when reached (in future -> inActive)
    private float leftEdge;

    private void Start()
    {
        // Vector3.zero -> the left side
        // reference the left side of the camera (to know)
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    // updated for every frame
    private void Update()
    {
        // change position of the wood
        // make it move to the left side
        transform.position += Vector3.left * speed * Time.deltaTime;

        // if the woods exceeds the left edge
        if (transform.position.x < leftEdge)
        {
            // Future -> set wood to inActive 
            Destroy(gameObject);
        }
    }
}
