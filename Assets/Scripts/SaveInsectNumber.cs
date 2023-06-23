using UnityEngine;
using UnityEngine.UI;

//класс дл€ сохранени€ количества насекомых
//введеных пользователем
public class SaveInsectNumber : MonoBehaviour
{
    //объ€вл€ем поле ввода
    public InputField field;
    //объ€вл€ем кнопку
    public Button startGameBtn;

    public void SaveInsects()
    {
        //сохранение значени€ пол€ ввода
        //если оно пустое или null присвоитс€ значение 0
        if (field.text == "" || field.text == null)
        {
            field.text = "0";
        }
        //сохранение данных в хеш приложени€
        PlayerPrefs.SetString("inse", field.text);
        PlayerPrefs.Save();

    }
}
