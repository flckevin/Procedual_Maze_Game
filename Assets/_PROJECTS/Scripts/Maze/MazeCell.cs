using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    public GameObject[] cellWalls;      //all the 4 corner walls and a whole block 
    public Dictionary<Direction, GameObject> cellWallsDict = new Dictionary<Direction, GameObject>(); //dictionary storing all cell so can be access by ID
    public bool cellVisited;            //boolean marking whether cell visited
    public List<Direction> removedWall;    //list of wall that been removed

    /// <summary>
    /// function to initialize cell
    /// </summary>
    public void CellInitialize()
    {
        //loop all cell walls
        for (int i = 0; i < cellWalls.Length; i++)
        {
            //add those cell walls into dictionary
            cellWallsDict.Add(IDToEnum(cellWalls[i].name), cellWalls[i]);
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
        ClearWall(Direction.Block);
    }

    /// <summary>
    /// function to clear wall by ID
    /// </summary>
    /// <param name="_wallID"> wall side ID </param>
    public void ClearWall(Direction _wallID)
    {
        //deactivating wall ID
        cellWallsDict[_wallID].SetActive(false);
        if (_wallID != Direction.Block)
        {
            removedWall.Add(_wallID);
        }

    }

    public Direction IDToEnum(string _ID)
    {
        switch (_ID)
        {
            case "LeftWall":
                return Direction.Left;
            case "RightWall":
                return Direction.Right;
            case "TopWall":
                return Direction.Top;
            case "BottomWall":
                return Direction.Bot;
        }

        return Direction.Block;
    }
}

public enum Direction
{
    Right,
    Left,
    Top,
    Bot,
    Block
}

