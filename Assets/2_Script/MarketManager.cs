using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using System.Globalization;
using System;

public class MarketManager : MonoBehaviour
{
    public Text val_coin;
    public Text val_repair;
    public Text val_upgrade;

    //control buttons
    public Button btn_Repair;
    public Button btn_Upgrade;

    public int repair;  //repair cost
    public int upgrade; //upgrade cost

    public void Show_Market()
    {
        //cost logic

        //output
        val_coin.text = ""+MainData.m_coin;
        val_repair.text = repair.ToString();
        val_upgrade.text = upgrade.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Show_btnState()
    { 
        if(MainData.m_coin >= repair)
        {
            btn_Repair.interactable = true;
        }else
        {
            btn_Repair.interactable = false;
        }

        if (MainData.m_coin >= upgrade)
        {
            btn_Upgrade.interactable = true;
        }
        else
        {
            btn_Upgrade.interactable = false;
        }
    }      

    // Update is called once per frame
    void Update()
    {
        Calculate_Cost();
        Show_Market();
        Show_btnState();
        print("Current Stage: " + MainData.cur_Stage);
        print("Current Base life" + MainData.m_baselife);
    }

    public void go_Repair()
    {
        MainData.m_coin -= repair;
        MainData.m_baselife = 100;
    }

    public void go_Upgrade()
    {
        MainData.m_coin -= upgrade;
        MainData.m_AttPow += 0.3f;
    }

    public void Calculate_Cost()
    {
        repair = 700;
        upgrade = 1000;
    }
    public void GoNextStage()
    {
        MainData.cur_Stage += 1;
        MainData.max_enemy += 1;
        SceneManager.LoadScene("2_Game_Scene");
    }
}
