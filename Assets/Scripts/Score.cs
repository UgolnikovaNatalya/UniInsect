using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public static int score = 0;

    private void Update()
    {
        scoreText.text = score.ToString();

    }

    public void Kill()
    {

        score++;
    }

    public void Miss()
    {
            if (score != 0)
            {
                score--;
            }        
    }
}
