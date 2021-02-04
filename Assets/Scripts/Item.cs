// #define DEBUG_LOG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    int point = 100;

    [SerializeField]
    GameObject particlePrefab = default;

    static int count = 0;

    private void Start()
    {
        count++;
    }

    public static void ClearCount()
    {
        count = 0;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!GameManager.IsGameStarted) return;

        GameManager.Log("hit "+collision.collider.name + " "+ collision.contacts[0].point );
        if (collision.collider.CompareTag("Player"))
        {
            // 得点処理
            GameManager.Instance.AddPoint(Mathf.RoundToInt(point * GameManager.GetTime));

            TinyAudio.PlaySe(TinyAudio.Se.Get);
            Instantiate(particlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);

            // クリアチェック
            count--;
            if (count <= 0)
            {
                GameManager.ToClear();
            }
        }
    }
}
