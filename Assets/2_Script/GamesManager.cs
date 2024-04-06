using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class GamesManager : MonoBehaviour
{
    public Transform spawnPoint; //sapwnpoint
    public Transform zombie; //a tangible object

    public Transform hit_effect; //zombie hit effect

    public int MakeCount = 0;
    public int KillCount = 0;

    public Text txt_StageNum;
    public Text txt_Coins; 
    public Slider Base_energy;
    public Slider music_vols;
    public Slider sfx_vols;
    public GameObject Gun_Sound;
    public GameObject UI_fail; //Fail UI
    public GameObject UI_Clear; //Clear UI
    AudioSource bgm_mucis; //background music
    AudioSource sfx_gun;

    float logic_time = 0; //internal time for the function
    bool is_make_Enemy = true; //making zombie?
    GameObject Find_obj; // Find a subject
    Base_Control obj_logic; // Associate the source with the corresponding variable

    GameState g_state;

    public void NextScene_Market()//move to the next scene when this is called
    {
        SceneManager.LoadScene("4_Market_Scene");
    }

    public void NextScene_Over()//move to the next scene when this is called
    {
        SceneManager.LoadScene("3_Over_Scene");
    }

    // Start is called before the first frame update
    void Start()
    {
        initData();
        ShowUI();
        
    }


    void initData()
    {
        g_state = GameState.init;
        bool is_make_Enemy = true;
        int MakeCount = 0;
        int KillCount = 0;
        Find_obj = GameObject.Find("Player_Base");
        obj_logic = Find_obj.GetComponent<Base_Control>();
        music_vols.value = MainData.music_vol;
        sfx_vols.value = MainData.sfx_vol;
        //Sound Playback
       // sfx_gun = Gun_Sound.GetComponentInChildren<AudioSource>();
       // sfx_gun.loop = false;
      //  sfx_gun.playOnAwake = false;

        bgm_mucis = this.GetComponent<AudioSource>();
        bgm_mucis.loop = true;
        bgm_mucis.playOnAwake = false;
        bgm_mucis.volume = MainData.music_vol;
        bgm_mucis.Play();
        print("vol" + MainData.music_vol + "    " + MainData.sfx_vol);
        MainData.ui_click = false;
    }

    // Update is called once per frame
    void Update()
    {
        ShowUI();
        Pause_Check();
        print("Current Stage: " + MainData.cur_Stage);
        //if(MainData.is_pause != true)
        {
            print("killed emeny: " + KillCount);
            //Make_Enemy(); //Make a emeny
            Char_Recog(); //Delete Touch-type Red Stations - Recognition
            //Rule_Check(); //check game rule
        }
        Game_Rule();
    }

    void Game_Rule()
    {
        switch (g_state)
        {
            case GameState.init:
                g_state = GameState.Spawn;
                break;
            case GameState.Ready:
                break;
            case GameState.Spawn:
                Make_Enemy();
                break;
            case GameState.Play:
                Rule_Check();
                break;
            case GameState.Fail:
                logic_time += Time.deltaTime;

                if(logic_time >= 2f)
                {
                    UI_fail.gameObject.SetActive(false);
                    logic_time = 0;
                    NextScene_Over();
                }
                break;
            case GameState.Clear:
                logic_time += Time.deltaTime;

                if (logic_time >= 2f)
                {
                    UI_Clear.gameObject.SetActive(false);
                    logic_time = 0;

                    SaveGame(); //save before we move to scene
                    NextScene_Market();
                }
                break;

        }
    }

    //for saving current data
    void SaveGame()
    {
        saveData psave = new saveData(); //new save data 

        psave.cur_Stage  = MainData.cur_Stage;
        psave.m_baselife = MainData.m_baselife;
        psave.m_coin     = MainData.m_coin;
        psave.m_AttPow   = MainData.m_AttPow; 
        psave.m_maxlife  = MainData.m_maxlife;
        psave.max_enemy = MainData.max_enemy;

        psave.music_vol = MainData.music_vol;
        psave.sfx_vol = MainData.sfx_vol;

        //saving process
        FileStream fs = new FileStream("save.dat", FileMode.Create); // new file for save
        //serialize/formatter
        BinaryFormatter bf = new BinaryFormatter(); //getting binary formatter ready
        bf.Serialize(fs, psave);
        fs.Close();

    }

    void Make_Enemy()
    {
        if (is_make_Enemy == true && MakeCount < MainData.max_enemy) // Since we make zombies from zero, the actual number -1
        {
            StartCoroutine("MakeJombie"); // MakeJombie();
        }
        if (MakeCount >= MainData.max_enemy)
        {
            UnityEngine.Debug.Log("max_enemy"+ MainData.max_enemy+ " " + MakeCount);
            g_state = GameState.Play;
        }
    }

    void Rule_Check()
    {
        //Clear Conditions
        if (KillCount == MainData.max_enemy)
        {
            g_state = GameState.Clear;
            UI_Clear.gameObject.SetActive(true);

        }
        if (MainData.m_baselife <= 0)
        {
            UI_fail.gameObject.SetActive(true);
            g_state = GameState.Fail;
        }
    }


    void Pause_Check()
    {
        if (MainData.is_pause == true)
        {
            Time.timeScale = 0f;
            bgm_mucis.Pause();
        }
        else
        {
            Time.timeScale = 1f;
            bgm_mucis.volume = MainData.music_vol;
            bgm_mucis.UnPause();
        }
    }




    void Char_Recog()
    {
        if (Input.GetMouseButtonDown(0) == true) //0 <- left / 1,2 <- middle, right
        {
          //  sfx_gun.volume = MainData.sfx_vol;
          //  sfx_gun.Play();
            Ray screenray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit other;
            if (Physics.Raycast(screenray, out other, 25f) == true)
             {
                //You need to check what is the correct object
                print("There's a guy who got hit" + other.transform.name);
                if (other.transform.tag == "Enemy")
                {
                    //ZombieControl src = other.transform.gameObject.GetComponent<ZombieControl>();
                    //src.Damaged(MainData.m_AttPow);

                    other.transform.SendMessage("Damaged", MainData.m_AttPow);
                    //KillCount++;
                    //Destroy(other.transform.gameObject);
                }
                if(MainData.ui_click == false)//ui? ????? ??
                {
                    Instantiate(hit_effect, other.point, Quaternion.identity); 
                }

            }
            else
            {
                print("No one has been hit");

            }
        }
    }


    IEnumerator MakeJombie()
    {
        is_make_Enemy = false;
        yield return new WaitForSeconds(1.5f); //When the condition is satisfied, the following syntax is performed // the standby part
                                               //The performance of the logic
                                               //The performance of the logic
        Vector3 temp = Vector3.zero;
        temp.z = Random.Range(-5, 5);
        Instantiate(zombie, spawnPoint.position + temp, spawnPoint.rotation);
        is_make_Enemy = true;
        MakeCount++;
    }

    public void Set_VolM()
    {
        MainData.music_vol = music_vols.value;
    }
    public void Set_VolS()
    {
        MainData.sfx_vol = sfx_vols.value;
    }

    void ShowUI()
    {
        txt_StageNum.text = "" + MainData.cur_Stage;
        Base_energy.value = MainData.m_baselife;
        Base_energy.maxValue = MainData.m_maxlife;
        txt_Coins.text = "" + MainData.m_coin;
    }

    public void On_Pause()
    {
        print("pause");
        MainData.is_pause = true;
        MainData.ui_click = true;
    }

    public void On_Resume()
    {
        Invoke("UI_Restore", 0.2f);

        MainData.is_pause = false;

    }
    void UI_Restore()
    {
        MainData.ui_click = false;
    }
}
