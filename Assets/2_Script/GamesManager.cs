using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamesManager : MonoBehaviour
{
    public Transform spawnPoint; //sapwnpoint
    public Transform zombie; //a tangible object
    bool is_make_Enemy = true; //making zombie?
    int MakingNum = 5;
    int MakeCount = 0;
    int KillCount = 0;
    public Text txt_StageNum;

    // ??? ??? ????
    GameObject Find_obj; // Find a subject
    Base_Control obj_logic; // Associate the source with the corresponding variable

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
        Find_obj = GameObject.Find("Player_Base");
        obj_logic = Find_obj.GetComponent<Base_Control>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowUI();
        print("Current Stage: " + MainData.cur_Stage);
        print("killed emeny: " + KillCount);
        Make_Enemy(); //Make a emeny
        Char_Recog(); //Delete Touch-type Red Stations - Recognition
        Rule_Check(); //check game rule
    }
    void Rule_Check()
    {
        //Clear Conditions
        if (KillCount == MakingNum)
        {
            NextScene_Market();
        }
        if (obj_logic.mylife <= 0)
        {
            NextScene_Over();
        }
    }




    void Char_Recog()
    {
        if (Input.GetMouseButtonDown(0) == true) //0 <- left / 1,2 <- middle, right
        {
            Ray screenray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit other;
            if (Physics.Raycast(screenray, out other, 20f) == true)
            {
                //You need to check what is the correct object
                print("There's a guy who got hit" + other.transform.name);
                if (other.transform.tag == "Enemy")
                {
                    KillCount++;
                    Destroy(other.transform.gameObject);
                }
            }
            else
            {
                print("No one has been hit");

            }
        }
    }

    void Make_Enemy()
    {
        if (is_make_Enemy == true && MakeCount < MakingNum)
        {
            StartCoroutine("MakeJombie"); // MakeJombie();
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

    void ShowUI()
    {
        txt_StageNum.text = "" + MainData.cur_Stage;
    }
}
