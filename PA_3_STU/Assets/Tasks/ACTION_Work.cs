using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using BBUnity.Actions;		  // actions with "gameobject"
using FSM;

using Steerings;

[Action("MyActions/Work")]  // name of the action for BB engine
[Help("Goes to work")]

public class ACTIOM_Work : GOAction  // inherit from GOAction
// to have access to the gameobject
// Beware: GOActions ARE NOT MonoBehaviours
{
    private FSM_BobWork bobWork;

    // BB engine OnStart method (equivalent to Start of MonoBehaviours)
    public override void OnStart()
    {
        base.OnStart();

        bobWork = gameObject.GetComponent<FSM_BobWork>();
        bobWork.enabled = true;
        bobWork.ReEnter();
    }


    // BB engine OnUpdate method
    public override TaskStatus OnUpdate()
    {
        if (bobWork.currentState == FSM_BobWork.State.TERMINATED)
        {
            bobWork.Exit();
            return TaskStatus.COMPLETED; // COMPLETED = SUCCESSFUL termination
        }
        else if (bobWork.currentState == FSM_BobWork.State.FAILED)
        {
            bobWork.Exit();
            return TaskStatus.FAILED;
        }
        else
        {
            return TaskStatus.RUNNING;  // RUNNING = not COMPLETED yet
        }
    }

    // what to do if task is aborted while running
    public override void OnAbort()
    {
        base.OnAbort();
        bobWork.Exit();
    }

}