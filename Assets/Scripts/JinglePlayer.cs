using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JinglePlayer : MonoBehaviour
{
    [Tooltip("鳴らしたいSE"), SerializeField]
    TinyAudio.Se se = TinyAudio.Se.Gameover;

    void Start()
    {
        TinyAudio.StopBGM();
        TinyAudio.PlaySe(se);
    }
}
