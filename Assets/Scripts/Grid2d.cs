using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Grid2d : MonoBehaviour
{
    public int width;
    public int height;
    public float cellSize = 1f;
    public GameObject nodePrefab;
    [Range(0f, 1f)] public float obstacleChange = 0.2f; //20% ô thành tường

    Node[,] grid;
    public Node startNode;
    public Node goalNode;

    void Start()
    {
        CreateGrid();
    }

    public void CreateGrid()
    {
        DeleteGrid();
        width = Random.Range(9, 15);
        height = Random.Range(9, 15);
        grid = new Node[width, height];

        Vector2 startPos = new Vector2(-((width * cellSize)  / 2f) + cellSize / 2f,
            ((height * cellSize)  / 2f) - cellSize / 2f);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //Vector3 pos = new Vector3(x * cellSize, y * cellSize, 0);
                Vector3 pos = transform.position + new Vector3(startPos.x + (x * cellSize), startPos.y - (y * cellSize), 0);
                GameObject obj = Instantiate(nodePrefab, pos, Quaternion.identity, transform);
                Node node = obj.GetComponent<Node>();
                node.gridPos = new Vector2Int(x, y);

                //random obstacle
                bool isObstacle = Random.value < obstacleChange;
                node.SetWalkable(!isObstacle);

                grid[x, y] = node;
            }
        }
        CreateStartAndGoal();
    }

    private void DeleteGrid()
    {
        if(transform.childCount > 0)
        {
            foreach(Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void CreateStartAndGoal()
    {
        startNode = GetRandomWalkableNode();
        startNode.SetTypeNode(NodeType.npc);

        do
        {
            goalNode = GetRandomWalkableNode();
            goalNode.SetTypeNode(NodeType.goal);
        } while( goalNode == startNode );
    }
    Node GetRandomWalkableNode()
    {
        Node node = null;
        while(node == null || !node.walkable)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            node = grid[x, y];
        }
        return node;
    }

    public Node GetNode(Vector2Int pos)
    {
        if (pos.x >= 0 && pos.x < width && pos.y >= 0 && pos.y < height)
        {
            return grid[pos.x, pos.y];
        }
        return null;
    }
}

