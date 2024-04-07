using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using UnityEngine;

//Zombie enum 
public enum ActionType {
    init, idle, walk, run, contact, 
    attack, drain, cooltime
} //On respond walk/run towards the target, when reach the target change the contact status

public class ZombieControl : MonoBehaviour
{
    public ActionType myact;

    //status change based on time
    public float action_time;

    public GameObject Find_obj; //find object
    public Base_Control obj_logic; //conect source

    public GameObject die_effect; //zombie die effect


    public Animator my_ani;

    public float m_life; //zombie(monster life)
    public float matt_power; //zombie attack power


    // Start is called before the first frame update
    void Start()
    {
        action_time = 0;
        myact = ActionType.init;
        Find_obj = GameObject.Find("Player_Base");
        obj_logic = Find_obj.GetComponent<Base_Control>(); //??? ?? ?????? ????? ???? ??? ??
        print("Find_obj" + Find_obj.tag);
        //Obtain information from Zombie's animation and control it in its code
        init_Data();
    }

    void init_Data()
    {
        //upgrading zombies as the stages go up
        m_life = 1f + (MainData.cur_Stage*0.2f); //zombie health
        matt_power = 0.6f + (MainData.cur_Stage * 0.2f); //zombie attack power

        my_ani = this.GetComponentInChildren<Animator>();
        myact = ActionType.init;
    }

    // Update is called once per frame
    void Update()
    {
        print("Status: " + myact);
        Enemy_Action();
    }
    public void Damaged(float att_power)
    {
        m_life -= att_power;

        if (m_life <= 0)
        {
            // 여기서 null 참조 예외가 발생할 수 있습니다.
            // 예를 들어, die_effect가 Inspector에서 할당되지 않았다면 Instantiate 시도 시 예외가 발생할 수 있습니다.
            if (die_effect != null)
            {
                Instantiate(die_effect, this.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogError("die_effect is not set!");
            }

            // 게임 매니저 또는 다른 컴포넌트에 대한 참조가 필요하다면, null 체크를 해야 합니다.
            // 예: GamesManager src = GameObject.Find("Game_Manager").GetComponent<GamesManager>();
            // if (src != null) { /* 로직 처리 */ }

            Destroy(gameObject); // 게임 오브젝트 파괴
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player_Base")
        {
            myact = ActionType.contact;
            Vector3 curpos = this.transform.position;
            this.transform.position = new Vector3(curpos.x - 0.1f, curpos.y, curpos.z);
            my_ani.SetTrigger("Cooltime");
        }
    }
    public void Enemy_Action()
    {
        switch (myact)
        {
            case ActionType.init:
                myact = ActionType.idle;

                break;
            case ActionType.idle: //zombie idle for 1 second
                action_time += Time.deltaTime;
                if (action_time >= 0.8f) //idle 1.5 sec
                {
                    action_time = 0;
                    myact = ActionType.walk;
                    //So that the animation changes to walk
                    my_ani.SetTrigger("Walk");
                }
                break;
            case ActionType.walk: //zombie walk
                this.transform.Translate(Vector3.forward * Time.deltaTime * 1.5f);
                action_time += Time.deltaTime;
                if (action_time >= 3.5f) //walk 3.5 sec
                {
                    action_time = 0;
                    myact = ActionType.run;
                    my_ani.SetTrigger("Run");
                }
                break;
            case ActionType.run: //zombie run
                this.transform.Translate(Vector3.forward * Time.deltaTime * 5f);
                break;
            case ActionType.contact:
                myact = ActionType.cooltime; //zombie contacts target
                break;
            case ActionType.attack:
                    action_time += Time.deltaTime;
                if(action_time >= 1.1f)
                {
                    action_time = 0;
                    myact = ActionType.drain;
                    my_ani.SetBool("is_Attack", false);
                }
                break;
            case ActionType.drain:
                //increase base life
                obj_logic.Damaged(matt_power);

                myact = ActionType.cooltime;
                break;
            case ActionType.cooltime:
                action_time += Time.deltaTime;
                if(action_time >= 1.7f)
                    {
                    action_time = 0;
                    myact = ActionType.attack;

                    my_ani.SetBool("is_Attack", true);
                }
                break;
        }

    }
}
