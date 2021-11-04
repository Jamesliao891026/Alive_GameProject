using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public Sound[] sounds;

    // 靜態音頻管理器
    public static AudioManager instance;

    void Awake()
    {
        // 判斷原本是否有音樂在播放
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }
        // 切換場景音樂不間斷
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            // 將新的音源組件設定為當前正在查看的音源
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop; // 主題循環
        }
    }
    void Start()
    {
        //AudioManager.instance.Play();
        // FindObjectOfType<AudioManager>().Play("PlayerDeath");
    }

    // 播放音源
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
