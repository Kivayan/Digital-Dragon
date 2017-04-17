using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audio;

    /// <summary>
    /// If Set to false, Audio source should have clip preselected
    /// </summary>
    public bool playRandomClips = false;

    public AudioClip[] clips;

    public bool randomizeVolume = false;
    public float volumeRangeMin = 0.3f;
    public float volumeRangeMax = 0.6f;

    public bool randomizePitch = false;
    public float pitchRangeMin = 1.4f;
    public float pitchRangeMax = 1.6f;

    public bool playAtRandomInterval = true;
    private bool playTriggered = false;
    public float intervalMin = 3;
    public float intervalMax = 15;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        MonitorPlayType();
    }

    private void MonitorPlayType()
    {
        if (playAtRandomInterval && !playTriggered)
        {
            audio.loop = false;
            StartCoroutine(AwaitPlay());
        }
        else
        {
            if (!audio.isPlaying)
                PlaySound();
        }
    }

    private void PlaySound()
    {
        if (randomizeVolume)
            audio.volume = Random.Range(volumeRangeMin, volumeRangeMax);

        if (randomizePitch)
            audio.pitch = Random.Range(pitchRangeMin, pitchRangeMax);

        if (playRandomClips)
        {
            audio.clip = RandomClip();
            audio.Play();
        }
        else
        {
            audio.Play();
        }
    }

    private IEnumerator AwaitPlay()
    {
        playTriggered = true;
        float x = Random.Range(intervalMin, intervalMax);

        yield return new WaitForSeconds(x);
        PlaySound();
        playTriggered = false;
    }

    // Select Random Clip from the list
    private AudioClip RandomClip()
    {
        int x = Random.Range(0, clips.Length);
        return clips[x];
    }
}