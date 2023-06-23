using UnityEngine;

/*
 * Класс для удаление объекта
 */
public class KillInsect : MonoBehaviour
{
    //объект с кровью
    public GameObject deathInsect;

    //ссылка на объект класса Score, для подсчета очков
    private Score sm;
    
    //тип игры. Если 1 - игра с сохранением результатов
    //2 - игра без сохранения результатов
    private int typeScore;

    //функция запускается перед Start
    private void Awake()
    {
        //получаем тип игры
        typeScore = PlayerPrefs.GetInt("typeScore");
    }
    private void Start()
    {
        //привязываемся к объекту класса Score
        sm = FindObjectOfType<Score>();
    }

    //обработчик нажатия на экран/мышь
    private void OnMouseDown()
    {
        //игра с сохранением результатов
        if (typeScore == 1)
        {
            if (deathInsect != null)
                {
                    Instantiate(deathInsect, transform.position, transform.rotation);

                    sm.Kill();

                    Destroy(gameObject);
                }

        }
        //игра без сохранения результатов
        if (typeScore == 2)
        {
            if (deathInsect != null)
            {
                Instantiate(deathInsect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

    }




}
