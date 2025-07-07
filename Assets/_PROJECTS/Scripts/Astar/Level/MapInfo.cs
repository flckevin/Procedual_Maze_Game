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
                    //connect current node to neighbour
                    allNode[i].ConnectNode(allNode[j]);
                    //connect neighbour to current node
                    allNode[j].ConnectNode(allNode[i]);
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
}
