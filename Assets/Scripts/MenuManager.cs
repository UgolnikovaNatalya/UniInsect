using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Класс для обработки нажатия на кнопки меню.
 * Описываются все сцены, на которые происходит переход
 * после нажатия на кнопку
 */

public class MenuManager : MonoBehaviour
{
    //все сцены
    private const string Name = "GamerName";
    private const string Insects = "InsectNumber";
    private const string Record = "Records";
    private const string MainMenu = "MainMenu";
    private const string SimpleGame = "SimpleGame";
    //для передачи типа игры
    private int typeScore;

    public void StartGame()
    {
        //загрузка сцены
        SceneManager.LoadScene("GameScene");
        //игра с сохранением
        typeScore = 1;
        //сохранение и передача типа игры в хеш игры
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
        //игра без сохранения
        typeScore = 2;
        PlayerPrefs.SetInt("typeScore", typeScore);

        SceneManager.LoadScene(SimpleGame);
    }

}
