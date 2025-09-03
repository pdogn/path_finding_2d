using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool walkable;
    public Vector2Int gridPos;
    // cost từ start
    public int gCost;
    // heuristic đến goal
    public int hCost;
    public int fCost { get { return gCost + hCost; } }

    public Node parent;


    public SpriteRenderer sprite;
    private void Awake()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void SetWalkable(bool canWalk)
    {
        walkable = canWalk;
        if(sprite != null)
        {
            SetTypeNode(NodeType.empty);
            if (!canWalk) SetTypeNode(NodeType.wall);
        }
    }
    public void SetTypeNode(NodeType type)
    {
        switch (type)
        {
            case NodeType.empty:
                sprite.color = Color.white;
                break;
            case NodeType.wall:
                sprite.color = Color.gray;
                break;
            case NodeType.npc:
                sprite.color = Color.green;
                break;
            case NodeType.goal:
                sprite.color = Color.red;
                break;
            case NodeType.findedPoint:
                sprite.color = Color.yellow;
                break;
        }
    }
}
 public enum NodeType
{
    empty,
    wall,
    npc,
    goal,
    findedPoint
}
