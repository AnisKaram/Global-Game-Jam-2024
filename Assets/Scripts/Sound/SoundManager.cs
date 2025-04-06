using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    [SerializeField] private AudioSource _alienSource;
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _musicSource;

    [SerializeField] private List<AudioClip> _alienClips;
    [SerializeField] private List<AudioClip> _sfxClips;

    [SerializeField] private List<AudioClip> _musicClips;

    public static SoundManager Instance
    {
        get { return _instance; }
    }

    public List<AudioClip> ListOfAlienClips
    {
        get { return _alienClips; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void PlayAlienSfx(int sfxIndex)
    {
        if (!_alienSource.isPlaying)
        {
            _alienSource.clip = _alienClips[sfxIndex];
            _alienSource.Play();
        }
    }

    public void PlaySfx(int sfxIndex)
    {
        _sfxSource.clip = _sfxClips[sfxIndex];
        _sfxSource.Play();
    }

    public void PlayMusic(int musicIndex)
    {
        _musicSource.clip = _musicClips[musicIndex];
        _musicSource.Play();
    }

    public void StopMusic()
    {
        _musicSource.Stop();
    }
}