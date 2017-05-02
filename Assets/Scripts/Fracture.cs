using UnityEngine;

public class Fracture : MonoBehaviour
{
    public GameObject MurDestroy;
    public GameObject expPrefab;
    public bool giveExp = false;
    public Transform gameControler;

    // Use this for initialization

    private void Start()
    {
        gameControler = GameObject.FindGameObjectWithTag("GameControler").transform;
    }

    private void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "Smash")
        {
            Debug.Log("hit");
            gameControler.GetComponent<GameOver>().MenDown(1);
            Destroy(gameObject);

            Instantiate(MurDestroy, transform.position, transform.rotation);
            if (giveExp == true)
            Instantiate(expPrefab, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), transform.rotation);
        }
    }
}