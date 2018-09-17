using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneSelector { mainMenu, gameScene };
public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
    //
    public SceneSelector sceneSelector;
    [SerializeField] GameObject mainMenuAudio;
    [SerializeField] GameObject ingameAudio;

    [SerializeField] AudioSource hurtAudioSource;
    [SerializeField] AudioClip[] hurtAudioClips;

    [SerializeField] AudioSource failAudioSource;

    private void Awake()
    {
        SwitchScene();
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    public void SwitchScene()
    {
        if (sceneSelector == SceneSelector.mainMenu)
        {
            mainMenuAudio.SetActive(true);
            ingameAudio.SetActive(false);
        }
        else
        {
            mainMenuAudio.SetActive(false);
            ingameAudio.SetActive(true);
        }
    }

    //Play a random minion hurt sound
    public void PlayHurtAudio()
    {
        int val = Random.Range(0, 3);
        print(val);
        hurtAudioSource.clip = hurtAudioClips[val];
        hurtAudioSource.Play();
    }

    //GameOver
    public void PlayFailAudio()
    {
        ingameAudio.GetComponent<AudioSource>().Stop();
        failAudioSource.Play();
    }

    //Restart
    public void PlayInGameAudio()
    {
        ingameAudio.GetComponent<AudioSource>().Play();
    }

    public void PlayMenuAudio()
    {
        mainMenuAudio.GetComponent<AudioSource>().Play();
    }
}
