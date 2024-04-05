using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Base_Control : MonoBehaviour
{
    public Text base_life;
    // Start is called before the first frame update
    public float mylife = MainData.m_baselife;

    public GameObject blood_canvas; //player hit effect

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
        blood_canvas.gameObject.SetActive(true);
        Invoke("resume_blood",0.2f);
        MainData.m_baselife -= att_power;
        if (mylife <= 0)
        {
            mylife = 0;
            MainData.m_baselife = 0;
        }
    }

    void resume_blood()
    {
        blood_canvas.gameObject.SetActive(false);
    }
}


