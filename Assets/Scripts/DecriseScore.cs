using UnityEngine;

public class DecriseScore : MonoBehaviour
{
    public Score scores;
    public InsectSpawn timer;


    private void Start()
    {
        scores = FindObjectOfType<Score>(); 
        timer = FindObjectOfType<InsectSpawn>();
    }

    private void OnMouseDown()
    {
        if (timer.gameTimer > 0)
        {
            scores.Miss();
        } 
        
    }
}
