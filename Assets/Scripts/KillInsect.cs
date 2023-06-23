using UnityEngine;

/*
 * ����� ��� �������� �������
 */
public class KillInsect : MonoBehaviour
{
    //������ � ������
    public GameObject deathInsect;

    //������ �� ������ ������ Score, ��� �������� �����
    private Score sm;
    
    //��� ����. ���� 1 - ���� � ����������� �����������
    //2 - ���� ��� ���������� �����������
    private int typeScore;

    //������� ����������� ����� Start
    private void Awake()
    {
        //�������� ��� ����
        typeScore = PlayerPrefs.GetInt("typeScore");
    }
    private void Start()
    {
        //������������� � ������� ������ Score
        sm = FindObjectOfType<Score>();
    }

    //���������� ������� �� �����/����
    private void OnMouseDown()
    {
        //���� � ����������� �����������
        if (typeScore == 1)
        {
            if (deathInsect != null)
                {
                    Instantiate(deathInsect, transform.position, transform.rotation);

                    sm.Kill();

                    Destroy(gameObject);
                }

        }
        //���� ��� ���������� �����������
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
