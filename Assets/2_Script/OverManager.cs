using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Btn_Continue()
    {
        SceneManager.LoadScene("2_Game_Scene");
    }
    public void Btn_GoTilte()
    {
        SceneManager.LoadScene("1_Ttile_Scene");
    }
}
