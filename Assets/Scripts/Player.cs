using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float strength = 5f;
    private float gravity = -9.81f;
    //public float tilt = 5f;

    private Vector3 direction;



    private void OnEnable()
    {
        // get the position of the player game object 
        Vector3 position = transform.position;
        position.y = 0f;
        // update the position of the player at the start of the game
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        // space or left mouse or up arrow is clicked 
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            // change the postion/jump up with the specified strength amount
            // velocity = 0 
            direction = Vector3.up * strength;
        }

        // incase nothing was click -> make player go down by the force of gravity 
        // Apply gravity and update the position
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        // Tilt the player based on the direction
       /* Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;*/
    }


    // for triggering the box colliders2D
     void OnTriggerEnter2D(Collider2D other)
    {
        // For Ground collider & Sky collider & Wood Prefab colliders (Upper wood collider & Lower wood collider)
        if (other.gameObject.CompareTag("Obstacle"))
        {
            // FindObjectOfType is not the best way
            // method in GameManager class 
            FindObjectOfType<GameManager>().GameOver();
            
        }
        // For Scoring collider (in between upper and lower woods colliders)
        else if (other.gameObject.CompareTag("Scoring"))
        {
            // method in GameManager class 
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

    

}
