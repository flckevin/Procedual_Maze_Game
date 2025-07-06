using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [Header("ButtonGroup")]
    public ButtonGroupInfo[] buttonGroup;
    public Vector3[] buttonGroupDefaultPosition;
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
        buttonGroupDefaultPosition = new Vector3[buttonGroup.Length];
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
        DataM.unlockedLevel = 0;

        for (int i = 0; i < buttonGroup.Length; i++)
        {
            buttonGroup[i].nextLevelToAssign = buttonGroup[i].defaultLevelAssign - 1;
            buttonGroup[i].OnChangeStageReverse();
            
        }

        for (int i = 0; i < buttonGroup.Length; i++)
        {
            for (int y = 0; y < buttonGroup[i]._stages.Length; y++)
            {
                buttonGroup[i]._stages[y].ResetStar();
            }
        }
    }
}
