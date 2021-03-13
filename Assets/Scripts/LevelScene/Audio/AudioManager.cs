using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        public float volume;
        public bool loop;
        public AudioSource source;
    }

    public Sound[] sounds;
    void Start()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }

        PlaySound("MainTheme");
    }

    public void PlaySound(string name)
    {
        foreach (Sound s in sounds)
        {
            if(s.name == name)
            {
                s.source.Play();
            }
        }
    }
}
