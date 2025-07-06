using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [Header("ButtonGroup")]
    public ButtonGroupInfo[] buttonGroup;           //all button group avalible in scene
    private Vector3[] _buttonGroupDefaultPosition;  //all default position of each button group
    
    // Start is called before the first frame update
    void Start()
    {
        MenuInitializer();
    }

    /// <summary>
    /// function to initialize menu
    /// </summary>
    private void MenuInitializer()
    {
        //randomizing unlocked level
        int _unlockedrand = UnityEngine.Random.Range(1, 999);
        //set unlocked level to static data
        DataM.unlockedLevel = _unlockedrand;
        //declare new button group position
        _buttonGroupDefaultPosition = new Vector3[buttonGroup.Length];
        //loop all button groups
        for (int i = 0; i < _buttonGroupDefaultPosition.Length; i++)
        {
            //storage of the button position
            _buttonGroupDefaultPosition[i] = buttonGroup[i].transform.position;
        }
    }

    /// <summary>
    /// function to activate given target
    /// </summary>
    /// <param name="_target"> target to activate </param>
    public void ActivateTarget(GameObject _target)
    {
        //activating target
        _target.SetActive(true);
    }

    /// <summary>
    /// function to deactivate target
    /// </summary>
    /// <param name="_target"> target </param>
    public void DeactivateTarget(GameObject _target)
    {
        //deactivate target
        _target.SetActive(false);
    }

    public void DataReset()
    {
        //set data to 0
        DataM.unlockedLevel = 0;

        //loop all button group
        for (int i = 0; i < buttonGroup.Length; i++)
        {
            //set next level to assign back to default
            buttonGroup[i].nextLevelToAssign = buttonGroup[i].defaultLevelAssign - 1;
            //set all stages in reverse 
            buttonGroup[i].OnChangeStageReverse();
            //reset position
            buttonGroup[i].transform.position = _buttonGroupDefaultPosition[i];
        }

        //loop all button group
        for (int i = 0; i < buttonGroup.Length; i++)
        {
            //loop all the stages button inside the button group
            for (int y = 0; y < buttonGroup[i]._stages.Length; y++)
            {
                //call remove star function from those stages button
                buttonGroup[i]._stages[y].ResetStar();
            }
        }

        
    }
}
