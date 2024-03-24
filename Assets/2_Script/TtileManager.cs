using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Accessing thin management classes and data-type functions
// I'll accept the Ui object and process the order when the button is pressed
// If you press the button, I'll turn over the scene

class MainData
{
    static public int cur_Stage = 1;
    //
    static public int m_coin = 0; // the coins gained after destroying the enemy
    static public float m_AttPow; //the main character's aggressive power
    static public float m_baselife = 100;
    //operational information
    static public float music_vol = 1f; //Background music volume
    static public float sfc_vol = 1f; //Sound effect sound volume
                                      //pause상태 체크
    static public bool is_pause = false; //Status variable to create a pause
    static public int max_enemy = 5;
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
