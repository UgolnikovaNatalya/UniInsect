using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public Transform[] moveSpots;

    private int randomSpot;
    private float speed = 2f;

    private void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
        }
    }

}
