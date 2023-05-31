using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InsectSpawn : MonoBehaviour
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

    //таймер
    public float gameTimer = 4;

    public Text timerText;

    //счетчик
    private Text score;

    //кнопка возврата в меню
    public Button btn;



    private void Start()
    {
        //выводим секунды в текстовое окно секундомера
        timerText.text = gameTimer.ToString();
        insectNumber = 0;

        btn.gameObject.SetActive(false);

        StartCoroutine(Spawn());
        Debug.Log(timerText.text);
    }

    private void Update()
    {
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime; //обратный отсчет
            timerText.text = Mathf.Round(gameTimer).ToString();
        }
        //else 
        //{           
        //    //StopCoroutine(Spawn());
        //    GameObject obj = GameObject.FindWithTag("Insect");
        //    Destroy(obj);
        //    Debug.LogAssertion("Coroutine is stopped");
        //}

    }

    IEnumerator Spawn()
    {
        //генерация по времени
        if (insectNumber == 0)
        {

            while (gameTimer > 0 && insectNumber != 3)
            {
                randomInsect = Random.Range(1, 3); //если 1 - паук, 2 - пчела

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
                //insectNumber++;
                Debug.Log($"Timer: {gameTimer}");
            }

            GameObject[] obj = GameObject.FindGameObjectsWithTag("Insect");
            for (int i = 0; i < obj.Length; i++)
            {
                Destroy(obj[i]);
            }


            //GameObject[] obj = GameObject.FindGameObjectsWithTag("Insect");
            //GameObject obj1 = obj[];
            //Destroy(obj1);



            btn.gameObject.SetActive(true);
        }

        //btn.gameObject.SetActive(true);
        ////генерация по количеству
        //if (insectNumber > 0)
        //{
        //    gameTimer = 0;
        //    gameTimer += Time.deltaTime;
        //    //цикл для создания насекомых,
        //    //когда задано количество
        //    while (count != insectNumber)
        //    {
        //        randomInsect = Random.Range(1, 3); //если 1 - паук, 2 - пчела

        //        if (randomInsect == 1)
        //        {
        //            Instantiate(spider, new Vector2(Random.Range(-3.5f, 3.5f), 6.5f), Quaternion.identity);
        //            yield return new WaitForSeconds(3f);
        //        }

        //        else if (randomInsect == 2)
        //        {
        //            Instantiate(bee, new Vector2(Random.Range(-3.5f, 3.5f), 6.5f), Quaternion.identity);
        //            yield return new WaitForSeconds(2.5f);
        //        }

        //        count++;

        //    }

        //}

    }

}