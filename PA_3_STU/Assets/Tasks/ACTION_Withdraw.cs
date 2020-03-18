using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus

[Action("MyActions/Withdraw")]
[Help("Withdraws money from account (= moves from account to pocket)")]

public class ACTION_Withdraw : BBUnity.Actions.GOAction
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
            Debug.Log("No blackboard attached to gameobject in withdraw. Failing");
            return TaskStatus.FAILED;
        }
        else
        {
            if (blackboard.MakeWithdrawal())
                return TaskStatus.COMPLETED;
            else
                return TaskStatus.FAILED;
        }
    }

}
