using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable] // 標記為可序列化
public class Sound
{
    public string name;

    public AudioClip clip; // 剪輯

    [Range(0f, 1f)] // 音量範圍
    public float volume; // 音量
    [Range(.1f, 3f)]
    public float pitch; // 音調

    public bool loop; // 循環

    [HideInInspector] // 不顯示在檢查器中
    public AudioSource source;
}
