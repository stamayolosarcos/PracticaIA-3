using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus

[Action("MyActions/Drink beer")]
[Help("Drinks a beer (reduce thirst...) Uses agent's own BB")]

public class ACTION_DrinkBeer : BBUnity.Actions.GOAction
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
            Debug.Log("No blackboard attached to gameobject in Drink Beer. Failing");
            return TaskStatus.FAILED;
        }
        else
        {
            blackboard.DrinkBeer();
            return TaskStatus.COMPLETED;
        }
    }

}