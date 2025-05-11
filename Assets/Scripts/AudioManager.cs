using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioGameMixer;
    [SerializeField] private AudioData _audioData;
    [SerializeField] private AudioSource _sound;
    void Start()
    {
        
    }
    public void Setmaster(float f)
    {
        _audioData._master = f;
        _audioGameMixer.SetFloat("Master", Mathf.Log10(f) * 20f);
    }
    public void SetMusic(float f)
    {
        _audioData._music = f;
        _audioGameMixer.SetFloat("Music", Mathf.Log10(f) * 20f);
    }
    public void SetSFX(float f)
    {
        _audioData._SFX = f;
        _audioGameMixer.SetFloat("SFX", Mathf.Log10(f) * 20f);
    }
    public void PlaySound()
    {
        _sound.Play();
    }
    public void StopSound()
    {
        _sound.Stop();
    }
    public void PlaysfxIndex(int index)
    {
        _sound.clip = _audioData.sfxClip[index];
    }
    public void PlayMusicIndex(int index)
    {
        _sound.clip = _audioData.musicClip[index];
    }

}
