﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyAudio : MonoBehaviour
{
    public static TinyAudio Instance;

    public enum Se
    {
        Click,
        Hit,
        Get,
        Gameover,
        Clear
    }

    [Tooltip("効果音データ"), SerializeField]
    AudioClip[] seList = null;

    AudioSource audioSource;

    void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySe(Se se)
    {
        Instance.audioSource.PlayOneShot(
            Instance.seList[(int)se]);
    }

    public static void StopBGM()
    {
        Instance.audioSource.Stop();
    }
}
