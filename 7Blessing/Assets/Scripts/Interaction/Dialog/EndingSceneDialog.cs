﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneDialog : Interaction {
    DialogManager dialogManager;
    [SerializeField] DialogText dialogText;
    [SerializeField] string nextSceneName;
    [SerializeField] AudioClip endingSound;
    [SerializeField] AudioClip nextSceneSound;

    private AudioSource audioSource;
    public override void Interact()
    {
        if(endingSound != null)
        {
           // audioSource.PlayOneShot(endingSound);
        }
        if(dialogText != null)
        {
            print(dialogManager);
            dialogManager.StartDialog(dialogText);
            audioSource.PlayOneShot(endingSound);
        }
        else
        {
            NextScene();
        }
    }

    // Use this for initialization
    void Awake () {
        print(GameObject.FindGameObjectWithTag("DialogManager"));
        dialogManager = GameObject.FindGameObjectWithTag("DialogManager").GetComponent<DialogManager>();
        audioSource = GetComponent<AudioSource>();
        print("hey");
    }

    public void NextScene() {
		if(nextSceneName != null)
        {
            GameObject music = GameObject.FindGameObjectWithTag("MusicPlayer");
            if (music != null && nextSceneSound != null)
            {
                MusicPlayer musicPlayer = music.GetComponent<MusicPlayer>();
                musicPlayer.ChangeMusic(nextSceneSound);
            }
            SceneManager.LoadScene(nextSceneName);
        }
	}
}
