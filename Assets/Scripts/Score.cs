using UnityEngine;
using UnityEngine.UI;

/*
 *  ласс дл€ подсчета очков
 */
public class Score : MonoBehaviour
{
    //объ€вл€ем поле, в котором вывод€тс€ очки
    public Text scoreText;
    public int score = 0;


    private void Start()
    {
        //объ€вл€ем текстовое поле
        scoreText = GetComponent<Text>();
        //задаем начальное значени€ очков
        score = 0;
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        //обновл€ем значение в текстовом поле, если очки мен€ютс€
        scoreText.text = score.ToString();
        //сохран€ем значение в хэш приложени€
        PlayerPrefs.SetInt("r", score);

    }

    //функци€ вызываетс€, когда насекомое убито
    public void Kill()
    {
        score++;
    }
    //функци€ вызываетс€, когда был промах
    public void Miss()
    {
        if (score != 0)
        {
            score--;
        }        
    }
}
