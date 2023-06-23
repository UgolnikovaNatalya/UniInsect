using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/*
 * ����� �� �����, ��� � InsectSpawn
 * ������ � ��� �� ����������� �������
 */
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

    //���������� ��� ���������� �������� ��������  1 - ����, 2 - �����
    private int randomInsect;

    //�������
    public Text score;

    //������� � ����
    public Button btn;
    //������ ����������� ������
    private float timerButton = 1f;

    void Start()
    {
        //��������� ������ � ���������� ���������
        insectNumber = int.Parse(PlayerPrefs.GetString("inse"));
        //������ ��������� ������ 1,5 ���
        timerButton = 1.5f;
        btn.gameObject.SetActive(false);
        //����� ��������
        StartCoroutine(Spawn());
    }

    void Update()
    {
        //��������� ���������� ���������
        score.text = insectNumber.ToString();

        //����� ���������� ��������� =0, ����������� ������ 
        //��������� ������ � ��������� �������� ����� 1,5 ���
        if (insectNumber == 0)
        {
            //������ ���� �������� ����� 1,5 ���
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
        //��������� ��������
            StopCoroutine(Spawn());        
    }

    //��������
    IEnumerator Spawn()
    {
        //���� ���������� ��������� > 0 ��������� ���������
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

        if (insectNumber == 0)
        {
            //����� ��������� ���������� ����������
            //����������� ���� ��������� ����� 1,5 ���
            GameObject[] obj = GameObject.FindGameObjectsWithTag("Insect");
            for (int i = 0; i < obj.Length; i++)
            {
                Destroy(obj[i], 1.5f);
            }

        }

    }
}

