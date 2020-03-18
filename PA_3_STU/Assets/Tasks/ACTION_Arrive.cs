using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using BBUnity.Actions;		  // actions with "gameobject"

using Steerings;

[Action("MyActions/Arrive")]  // name of the action for BB engine
[Help("Goes to (ARRIVES) a specified location (target)")]

public class ACTION_Arrive : GOAction  // inherit from GOAction
// to have access to the gameobject
// Beware: GOActions ARE NOT MonoBehaviours
{

    [InParam("target")] // name of the "input" parameter for BB engine
    public GameObject target;

    [InParam("closeEnough")] // name of the "input parameter" for BB...
    public float closeEnough;

    private Arrive arrive;

    // BB engine OnStart method (equivalent to Start of MonoBehaviours)
    public override void OnStart()
    {
        base.OnStart();

        arrive = gameObject.GetComponent<Arrive>();
        arrive.target = target;
        arrive.closeEnoughRadius = closeEnough;  // onUpdate will also take care of this
        arrive.enabled = true;
    }


    // BB engine OnUpdate method
    public override TaskStatus OnUpdate()
    {
        if (SensingUtils.DistanceToTarget(gameObject, target) <= closeEnough)
        {
            arrive.enabled = false;
            return TaskStatus.COMPLETED; // COMPLETED = SUCCESSFUL termination
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
        arrive.enabled = false;
    }

}