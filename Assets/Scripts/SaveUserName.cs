using UnityEngine;
using UnityEngine.UI;

public class SaveUserName : MonoBehaviour
{
    public InputField field;
    //public Button startGameBtn;

    public void SaveName()
    {

        if (field.text == "" || field.text == null)
        {
            field.text = "No name";
        }

        PlayerPrefs.SetString("username", field.text);
        PlayerPrefs.Save();

        Debug.LogError($"SaveName {PlayerPrefs.GetString("username", field.text)}");
    }
        
}
