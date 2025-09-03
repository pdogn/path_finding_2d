using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NpcController : MonoBehaviour
{
    public float speed = 8f;
    bool isMoving;
    Coroutine moveCoroutine;
    public void StartMove(List<Node> path)
    {
        if (isMoving) return;
        isMoving = true;
        if (path.Count == 0) return;

        moveCoroutine = StartCoroutine(MovePath(path,1));
    }
    private IEnumerator MovePath(List<Node> path, int crrIndex)
    {
        for (int i = 0; i < path.Count; i++)
        {
            Transform target = path[i].transform;

            while (Vector3.Distance(transform.position, target.position) > 0.005f)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    target.position,
                    speed * Time.deltaTime
                );
                yield return null;
            }
        }
    }

    public void ReSetPos(Vector3 pos)
    {
        if(moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        isMoving = false;
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
