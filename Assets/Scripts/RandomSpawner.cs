//#define DEBUG_LOG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    /// <summary>
    /// 画面端から出現可能な割合(0～1)
    /// </summary>
    const float SpawnRangeX = 0.25f;
    const float SpawnRangeY = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        var cam = Camera.main;
        var camToMe = transform.position - cam.transform.position;
        var toChrDistance = Vector3.Dot(cam.transform.forward, camToMe);
        var vpos = new Vector3(0, 0, toChrDistance);
        var leftBottom = cam.ViewportToWorldPoint(vpos);
        vpos = new Vector3(1, 1, toChrDistance);
        var rightTop = cam.ViewportToWorldPoint(vpos);
        var leftBottomToRightTop = rightTop - leftBottom;
        var xDist = Vector3.Dot(cam.transform.right, leftBottomToRightTop);
        var yDist = Vector3.Dot(cam.transform.up, leftBottomToRightTop);

        // XとYの左下からのランダムの距離を求める
        var colliderBnd = GetComponent<Collider>().bounds;
        var minRange = colliderBnd.min - transform.position;
        var maxRange = colliderBnd.max - transform.position;
        var xpos = Random.Range(-minRange.x, xDist - maxRange.x);
        var ypos = Random.Range(-minRange.y, yDist - maxRange.y);

        for (var i = 0; i < 100; i++)
        {
            var xn = xpos / xDist;
            var yn = ypos / yDist;

            GameManager.Log($"  {xn} {yn}");

            if (    (xn < SpawnRangeX)
                ||  (xn > (1f-SpawnRangeX))
                ||  (yn < SpawnRangeY)
                ||  (yn > (1f-SpawnRangeY))) {

                GameManager.Log($"  break");
                break;
            }

            xpos = Random.Range(-minRange.x, xDist - maxRange.x);
            ypos = Random.Range(-minRange.y, yDist - maxRange.y);
        }

        // ワールド座標に統合
        transform.position = leftBottom + xpos * cam.transform.right
            + ypos * cam.transform.up;
    }
}
