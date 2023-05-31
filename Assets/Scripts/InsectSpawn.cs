using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InsectSpawn : MonoBehaviour
{

    //������ ������
    [SerializeField]
    public GameObject spider;

    //������ ����
    [SerializeField]
    public GameObject bee;

    //���������� ���������
    private int insectNumber;

    //���������� ��� ���������� �������� ��������  1 - ����, 2 - �����
    private int randomInsect;

    //������
    public float gameTimer = 4;

    public Text timerText;

    //�������
    private Text score;

    //������ �������� � ����
    public Button btn;



    private void Start()
    {
        //������� ������� � ��������� ���� �����������
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
            gameTimer -= Time.deltaTime; //�������� ������
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
        //��������� �� �������
        if (insectNumber == 0)
        {

            while (gameTimer > 0 && insectNumber != 3)
            {
                randomInsect = Random.Range(1, 3); //���� 1 - ����, 2 - �����

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
        ////��������� �� ����������
        //if (insectNumber > 0)
        //{
        //    gameTimer = 0;
        //    gameTimer += Time.deltaTime;
        //    //���� ��� �������� ���������,
        //    //����� ������ ����������
        //    while (count != insectNumber)
        //    {
        //        randomInsect = Random.Range(1, 3); //���� 1 - ����, 2 - �����

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