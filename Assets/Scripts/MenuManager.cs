using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * ����� ��� ��������� ������� �� ������ ����.
 * ����������� ��� �����, �� ������� ���������� �������
 * ����� ������� �� ������
 */

public class MenuManager : MonoBehaviour
{
    //��� �����
    private const string Name = "GamerName";
    private const string Insects = "InsectNumber";
    private const string Record = "Records";
    private const string MainMenu = "MainMenu";
    private const string SimpleGame = "SimpleGame";
    //��� �������� ���� ����
    private int typeScore;

    public void StartGame()
    {
        //�������� �����
        SceneManager.LoadScene("GameScene");
        //���� � �����������
        typeScore = 1;
        //���������� � �������� ���� ���� � ��� ����
        PlayerPrefs.SetInt("typeScore", typeScore);
    }

    public void GamerName()
    {
        SceneManager.LoadScene(Name);
    }

    public void InsectNumber()
    {
        SceneManager.LoadScene(Insects);
    }

    public void Records()
    {
        SceneManager.LoadScene(Record);
    }

    public void ToMenu()
    {

        SceneManager.LoadScene(MainMenu);
    }

    public void ToSimpleGame()
    {
        //���� ��� ����������
        typeScore = 2;
        PlayerPrefs.SetInt("typeScore", typeScore);

        SceneManager.LoadScene(SimpleGame);
    }

}
