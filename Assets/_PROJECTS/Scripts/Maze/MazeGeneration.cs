using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MazeGeneration : MonoBehaviour
{
    [Header("PREFAB")]
    [HorizontalLine(padding = 20, thickness = 4)]
    public MazeCell mazeCellPrefab;         //cell prefab of each maze cell
    public GameObject bug;                  //bug prefab
    public GameObject target;               //target prefab

    [Header("SIZE")]
    [HorizontalLine(padding = 20, thickness = 4)]
    public int width;                       //the width of the maze
    public int height;                      //the height of the maze

    [Header("Camera")]
    [HorizontalLine(padding = 20, thickness = 4)]
    public Vector3 camPos;                  //camera position
    public float camSize;                   //camera size

    //================================ PRIVATE ================================
    private MazeCell[,] _mazeGrid;          //dimension of the maze so we can track and position easily
    private MapInfo _mapInfo;
    //================================ PRIVATE ================================

    // Start is called before the first frame update
    void Start()
    {
        MazeInitializer();
    }

    /// <summary>
    /// function to generate maze
    /// </summary>
    void MazeInitializer()
    {
        //============== SET ==============
        _mapInfo = GetComponent<MapInfo>();
        //============== SET ==============

        #region ========== MAZE / A* INITIALIZATION  ==========
        //create new grid with following given width and height for maze dimension
        _mazeGrid = new MazeCell[width, height];
        //create new gameobject with name maze parent
        GameObject _mazeParent = new GameObject("Maze Parent");
        //loop at x position
        for (int x = 0; x < width; x++)
        {
            //loop at y posiion
            for (int y = 0; y < height; y++)
            {
                //spawning maze cell
                MazeCell _spawnedCell = Instantiate(mazeCellPrefab, new Vector3(x, y, 0), Quaternion.identity);
                //set maze 2D array to be this maze with it following position
                _mazeGrid[x, y] = _spawnedCell;
                //initialize each cell
                _spawnedCell.CellInitialize();
                //set parent for the maze
                _spawnedCell.transform.parent = _mazeParent.transform;
                _mapInfo.allNode.Add(_spawnedCell.GetComponent<Node>());

                if (x == 0 && y == 12)
                {
                    bug = Instantiate(bug, new Vector3(x, y, 0), Quaternion.identity);
                    _mapInfo.startNode = _spawnedCell.GetComponent<Node>();
                    _mapInfo.AI = bug.GetComponent<AIBehaviour>();
                }
            }
        }
        //call maze generation which to create path inside maze
        GenerateMaze(null, _mazeGrid[0, 0]);
        
        //randomizing target posiotion
        Vector2 _targetPos = new Vector2(UnityEngine.Random.Range(0, width), UnityEngine.Random.Range(0, height));
        //spawn target at that randomized positon
        target = Instantiate(target, new Vector3(_targetPos.x, _targetPos.y, 0), Quaternion.identity);
        //set target for map info
        _mapInfo.targetNode = target.GetComponent<Node>();

        _mapInfo.MapInitialize();
        #endregion

        

        #region ========== CAMERA INITIALIZATION ==========
        //get camera
        Camera _cam = Camera.main;
        //set camera position
        _cam.transform.position = camPos;
        //set camera orthographic size
        _cam.orthographicSize = camSize;
        #endregion

        
    }

    /// <summary>
    /// function to create path inside maze
    /// </summary>
    /// <param name="_previousCell"> previous maze cell </param>
    /// <param name="_currentCell"> current maze cell </param>
    private void GenerateMaze(MazeCell _previousCell, MazeCell _currentCell)
    {
        //marking the current cell as visited so we won't be checking it and clear wall at that cell
        _currentCell.VisitedMark();
        //calling function to clear wall and block to create path for maze
        ClearWalls(_previousCell, _currentCell);


        //decalring varible to get next unvisited cell
        MazeCell _nextCell;

        do
        {
            //get next unvisited cell
            _nextCell = GetNextUnVisitedCell(_currentCell);
            //if there is next cell
            if (_nextCell != null)
            {
                //call this function again recursively until it check all maze cell
                GenerateMaze(_currentCell, _nextCell);
            }
            //condition to get out loop
        } while (_nextCell != null);
    }

    /// <summary>
    /// function to return next unvisited cell
    /// </summary>
    /// <param name="_currentCell"> current cell so we check it surrounding </param>
    /// <returns></returns>
    private MazeCell GetNextUnVisitedCell(MazeCell _currentCell)
    {
        var _unvisitedCell = GetUnVitistedCells(_currentCell);
        return _unvisitedCell.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();

    }

    /// <summary>
    /// function to get neighbour cell at current cell
    /// </summary>
    /// <param name="currentCell"></param>
    /// <returns></returns>
    private IEnumerable<MazeCell> GetUnVitistedCells(MazeCell currentCell)
    {
        //checking which cell is visted
        int x = (int)currentCell.transform.position.x;
        int y = (int)currentCell.transform.position.y;

        //checking if all the cells at left, right, back and front are in bounds of the maze and not visited

        if (x + 1 < width)
        {
            MazeCell _cellToRight = _mazeGrid[x + 1, y];
            if (_cellToRight.cellVisited == false)
            {
                yield return _cellToRight;
            }
        }

        if (x - 1 >= 0)
        {
            MazeCell _cellToLeft = _mazeGrid[x - 1, y];
            if (_cellToLeft.cellVisited == false)
            {
                yield return _cellToLeft;
            }
        }

        if (y + 1 < height)
        {
            MazeCell _cellToTop = _mazeGrid[x, y + 1];
            if (_cellToTop.cellVisited == false)
            {
                yield return _cellToTop;
            }
        }

        if (y - 1 >= 0)
        {
            MazeCell _cellToBottom = _mazeGrid[x, y - 1];
            if (_cellToBottom.cellVisited == false)
            {
                yield return _cellToBottom;
            }
        }
    }

    /// <summary>
    /// function to clear walls to create path for maze
    /// </summary>
    /// <param name="_previousCell"></param>
    /// <param name="_currentCell"></param>
    private void ClearWalls(MazeCell _previousCell, MazeCell _currentCell)
    {
        //if there is no previous cell then stop execute
        if (_previousCell == null) return;

        //checking previous cell is at left of current one
        if (_previousCell.transform.position.x < _currentCell.transform.position.x)
        {
            _previousCell.ClearWall("RightWall");
            _currentCell.ClearWall("LeftWall");
            return;
        }

        //checking previous cell is at right of current one
        if (_previousCell.transform.position.x > _currentCell.transform.position.x)
        {
            _previousCell.ClearWall("LeftWall");
            _currentCell.ClearWall("RightWall");
            return;
        }

        //checking previous cell is at bottom of current one
        if (_previousCell.transform.position.y < _currentCell.transform.position.y)
        {
            _previousCell.ClearWall("TopWall");
            _currentCell.ClearWall("BottomWall");
            return;
        }

        //checking previous cell is at top of current one
        if (_previousCell.transform.position.y > _currentCell.transform.position.y)
        {
            _previousCell.ClearWall("BottomWall");
            _currentCell.ClearWall("TopWall");
            return;
        }
    }
}
