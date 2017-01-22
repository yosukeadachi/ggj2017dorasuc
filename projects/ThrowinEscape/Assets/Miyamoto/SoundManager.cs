using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    // 音
    public AudioClip sound;
    AudioSource m_audio;

	// Use this for initialization
	void Start () {
        m_audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void PlaySoundOneShot()
    {
        m_audio.PlayOneShot(sound);
    }
}
