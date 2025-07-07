using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    public GameObject[] cellWalls;      //all the 4 corner walls and a whole block 
    public Dictionary<string,GameObject> cellWallsDict = new Dictionary<string,GameObject>(); //dictionary storing all cell so can be access by ID
    public bool cellVisited;            //boolean marking whether cell visited
    
    /// <summary>
    /// function to initialize cell
    /// </summary>
    public void CellInitialize()
    {
        //loop all cell walls
        for (int i = 0; i < cellWalls.Length; i++)
        {
            //add those cell walls into dictionary
            cellWallsDict.Add(cellWalls[i].name, cellWalls[i]);
        }
    }

    /// <summary>
    /// function to mark cell as visited
    /// </summary>
    public void VisitedMark()
    {
        //set bollean to true so map generation can be identify as visited cell
        cellVisited = true;
        //clearing the block
        ClearWall("UnvisitedBlock");
    }

    /// <summary>
    /// function to clear wall by ID
    /// </summary>
    /// <param name="_wallID"> wall side ID </param>
    public void ClearWall(string _wallID)
    {
        //deactivating wall ID
        cellWallsDict[_wallID].SetActive(false);
    }
}
