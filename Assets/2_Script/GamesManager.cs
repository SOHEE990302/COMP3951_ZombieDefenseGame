using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamesManager : MonoBehaviour
{

    public Text txt_StageNum;


    public void NextScene()//move to the next scene when this is called
    {
        SceneManager.LoadScene("4_Market_Scene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowUI();
        print("Current Stage: " + MainData.cur_Stage);
    }

    void ShowUI()
    {
        txt_StageNum.text = ""+ MainData.cur_Stage;
    }
}
