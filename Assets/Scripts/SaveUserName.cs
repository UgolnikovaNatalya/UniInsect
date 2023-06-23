using UnityEngine;
using UnityEngine.UI;

//класс для сохранения имени пользователя
public class SaveUserName : MonoBehaviour
{
    //определяем поле ввода на сцене
    public InputField field;

    public void SaveName()
    {
        //сохранение значения поля ввода
        //если оно пустое или null присвоится значение No name
        if (field.text == "" || field.text == null)
        {
            field.text = "No name";
        }

        //сохранение данных в хеш приложения
        PlayerPrefs.SetString("userName", field.text);
        PlayerPrefs.Save();
    }
        
}
