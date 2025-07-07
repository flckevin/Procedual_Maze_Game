using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Quocanh.pattern;
public class AStarManager : QuocAnhSingleton<AStarManager>
{
    public List<Node> allNode;            //storage of all node
   

   
    public List<Node> GeneratedPath(Node _startNode, Node _endNode)
    {
        //list of keep track which node we are finding
        List<Node> openList = new List<Node>();

        // //get all node
        foreach(Node _n in allNode)
        {
            //set g to max value to that the AI knows that it will start generate path again
            _n.gScore = float.MaxValue;
        }

        #region SETUP

        //set start node to 0 so that ai know that it already at the node itself
        _startNode.gScore = 0;
        //set value of h for end node using distance calculation between start and end
        _endNode.hScore = Vector2.Distance(_startNode.transform.position,_endNode.transform.position);
        //add the first node into the tracking list
        openList.Add(_startNode);

        #endregion

        #region A* Initiate
        Debug.Log($"OPEN list count {openList.Count}");
        while(openList.Count > 0)
        {
            Debug.Log("IN LOOP");
            //storing the node that has lowest f value which is path is nearer to the target
            int lowestF = default;
            //get a node from open list
            for(int i = 1; i < openList.Count; i ++)
            {
                //comparing all the path to the current node has lowest F
                //if the current item has the lower F
                if(openList[i].FScore() < openList[lowestF].FScore())
                {
                    //get the    
                    lowestF = i;
                }
            }

            //get the lowest node
            Node _currentNode = openList[lowestF];
            //stop tracking that node
            openList.Remove(_currentNode);
            //if the current node have reach to the end
            if (_currentNode == _endNode)
            {
                //create a new list containing final path
                List<Node> _closedList = new List<Node>();

                //insert path with backtracking
                _closedList.Insert(0, _endNode);
                //if current node havent reach back to the start
                while (_currentNode != _startNode)
                {
                    //set the current node back to the origin
                    _currentNode = _currentNode.core;
                    //then add it to final path
                    _closedList.Add(_currentNode);
                }

                //reverse the path so we can go in order
                _closedList.Reverse();

                //return the path to the AI
                return _closedList;
            }
            else { Debug.Log($"stuck at {_currentNode} to {_endNode}?"); }

            //neighbour checking
            foreach (Node connectedNode in _currentNode.neighbours)
            {
                //comparing G score between current node and neighbour node
                float heldGScore = _currentNode.gScore + Vector2.Distance(_currentNode.transform.position, connectedNode.transform.position);
                //if the calculated G score is less than connected node g score
                if (heldGScore < connectedNode.gScore)
                {
                    //if it is the most optimal path
                    //update the connected node
                    connectedNode.core = _currentNode;
                    connectedNode.gScore = heldGScore;
                    connectedNode.hScore = Vector2.Distance(connectedNode.transform.position, _endNode.transform.position);
                    //checking if open list not contain this node
                    if (!openList.Contains(connectedNode))
                    {
                        //add the node into it
                        openList.Add(connectedNode);
                    }
                }
            }
        }

        #endregion

        Debug.Log($"NULL for {_startNode} + {_endNode} path");
        //default return if there is nothing
        return null;
    }
    
}
