using UnityEngine;
using Pada1.BBCore;
using BBUnity.Conditions;


[Condition("MyConditions/FindInstanceOfFlower")] //name of the condition for the 
// BB engine
[Help("Ask agent's blackboard if it is possible to find a flower")]

public class CONDITION_FindInstanceOfFlower : GOCondition
// GOCondition is the superclass of conditions that have access to the gameobject
{
    [OutParam("the flower found")]
    public GameObject flower;
    // only relevant method for conditions. Perform a check and return the result
    public override bool Check()
    {
        // get the blackboard. Fail + error message if no blackboard attached 
        BOB_Blackboard blackboard = gameObject.GetComponent<BOB_Blackboard>();
        if (blackboard == null)
        {
            Debug.Log("No blackboard attached to gameobject in condition FindFlower");
            return false;
        }
        flower = blackboard.FindInstanceOfFlower();
        if (flower != null) return true;
        else return false;
    }
}