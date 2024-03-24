using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Base_Control : MonoBehaviour
{
    public Text base_life;
    // Start is called before the first frame update
    public float mylife = MainData.m_baselife;

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
        MainData.m_baselife -= att_power;
        if (mylife <= 0)
        {
            mylife = 0;
            MainData.m_baselife = 0;
        }
    }
}
