using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus


[Action("MyActions/SetTag")]
[Help("sets (changes) the tag of an object")]

public class Action_SetTag : BBUnity.Actions.GOAction
{

    [InParam("object the tag of which has to be set")]
    [Help("The object the tag of which has to be set")]
    public GameObject target;

    [InParam("the new tag")]
    public string tag;


    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        if (target == null) return TaskStatus.FAILED;
        else
        {
            target.tag = tag;
            return TaskStatus.COMPLETED;
        }
    }

}