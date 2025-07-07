using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    public Node startNode;                         //start node
    public Node targetNode;                        //goal node ai need to reach
    public List<Node> allNode = new List<Node>();  //all node in the level
    public AIBehaviour AI;                         //the ai itself

    public void MapInitialize()
    {
        NodeConnection();
        AStarAIInitialize();
    }

    private void NodeConnection()
    {
        //get a node
        for (int i = 0; i < allNode.Count; i++)
        {
            //get all neighbours except the current one
            for (int j = i + 1; j < allNode.Count; j++)
            {
                //if the distance between neightbour is not far
                if (Vector2.Distance(allNode[i].transform.position, allNode[j].transform.position) <= 1f)
                {
                    //loop all removed all in first cell
                    for (int iRW = 0; iRW < allNode[i].mazeCell.removedWall.Count; iRW++)
                    {
                        //loop all removed all in second cell
                        for (int jRW = 0; jRW < allNode[j].mazeCell.removedWall.Count; jRW++)
                        {
                            //if they all have opposite sides
                            if (OppositeCheck(allNode[i].mazeCell.removedWall[iRW], allNode[j].mazeCell.removedWall[jRW], allNode[i].mazeCell, allNode[j].mazeCell) == true)
                            {
                                //connect current node to neighbour
                                allNode[i].ConnectNode(allNode[j]);
                                //connect neighbour to current node
                                allNode[j].ConnectNode(allNode[i]);
                            }
                        }
                    }
                    

                }
            }
        }
    }

    private void AStarAIInitialize()
    {
        //setup node
        AStarManager.Instance.allNode = allNode;
        //assign target node to AI
        AI.targetNode = targetNode;
        //assign start node to AI
        AI.currentNode = startNode;
        //enable AI
        AI.enabled = true;

    }

    //I have no idea how i come up with this thing but for some reason it works with my pathfinding framework
    //without in need of spawning obstecles block
    private bool OppositeCheck(Direction _firstDirection, Direction _secondDirection, MazeCell _cell1, MazeCell _cell2)
    {
        if (_firstDirection == Direction.Right && _secondDirection == Direction.Left
            && _cell1.transform.position.x == _cell2.transform.position.x - 1)
        {
            return true;

        }
        else if (_firstDirection == Direction.Left && _secondDirection == Direction.Right
                && _cell1.transform.position.x == _cell2.transform.position.x + 1)
        {

            return true;
        }
        else if (_firstDirection == Direction.Top && _secondDirection == Direction.Bot
                && _cell1.transform.position.y == _cell2.transform.position.y - 1)
        {
            return true;
        }
        else if (_firstDirection == Direction.Bot && _secondDirection == Direction.Top
                && _cell1.transform.position.y == _cell2.transform.position.y + 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
