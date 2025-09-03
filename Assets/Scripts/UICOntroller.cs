using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Grid2d grid2d;
    public PathFinding pathFinding;

    public Button randomMapBtn;
    public Button findPathBtn;

    private void Awake()
    {
        grid2d = FindObjectOfType<Grid2d>();
        pathFinding = FindObjectOfType<PathFinding>();

        randomMapBtn = transform.GetChild(0).GetComponent<Button>();
        findPathBtn = transform.GetChild(1).GetComponent<Button>();
    }
    private void Start()
    {
        randomMapBtn.onClick.AddListener(grid2d.CreateGrid);
        findPathBtn.onClick.AddListener(pathFinding.FindPath);
    }
}
