using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus

[Action("MyActions/Count flower")]
[Help("Count flower for bouquet. Use agent's own blackboard")]

public class ACTION_CountFlower : BBUnity.Actions.GOAction
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
            blackboard.flowers++;
            return TaskStatus.COMPLETED;
        }
    }
}
