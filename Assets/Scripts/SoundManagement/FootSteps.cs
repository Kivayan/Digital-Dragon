using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AnimatorHandler animHandler;
    private AudioSource audio;

    public float volumeRangeMin = 0.3f;
    public float volumeRangeMax = 0.6f;

    public float pitchRangeMin = 1.4f;
    public float pitchRangeMax = 1.6f;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        SimpleWalkDetector();
    }

    private void SimpleWalkDetector()
    {
        if(animHandler.IsMoving == true && !audio.isPlaying & animHandler.isFlying == false)
        {
            audio.volume = Random.Range(volumeRangeMin, volumeRangeMax);
            audio.pitch = Random.Range(pitchRangeMin, pitchRangeMax);
            audio.Play();
        }
    }
}