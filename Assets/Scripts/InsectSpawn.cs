using System.Collections;
using UnityEngine;
using UnityEngine.UI;
/*
 * Основной класс, где происходит создание игровых объектов
 */
public class InsectSpawn : MonoBehaviour
{

    //объект пауков
    public GameObject spider;

    //объект пчел
    public GameObject bee;

    //переменная для рандомного создания объектов  1 - паук, 2 - пчела
    private int randomInsect;

    //таймер
    public float gameTimer = 6;
    public Text timerText;

    //счетчик очков
    public Text score;

    //кнопка возврата в меню
    public Button btn;


    private void Start()
    {
        //выводим секунды в текстовое окно секундомера
        timerText.text = gameTimer.ToString();

        //скрываем кнопку возврата в меню
        btn.gameObject.SetActive(false);

        //запускаем корутину
        StartCoroutine(Spawn());

    }

    private void Update()
    {
        //проводим отсчет времени, пока оно не равно 0
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime; //обратный отсчет
            timerText.text = Mathf.Round(gameTimer).ToString();
        }

    }

    // корутина
    IEnumerator Spawn()
    {
        //объекты создаются, пока таймер не равен 0
        while (gameTimer > 0)
        {
            //генерация рандомного числа
            randomInsect = Random.Range(1, 3); //если 1 - паук, 2 - пчела

            //создание объекта
            if (randomInsect == 1)
            {
                Instantiate(spider, new Vector2(Random.Range(-3.5f, 3.5f), 6.5f), Quaternion.identity);
                yield return new WaitForSeconds(1.0f);
            }
            else if (randomInsect == 2)
            {
                Instantiate(bee, new Vector2(Random.Range(-3.5f, 3.5f), 6.5f), Quaternion.identity);
                yield return new WaitForSeconds(1.2f);
            }

            gameTimer -= Time.deltaTime;

        }

        //удаление всех объектов после завершения времени
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Insect");
        for (int i = 0; i < obj.Length; i++)
        {
            Destroy(obj[i]);
        }

        //появление кнопки после окончания времени
        btn.gameObject.SetActive(true);
       
    }

}