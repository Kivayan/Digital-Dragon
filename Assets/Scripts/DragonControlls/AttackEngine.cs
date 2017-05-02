using UnityEngine;

public class AttackEngine : MonoBehaviour
{

    private AnimatorHandler animHandler;

    public GameObject UI;
    public GameObject owca;


    public KeyCode tailAttackKey;
    public ColliderController tailCollider1;
    public ColliderController tailCollider2;

    public KeyCode mouthAttackKey;
    public ColliderController jawTop;
    public ColliderController jawBot;

    public KeyCode armAttackKey;
    public ColliderController armLeft;
    public ColliderController armRight;

    public AudioClip audioTailHit;
    public AudioClip audioFistHit;
    public AudioClip audioEat;

    private AudioSource effectAudio;

    // Use this for initialization
    private void Start()
    {
        effectAudio = GetComponent<AudioSource>();
        animHandler = GetComponent<AnimatorHandler>();
    }

    // Update is called once per frame
    private void Update()
    {
        AttackMonitor();
    }

    private void AttackMonitor()
    {
        //Arm Attack
        if (Input.GetKeyDown(armAttackKey))
        {
            animHandler.TriggerAttack("JumpAttack");
            armLeft.ColliderOn();
            armRight.ColliderOn();
            effectAudio.clip = audioFistHit;
            effectAudio.Play();
        }

        //Mouth Attack
        if (Input.GetKeyDown(mouthAttackKey))
        {
            animHandler.TriggerAttack("HapTrigger");
            owca.GetComponent<Owca_script>().eat = true;
            jawTop.ColliderOn();
            jawBot.ColliderOn();
            effectAudio.clip = audioEat;
            effectAudio.Play();
        }

        //Tail Attack
        if (Input.GetKeyDown(tailAttackKey))
        {
            animHandler.TriggerAttack("TailAttack");
            tailCollider1.ColliderOn();
            if(tailCollider2 != null)
                tailCollider2.ColliderOn();

            effectAudio.clip = audioTailHit;
            effectAudio.Play();
        }
    }
}