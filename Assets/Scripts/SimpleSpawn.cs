using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SimpleSpawn : MonoBehaviour
{
    //������ ������
    [SerializeField]
    public GameObject spider;

    //������ ����
    [SerializeField]
    public GameObject bee;

    //���������� ���������
    private int insectNumber;
    private int currentNumber;

    //���������� ��� ���������� �������� ��������  1 - ����, 2 - �����
    private int randomInsect;

    //�������
    public Text score;

    //������� � ����
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
            randomInsect = Random.Range(1, 3); //���� 1 - ����, 2 - �����

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

