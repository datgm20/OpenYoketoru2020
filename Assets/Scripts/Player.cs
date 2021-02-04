using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject explosionPrefab = default;

    float cameraDistance = 0;
    Rigidbody rb = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraDistance = Vector3.Distance(Camera.main.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.IsGameStarted)
        {
            return;
        }

        var mp = Input.mousePosition;
        mp.z = cameraDistance;
        var wp = Camera.main.ScreenToWorldPoint(mp);
        var v = (wp - transform.position) / Time.fixedDeltaTime;
        rb.velocity = v;
        // Debug.Log(mp);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!GameManager.IsGameStarted) return;

        if (collision.collider.CompareTag("Enemy"))
        {
            TinyAudio.PlaySe(TinyAudio.Se.Hit);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameManager.ToGameover();
        }
    }
}
