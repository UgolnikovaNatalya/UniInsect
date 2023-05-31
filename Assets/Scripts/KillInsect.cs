using UnityEngine;

public class KillInsect : MonoBehaviour
{
    [SerializeField]
    public GameObject deathInsect;

    private Score sm;


    private void Start()
    {
        sm = FindObjectOfType<Score>();
    }

    private void OnMouseDown()
    {
        if (deathInsect != null)
        {
            Instantiate(deathInsect, transform.position, transform.rotation);

            sm.Kill();

            Destroy(gameObject);
        }

    }




}
