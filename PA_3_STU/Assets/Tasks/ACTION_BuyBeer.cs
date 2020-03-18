using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus

[Action("MyActions/Buy beer")]
[Help("buys a beer. Pays its price. Uses agent's own blackboard")]

public class ACTION_BuyBeer : BBUnity.Actions.GOAction
{

    private BOB_Blackboard blackboard;
    // BEWARE: BOB's blackboard is not the BB engine
    // managed blackboard. 


    public override void OnStart()
    {
        blackboard = gameObject.GetComponent<BOB_Blackboard>();
        if (blackboard == null)
        {
            Debug.Log("No blackboard attached to gameobject in Action Buy Beer");
        }
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        if (blackboard == null)
        {
            Debug.Log("Buy beer fails due to lack of blackboard");
            return TaskStatus.FAILED;
        }
        else
        {
            if (blackboard.BuyBeer())
                return TaskStatus.COMPLETED;
            else
                return TaskStatus.FAILED;
        }
    }

}