using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus

[Action("MyActions/Get paid")]
[Help("Receive salary in account. Use agent's own blackboard")]

public class ACTION_GetPaid : BBUnity.Actions.GOAction
{

    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        // get the blackboard. Fail + error message if no blackboard attached 
        BOB_Blackboard blackboard = gameObject.GetComponent<BOB_Blackboard>();
        if (blackboard == null)
        {
            Debug.Log("No blackboard attached to gameobject in Get paid. Failing");
            return TaskStatus.FAILED;
        }
        else
        {
            blackboard.GetPaid();
            return TaskStatus.COMPLETED;
        }
    }
}
