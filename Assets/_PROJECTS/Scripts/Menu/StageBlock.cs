using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageBlock : MonoBehaviour
{
    [Header("Stage block info")]
    public TextMeshProUGUI levelText;   //level text display on screen
    public int currentLevel;            //current level
    public Image spiderWeb;        //spider web to determine whether to unlock
    public Button button;             //button itself
    public Image[] Star;
    /// <summary>
    /// function to set level value
    /// </summary>
    /// <param name="_levelValue"></param>
    public void StageBlockSetter(int _levelValue)
    {
        //if level value is 0
        if (_levelValue == 0)
        {
            //set it as tutorial text
            levelText.text = "TUTORIAL";
        }
        else // it is not value 0
        {
            //set level text
            levelText.text = $"{_levelValue}";
        }

        //set current level value
        currentLevel = _levelValue;
    }

    /// <summary>
    /// function to unlock stage button
    /// </summary>
    /// <param name="_unlocked"> determine whether the stage been unlocked </param>
    public void StageUnlocker(bool _unlocked)
    {
        //enable / disable button
        button.enabled = _unlocked;
        //activate / deactivate spiderweb
        spiderWeb.enabled = !_unlocked;
    }
}
