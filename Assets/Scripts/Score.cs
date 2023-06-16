using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    public Text scoreText;
    public int score = 0;


    private void Start()
    {
        scoreText = GetComponent<Text>();
        
        score = 0;
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        scoreText.text = score.ToString();


        PlayerPrefs.SetInt("r", score);

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
