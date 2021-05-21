using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MusicSettings : MonoBehaviour
{
	public AudioSource audioData;
	public AudioSpeakerMode speaker;
	void Start()
	{
		audioData = GetComponent<AudioSource>();
		audioData.Play(0);
	}

	public void PlayMusic()
	{
		audioData.Play(0);
	}

	public void StopMusic()
	{
		audioData.Stop();
	}


}
