using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    float speedMin = 1f;
    [SerializeField]
    float speedMax = 5f;

    float speed;
    Rigidbody rb = default;

    private void Awake()
    {
        // speedに、speedMin～speedMaxの速度を乱数で求める
        speed = Random.Range(speedMin, speedMax);

        // ローカル変数thに、0～359の角度を乱数で求める
        var th = Random.Range(0, 359);

        // ローカル変数dirに、角度thで長さ1の方向ベクトルを求める
        var dir = new Vector3(Mathf.Cos(th * Mathf.Deg2Rad), Mathf.Sin(th * Mathf.Deg2Rad), 0);

        // 変数rbに、Rigidbodyのインスタンスを取得する
        rb = GetComponent<Rigidbody>();

        // 以上で求めた値を使って、速度を設定する
        rb.velocity = dir * speed;
    }

    private void FixedUpdate()
    {
        if (!GameManager.IsGameStarted)
        {
            rb.velocity = Vector3.zero;
            return;
        }

#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.Z))
        {
            rb.velocity = Vector3.zero;
        }
#endif

        if (Mathf.Approximately(rb.velocity.magnitude, 0f))
        {
            //Awake();
            speed = Random.Range(speedMin, speedMax);
        }
        else
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
}
