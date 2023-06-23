using System.Collections;
using UnityEngine;

/*
 * ����� ��� ������������ ����� ��� �������� 
 */
public class DeathEffect : MonoBehaviour
{
    //����� ����� ��������, ����������� ������
    private float _delayToDestroy = 2f;

    //������������ �����
    public AudioSource clip;

    private void Start()
    {
        //�������� ������ �� �����
        clip = GetComponent<AudioSource>();
        //����� ��������
        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        //������������ �����
        clip.Play();

        //��������� �������� �� 2 �������
        //� ����������� ������������ ������� (�����)
        yield return new WaitForSeconds(_delayToDestroy);
        Destroy(gameObject);
    }
}
