using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Accessing thin management classes and data-type functions
// I'll accept the Ui object and process the order when the button is pressed
// If you press the button, I'll turn over the scene

// using for save files
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

//save data files 
[Serializable]
class saveData
{
    public int   cur_Stage; //saved stage
    public float music_vol; //saved volume
    public float sfx_vol; //saved volume

    public float m_baselife; //saved baselife
    public float m_maxlife; //saved maxlife
    public float m_AttPow; //saved attack power(upgraded)
    public int   m_coin; //saved money
}
class MainData
{
    static public int cur_Stage = 1;
    //
    static public int m_coin = 0; // the coins gained after destroying the enemy
    static public float m_AttPow = 0.8f; //the main character's aggressive power
    static public float m_baselife = 100;
    static public float m_maxlife = 100; 
    //operational information
    static public float music_vol = 0.7f; //Background music volume
    static public float sfx_vol = 0.5f; //Sound effect sound volume
                                      //pause상태 체크
    static public bool is_pause = false; //Status variable to create a pause
    static public int max_enemy = 2;
}
//추후에 디자인 패턴을 생각해야함
public enum GameState //States to enter when playing the game
{
    init,
    Ready, //cut the time by -1
    Go, //The first letter comes out when it's zero
    Spawn, //the creation of enemy forces
    Play,
    Fail,
    Clear,
    GameOver,
    GoMarket
}
public class TtileManager : MonoBehaviour
{
    //Exit the game when you press the Exit button
    public void Exit_Game()
    {

    }
    //Processing when you press the New Game button
    public void New_Gane()
    {
        SceneManager.LoadScene("2_Game_Scene");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("Current Stage: "+ MainData.cur_Stage);
    }
}
