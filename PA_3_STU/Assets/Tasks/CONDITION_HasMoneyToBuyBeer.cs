using UnityEngine;
using Pada1.BBCore;
using BBUnity.Conditions;


[Condition("MyConditions/HasMoneyToBuyBeer")] //name of the condition for the 
// BB engine
[Help("Ask agent's blackboard if it is possible to buy a beer")]

public class CONDITION_HasMoneyToBuyBeer : GOCondition
// GOCondition is the superclass of conditions that have access to the gameobject
{

    // only relevant method for conditions. Perform a check and return the result
    public override bool Check()
    {
        // get the blackboard. Fail + error message if no blackboard attached 
        BOB_Blackboard blackboard = gameObject.GetComponent<BOB_Blackboard>();
        if (blackboard == null)
        {
            Debug.Log("No blackboard attached to gameobject in condition CheckMoney");
            return false;
        }

        return blackboard.HasMoneyToBuyBeer();

    }
}