using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private string count;
    public Text finalScore;

    private void Start()
    {
        count = "0";
        finalScore.text = "0";
    }

    public void EndGame()
    {

        count = finalScore.text;

        Debug.LogError($"Finale score is: {count}");

    }

}
