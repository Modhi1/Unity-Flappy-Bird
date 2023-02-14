using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class is for creating woods that are placed randomly on the y axis
public class Spawner : MonoBehaviour
{

    // ref to Woods prefab
    [SerializeField]
    private GameObject prefab;

    // rate for spawning prefab
    [SerializeField]
    private float spawnRate = 1f;

    // for the range that will be used to randomly place the wood 
    [SerializeField]
    private float minHeight = 2f;
    [SerializeField]
    private float maxHeight = 8f;

    // array of wood prefab
    public Woods[] wood; 


    // when start the game + player didn't lose yet
    // when script is enabled 
    private void OnEnable()
    {
        // stop after 15 spawns, 
        //                 methodName,   time   , repeatRate
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);

      //  wood[1].gameObject.SetActive(false);

      // create 15 woods using for loop
      // save them into array
      // set them into avtive 
    }

    // when player losses
    // when script is disabled 
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));

        // set the prefab inside the array to inActive
        // also set it inactive in woods movement
    }


    private void Spawn()
    {
        // Quaternion.identity means no rotation
        //                           gameObject,    position     , rotation
        GameObject woods = Instantiate(prefab, transform.position, Quaternion.identity);

        // change the position randomly on the y axis 
        woods.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);


    }
}
