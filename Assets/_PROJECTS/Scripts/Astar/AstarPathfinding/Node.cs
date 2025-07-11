using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Node core; //the original Node
    public List<Node> neighbours; //all nearby node that can be connect
    public float gScore; //value of how many move it takes to get to it node prefer to be call goal node score
    public float hScore; // value of estimate cost from the current node position to the end node position aka heuristic score
    public MazeCell mazeCell;//to check which wall is blocking way so we won't connect to neighbour
    /// <summary>
    /// Function to calculate Fscore for final destination which is F = G + H
    /// </summary>
    /// <returns></returns>
    public float FScore()
    {
        //returning the final destination value
        return gScore + hScore;
    }

    public void ConnectNode(Node _node)
    {
        //if given node is itself then stop
        if (_node == this || neighbours.Contains(_node)) return;
        //add it into neighbour
        neighbours.Add(_node);
    }

    // /// <summary>
    // /// function to draw line on gizmo to visualize which neighbour are being connect to current neighbour
    // /// </summary>
    // void OnDrawGizmos()
    // {
    //     //get color
    //     Gizmos.color = Color.green;

    //     //checking if there are any neighbour connected
    //     if(neighbours.Count > 0)
    //     {
    //         //if there are
    //         //get all the neighbour in the list
    //         for(int i = 0 ; i < neighbours.Count;i++)
    //         {
    //             //drawline from the current neighbour to the current neighbour that being in the list
    //             Gizmos.DrawLine(this.transform.position,neighbours[i].transform.position);
    //         }
    //     }
    // }
}
