using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using BBUnity.Actions;

[Action("MyActions/FindInstanceWithinRadius")]
[Help("Finds a nearby instance (withing given radius) with the given tag. Fails if no instance is found. ")]

public class ACTION_FindInstanceWithinRadius : GOAction
{

    [InParam("radius")]
    public float radius;

    [InParam("tag")]
    public string tag;

    [OutParam("Instance found")] // NOTICE: OutParam
    public GameObject instance;

    public override void OnStart()
    {
        base.OnStart();
    }


    public override TaskStatus OnUpdate()
    {
		instance = SensingUtils.FindInstanceWithinRadius(gameObject, tag, radius);
        if (instance == null)
            return TaskStatus.FAILED;
        else
            return TaskStatus.COMPLETED;
    }

}