using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

//Zombie enum 
public enum ActionType {
    init, idle, walk, run, contact, 
    attack, drain, cooltime
} //On respond walk/run towards the target, when reach the target change the contact status

public class ZombieControl : MonoBehaviour
{
    ActionType myact;

    //status change based on time
    float action_time;

    GameObject Find_obj; //find object
    Base_Control obj_logic; //conect source

    Animator my_ani;


    // Start is called before the first frame update
    void Start()
    {
        action_time = 0;
        myact = ActionType.init;
        Find_obj = GameObject.Find("Player_Base");
        obj_logic = Find_obj.GetComponent<Base_Control>(); //??? ?? ?????? ????? ???? ??? ??
        print("Find_obj" + Find_obj.tag);
        //Obtain information from Zombie's animation and control it in its code
        my_ani = this.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        print("Status: " + myact);
        Enemy_Action();
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
    void Enemy_Action()
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
                obj_logic.Damaged(2.5f);

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
