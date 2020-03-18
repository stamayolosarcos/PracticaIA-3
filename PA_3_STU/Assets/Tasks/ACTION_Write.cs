using UnityEngine;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus

[Action("MyActions/Write")]
[Help("writes the string in the given line (a gameObject with a Text Mesh attached)")]

public class ACTION_Write : BBUnity.Actions.GOAction
{

    [InParam("Line")]
    public GameObject line;
    [InParam("text")]
    public string text;

    private TextMesh tm;

    public override void OnStart()
    {
        base.OnStart();

        // get the Text Mesh component of line
        if(line!=null)
            tm = line.GetComponent<TextMesh>();

    }

    // Main class method, invoked by the execution engine.
    public override TaskStatus OnUpdate()
    {
        if (tm == null)
            Debug.Log("No line/textMesh in write. Succeeding, anyway");
        else
        {
            tm.text = text;
        }
        return TaskStatus.COMPLETED;

    } // OnUpdate

}