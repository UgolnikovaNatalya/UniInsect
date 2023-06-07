using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private const string Name = "GamerName";
    private const string Insects = "InsectNumber";
    private const string Record = "Records";
    private const string MainMenu = "MainMenu";

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
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

}
