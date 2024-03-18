using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MarketManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("Current Stage: " + MainData.cur_Stage);
    }
    public void NextSence()
    {
        
    }
    public void GoNextStage()
    {
        MainData.cur_Stage += 1;
        SceneManager.LoadScene("2_Game_Scene");
    }
}
