using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMake : MonoBehaviour
{
    public Transform spawnPoint;
    // public GameObject zombie; //Unshaped objects
    public Transform zombie2; //a tangible object
    bool is_making = true; //making zombie?

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(zombie); //Create a prefab object

    }

    // Update is called once per frame
    void Update()
    {
        if (is_making == true)
        {
            StartCoroutine("MakeJombie"); // MakeJombie();
        }
    }
    //Coroutine: How to call a function
    //Use multiprocessing techniques. a - a'
    // to be independent of the call function
    //Function
    IEnumerator MakeJombie()
    {
        is_making = false;
        yield return new WaitForSeconds(1.5f); //When the condition is satisfied, the following syntax is performed // the standby part
                                               //The performance of the logic
                                               //The performance of the logic
        Vector3 temp = Vector3.zero;
        temp.z = Random.Range(-5, 5);
        Instantiate(zombie2, spawnPoint.position + temp, spawnPoint.rotation);
        is_making = true;
    }
}
