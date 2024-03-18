using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//with the Camara info do scroll
public class CamScroll : MonoBehaviour
{
    public Camera mycam;
    public float speed = 15f;
    public int dir_x;

    // Start is called before the first frame update
    void Start()
    {
        speed = 15f;
        dir_x = 0;
    }

    void Scroll_Cam()
    {
        mycam.transform.position += Vector3.right * speed * Time.deltaTime * dir_x;
        //mycam.transform.Translate() one possible way
        //moving usign the current position and speed/ keybind with directions

        //Mathf.Clamp() restricting the value with in the boundaries.
        Vector3 temppos = mycam.transform.position;
        temppos.x = Mathf.Clamp(mycam.transform.position.x, -30, 30);
        mycam.transform.position = temppos;
    }

    // Update is called once per frame
    void Update()
    {
        Scroll_Cam();
    }

    public void Btn_Scroll_L()
    {
        dir_x = -1;
    }

    public void Btn_Scroll_R()
    {
        dir_x = 1;
    }

    public void Btn_Scroll_Up()
    {
        dir_x = 0; ;
    }
}
