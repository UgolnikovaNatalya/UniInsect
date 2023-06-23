using UnityEngine;
using UnityEngine.UI;

//����� ��� ���������� ����� ������������
public class SaveUserName : MonoBehaviour
{
    //���������� ���� ����� �� �����
    public InputField field;

    public void SaveName()
    {
        //���������� �������� ���� �����
        //���� ��� ������ ��� null ���������� �������� No name
        if (field.text == "" || field.text == null)
        {
            field.text = "No name";
        }

        //���������� ������ � ��� ����������
        PlayerPrefs.SetString("userName", field.text);
        PlayerPrefs.Save();
    }
        
}
