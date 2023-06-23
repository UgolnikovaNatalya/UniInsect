using UnityEngine;
using UnityEngine.UI;

//����� ��� ���������� ���������� ���������
//�������� �������������
public class SaveInsectNumber : MonoBehaviour
{
    //��������� ���� �����
    public InputField field;
    //��������� ������
    public Button startGameBtn;

    public void SaveInsects()
    {
        //���������� �������� ���� �����
        //���� ��� ������ ��� null ���������� �������� 0
        if (field.text == "" || field.text == null)
        {
            field.text = "0";
        }
        //���������� ������ � ��� ����������
        PlayerPrefs.SetString("inse", field.text);
        PlayerPrefs.Save();

    }
}
