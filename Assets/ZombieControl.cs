using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Zombie enum 
public enum ActionType { init, idle, walk, run, contact} //On respond walk/run towards the target, when reach the target change the contact status

public class ZombieControl : MonoBehaviour
{
    ActionType myact;

    //status change based on time
    float action_time;

    // Start is called before the first frame update
    void Start()
    {
        action_time = 0;
        myact = ActionType.init;
    }

    // Update is called once per frame
    void Update()
    {
        print("Status: " +  myact);
        Enemy_Action();
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
                if(action_time >= 1.5f) //idle 1.5 sec
                {
                    action_time = 0;
                    myact = ActionType.walk;
                }
                break; 
            case ActionType.walk: //zombie walk
                this.transform.Translate(Vector3.forward * Time.deltaTime * 1.5f);
                action_time += Time.deltaTime;
                if (action_time >= 3.5f) //walk 3.5 sec
                {
                    action_time = 0;
                    myact = ActionType.run;
                }
                break;
            case ActionType.run: //zombie run
                this.transform.Translate(Vector3.forward * Time.deltaTime * 5f);
                break;
            case ActionType.contact: //zombie contacts target
                break;
        }

    }
}
