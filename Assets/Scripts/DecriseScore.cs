using UnityEngine;

/*
 * ����� ��� ���������� �����
 * � ������, ���� ����� �����������
 * �� ����������
 */
public class DecriseScore : MonoBehaviour
{
    //������ �� ������ ������ Score
    public Score scores;
    //������ �� ������ ������ InsectSpawn
    public InsectSpawn timer;


    private void Start()
    {
        //�������� � ��������, ��������� �������
        scores = FindObjectOfType<Score>(); 
        timer = FindObjectOfType<InsectSpawn>();
    }

    //���������� ������� �� ����� ��������� ��� ����
    private void OnMouseDown()
    {
        //������ ����� ���� �� ����� ���������� �� ������ 0
        if (timer.gameTimer > 0)
        {
            scores.Miss();
        } 
        
    }
}
