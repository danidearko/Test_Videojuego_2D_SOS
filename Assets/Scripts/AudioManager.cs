using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip bandaSonora;
    public AudioClip fxButton;
    public AudioClip fxCoin;
    public AudioClip fxDead;
    public AudioClip fxFire;

    private AudioSource _audioSource;

    public AudioMixerSnapshot defaultSnapshot;
    public AudioMixerSnapshot tunelSnapshot;
    public AudioMixerSnapshot submarinoSnapshot;

    public GameObject musicObj;
    private AudioSource audioMusic;

    public static AudioManager Instance;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Opcional: mantener este objeto entre escenas.
        } else if (Instance != this) {
            Destroy(gameObject); // Asegura que solo haya una instancia.
        }
    }

    void Start() {
        _audioSource = GetComponent<AudioSource>();

        if (musicObj != null) {
            audioMusic = musicObj.GetComponent<AudioSource>();
            if (audioMusic != null) {
                audioMusic.clip = bandaSonora;
                audioMusic.loop = true;
                audioMusic.volume = 0.2f;
                audioMusic.Play();
            } else {
                Debug.LogError("AudioSource en musicObj no encontrado");
            }
        } else {
            Debug.LogError("musicObj no está asignado en el Inspector");
        }
    }

    public void SonarClipUnaVez(AudioClip ac) {
        if (_audioSource != null && ac != null) {
            _audioSource.PlayOneShot(ac);
        } else {
            Debug.LogError("AudioSource o AudioClip es null");
        }
    }

    public void IniciarEfectoTunel(){
        tunelSnapshot.TransitionTo(0.5f);
    }

    public void IniciarEfectoDefault(){
        defaultSnapshot.TransitionTo(0.5f);
    }
}
