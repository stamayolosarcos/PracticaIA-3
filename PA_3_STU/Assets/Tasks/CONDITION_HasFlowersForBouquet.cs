using UnityEngine;
using Pada1.BBCore;
using BBUnity.Conditions;


[Condition("MyConditions/HasFlowersForBouquet")]
[Help("Does BOB have enough flowers?")]

public class CONDITION_HasFlowersForBouquet : GOCondition
// GOCondition is the superclass of conditions that have access to the gameobject
{

    // only relevant method for conditions. Perform a check and return the result
    public override bool Check()
    {
        // get the blackboard. Fail + error message if no blackboard attached 
        BOB_Blackboard blackboard = gameObject.GetComponent<BOB_Blackboard>();
        if (blackboard == null)
        {
            Debug.Log("No blackboard attached to gameobject in condition ThirstTooHigh");
            return false;
        }

        return blackboard.EnoughFlowers();

    }
}