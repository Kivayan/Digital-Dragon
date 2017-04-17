using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public CharacterController cc;
    private Animator playerAnim;

    // Use this for initialization
    private void Start()
    {
        playerAnim = FindObjectOfType<CharacterController>().gameObject.GetComponent<Animator>();
        // cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        SimpleWalkDetector();
    }

    private void SimpleWalkDetector()
    {
        if(playerAnim.GetInteger("MovementPhase") == 1)
        {
            GetComponent<AudioSource>().volume = Random.Range(0.3f, 0.6f);
            GetComponent<AudioSource>().pitch = Random.Range(1.4f, 1.6f);
            GetComponent<AudioSource>().Play();
        }
    }

    //sry mate that did not work properly
    private void KubaKapMethod()
    {
        if (cc.isGrounded && cc.velocity.magnitude > 2f && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().volume = Random.Range(0.3f, 0.6f);
            GetComponent<AudioSource>().pitch = Random.Range(1.4f, 1.6f);
            GetComponent<AudioSource>().Play();
        }
    }
}