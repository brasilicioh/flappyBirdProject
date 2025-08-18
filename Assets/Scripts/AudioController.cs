using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    private AudioSource audioSource, audioSourceMusic;
    [SerializeField] AudioClip backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceMusic = gameObject.AddComponent<AudioSource>();
        audioSourceMusic.clip = backgroundMusic;
        audioSourceMusic.loop = true;
        audioSourceMusic.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TocarAudio(AudioClip som, bool loop = false, bool destruir = true)
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = som;
        audioSource.loop = loop;
        audioSource.Play();
        if (destruir) { Destroy(audioSource, som.length); }
    }

    public void PararMusicaFundo()
    {
        audioSourceMusic.Stop();
    }

    public void TocarMusicaFundo()
    {
        audioSourceMusic.Play();
    }
}
