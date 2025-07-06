using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGroupInfo : MonoBehaviour
{
    public StageBlock[] _stages;    //all stage block in block group
    public int nextLevelToAssign;   //next value of stage to assign to block level
    public int defaultLevelAssign;  //default level

    // Start is called before the first frame update
    void Start()
    {
        //calling Onchange stage to change block values
        OnChangeStage();
        defaultLevelAssign = nextLevelToAssign;
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

            //checking if current stage block contains value that been unlocked
            if (_stages[i].currentLevel <= DataM.unlockedLevel)
            {
                //unlock stage
                _stages[i].StageUnlocker(true);
            }
            else //not unlocked
            {
                //lock stage
                _stages[i].StageUnlocker(false);
            }
        }

        
    }

    public void OnChangeStageReverse()
    {
        //loop all the stage blocks
        for (int i = _stages.Length - 1; i > 0; i--)
        {
            //set stage block information base on given value
            _stages[i].StageBlockSetter(nextLevelToAssign);
            //increase next level value for next stage block
            nextLevelToAssign--;
            //checking if current stage block contains value that been unlocked
            if (_stages[i].currentLevel <= DataM.unlockedLevel)
            {
                //unlock stage
                _stages[i].StageUnlocker(true);
            }
            else //not unlocked
            {
                //lock stage
                _stages[i].StageUnlocker(false);
            }
        }
    }

}

