using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    public Node currentNode;
    public Node targetNode;
    public List<Node> path;
    public float moveSpeed;
    public bool ableToMove;
    void Awake()
    {
        path = new List<Node>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ableToMove == false) return;
        GeneratePath();
    }

    private void GeneratePath()
    {
        //if there are still path
        if (path.Count > 0)
        {
            //value for the first path in list
            int _x = 0;

            //get target of next path
            Vector3 _target = new Vector3(path[_x].transform.position.x,
                                          path[_x].transform.position.y,
                                          0);

            //move to next path
            this.transform.position = Vector3.MoveTowards(this.transform.position, _target, moveSpeed * Time.deltaTime);

            //if the ai reached to the targeted path
            if (Vector2.Distance(this.transform.position, path[_x].transform.position) < 0.1f)
            {
                //set current node at the targeted path
                currentNode = path[_x];
                //remote that path from list
                path.RemoveAt(_x);
            }
        }
        else
        {
            path = AStarManager.Instance.GeneratedPath(currentNode, targetNode);
        }
    }

    public void MoveAI(bool _move)
    {
        ableToMove = _move;
    }
    // void OnDrawGizmos()
    // {
    //     if(path.Count > 0)
    //     {
    //         Gizmos.color = Color.blue;
    //         for(int i = 1; i < path.Count;i++)
    //         {
    //             Gizmos.DrawLine(path[i].transform.position,path[i - 1].transform.position);
    //         }
    //     }
    // }
}
