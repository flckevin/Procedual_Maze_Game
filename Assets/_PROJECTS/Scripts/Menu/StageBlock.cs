using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageBlock : MonoBehaviour
{
    [Header("Stage block info")]
    public TextMeshProUGUI levelText;   //level text display on screen
    public int currentLevel;            //current level
    public GameObject spiderWeb;        //spider web to determine whether to unlock

    /// <summary>
    /// function to set level value
    /// </summary>
    /// <param name="_levelValue"></param>
    public void StageBlockSetter(int _levelValue)
    {
        //set level text
        levelText.text = $"{_levelValue}";
        //set current level value
        currentLevel = _levelValue;
    }
}
