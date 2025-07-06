using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScrollBehaviour : MonoBehaviour
{

    [Header("Button")]
    [HorizontalLine(thickness = 4, padding = 20)]
    public ButtonGroupInfo[] buttonsGroups;     //all the buttons
    public int yPosConnect;                     //y offset

    [Header("ScrollLimit")]
    [HorizontalLine(thickness = 4, padding = 20)]
    public int bottomLimit;                     //maximum bottom limit
    public int topLimit;                        //maximum top limit

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ScrollPositionDetection();

    }

    /// <summary>
    /// function to detect position of scroll and set it to create infinite effect
    /// </summary>
    public void ScrollPositionDetection()
    {
        //loop all the button group target need to be detect
        for (int i = 0; i < buttonsGroups.Length; i++)
        {
            //Debug.Log($" {buttonsGroups[i].name} {buttonsGroups[i].transform.position.y}");
            //=====> BOTTOM DETECTION 
            //if the current button hits bottom
            if (buttonsGroups[i].transform.position.y < bottomLimit)
            {
                //double checking if we set next value of i would be exceed array
                if (i + 1 <= buttonsGroups.Length - 1)
                {
                    //Debug.Log(Mathf.Abs(buttonsGroups[i].transform.position.y));
                    //moving the button ontop of the NEXT button in array
                    buttonsGroups[i].transform.position = new Vector2(buttonsGroups[i + 1].transform.position.x,
                                                                    Mathf.Abs(buttonsGroups[i + 1].transform.position.y) + yPosConnect);
                    buttonsGroups[i].nextLevelToAssign = buttonsGroups[i + 1]._stages[buttonsGroups[i + 1]._stages.Length - 1].currentLevel + 1;
                    buttonsGroups[i].OnChangeStage();
                }
                else // setting i does exceed array
                {
                    //moving the button ontop of the FIRST button in array
                    buttonsGroups[i].transform.position = new Vector2(buttonsGroups[0].transform.position.x,
                                                                    Mathf.Abs(buttonsGroups[0].transform.position.y) + yPosConnect);
                    buttonsGroups[i].nextLevelToAssign = buttonsGroups[0]._stages[buttonsGroups[0]._stages.Length - 1].currentLevel + 1;
                    buttonsGroups[i].OnChangeStage();
                }
            }
            else if (buttonsGroups[i].transform.position.y > topLimit)
            {
                
            }
        }
    }
}
