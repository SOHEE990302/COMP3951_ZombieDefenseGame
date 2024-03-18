using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 씬 관리 클래스및 자료형 함수를 접근 가능
// Ui객체를 받아들여서 버튼이 눌리면 명령을 처리하겠다
// 버튼을 누르면 씬을 넘기겠다

class MainData
{
    static public int cur_Stage = 1;
}
public class TtileManager : MonoBehaviour
{
    //Exit 버튼을 눌렀을때 게임 종료
    public void Exit_Game()
    {

    }
    //New Game 버튼을 눌렀을때 처리
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
