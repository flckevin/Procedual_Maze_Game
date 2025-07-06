using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGroupInfo : MonoBehaviour
{
    public StageBlock[] _stages;    //all stage block in block group
    public int nextLevelToAssign;   //next value of stage to assign to block level

    // Start is called before the first frame update
    void Start()
    {
        //calling Onchange stage to change block values
        OnChangeStage();
    }
    
    /// <summary>
    /// function to change stage block informations
    /// </summary>
    public void OnChangeStage()
    {
        //loop all the stage blocks
        for (int i = 0; i < _stages.Length; i++)
        {
            //set stage block information base on given value
            _stages[i].StageBlockSetter(nextLevelToAssign);
            //increase next level value for next stage block
            nextLevelToAssign++;
        }
    }
}
