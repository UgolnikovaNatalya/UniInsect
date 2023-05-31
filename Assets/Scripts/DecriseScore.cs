using UnityEngine;

public class DecriseScore : MonoBehaviour
{
    private Score scores;
    private InsectSpawn spawn;


    private void Start()
    {
        scores = FindObjectOfType<Score>();
        spawn = FindObjectOfType<InsectSpawn>();
    }

    private void OnMouseDown()
    {
        if (spawn.gameTimer > 0)
        {
            scores.Miss();
        }

    }
}
