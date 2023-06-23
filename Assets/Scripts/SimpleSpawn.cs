using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/*
 * Такой же класс, как и InsectSpawn
 * только в нем не сохраняются рекорды
 */
public class SimpleSpawn : MonoBehaviour
{
    //объект пауков
    [SerializeField]
    public GameObject spider;

    //объект пчел
    [SerializeField]
    public GameObject bee;

    //количество насекрмых
    private int insectNumber;

    //переменная для рандомного создания объектов  1 - паук, 2 - пчела
    private int randomInsect;

    //счетчик
    public Text score;

    //возврат в меню
    public Button btn;
    //таймер отображения кнопки
    private float timerButton = 1f;

    void Start()
    {
        //получение данных о количестве насекомых
        insectNumber = int.Parse(PlayerPrefs.GetString("inse"));
        //таймер появления кнопки 1,5 сек
        timerButton = 1.5f;
        btn.gameObject.SetActive(false);
        //старт корутины
        StartCoroutine(Spawn());
    }

    void Update()
    {
        //обновляем количество насекомых
        score.text = insectNumber.ToString();

        //когда количество насекомых =0, запускается таймер 
        //появления кнопки и остановка корутины через 1,5 сек
        if (insectNumber == 0)
        {
            //кнопка меню появится через 1,5 сек
            timerButton -= Time.deltaTime;

            if (timerButton > 0)
            {
                Debug.Log("Timer: " + timerButton);
            }
            else
            {
                btn.gameObject.SetActive(true);
            }
        }
        //остановка корутины
            StopCoroutine(Spawn());        
    }

    //корутина
    IEnumerator Spawn()
    {
        //пока количество насекомых > 0 насекомые создаются
        while (insectNumber > 0)
        {
            randomInsect = Random.Range(1, 3); //если 1 - паук, 2 - пчела

            if (randomInsect == 1)
            {
                Instantiate(spider, new Vector2(Random.Range(-3.5f, 3.5f), 6.5f), Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }

            else if (randomInsect == 2)
            {
                Instantiate(bee, new Vector2(Random.Range(-3.5f, 3.5f), 6.5f), Quaternion.identity);
                yield return new WaitForSeconds(1.5f);
            }

            insectNumber--;

        }

        if (insectNumber == 0)
        {
            //после появления последнего насекомого
            //уничтожение всех насекомых через 1,5 сек
            GameObject[] obj = GameObject.FindGameObjectsWithTag("Insect");
            for (int i = 0; i < obj.Length; i++)
            {
                Destroy(obj[i], 1.5f);
            }

        }

    }
}

