using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
    private int currentNumber;

    //переменная для рандомного создания объектов  1 - паук, 2 - пчела
    private int randomInsect;

    //счетчик
    public Text score;

    //возврат в меню
    public Button btn;

    void Start()
    {
        insectNumber = int.Parse(PlayerPrefs.GetString("inse"));
        Debug.LogError("InsectNumber: " +  insectNumber);
        

        btn.gameObject.SetActive(false);

        StartCoroutine(Spawn());
    }

    void Update()
    {
        score.text = insectNumber.ToString();
    }


    IEnumerator Spawn()
    {

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

        btn.gameObject.SetActive(true);

    }
}

