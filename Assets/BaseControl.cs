using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Base_Control : MonoBehaviour
{
    public Text base_life;
    // Start is called before the first frame update
    public float mylife = 100;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        base_life.text = "" + mylife;
    }
    // damage function
    public void Damaged(float att_power)
    {
        mylife -= att_power;
        if (mylife <= 0) mylife = 0;
    }
}
