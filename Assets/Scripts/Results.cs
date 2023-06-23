using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Класс отвечающий за сохранение данных и вывод статистики
 */
public class Results : MonoBehaviour
{
    private Text textRecord;

    //лист в котором хранятся рекорды
    private List<int> listOfRecords = new List<int> { 0, 0, 0 };
    //лист в котором хранятся имена
    private List<string> listOfUsers = new List<string> { "", "", "" };
    //размер сохраняемых листов
    private int listLength;
    //очки, набранные пользователем
    private int userPoints;
    //имя игрока
    private string userName;
    //позиция рекорда, по которой в лист с именами записывается имя
    private int indexPosition;

    //функция сохранения листов
    public void SaveList()
    {
        //сохраняем лист с рекордами
        for (int i = 0; i < listOfRecords.Count; i++)
        {
            PlayerPrefs.SetInt("listOfRecords" + i, listOfRecords[i]);
        }
        PlayerPrefs.SetInt("listLength", listOfRecords.Count);

        ////сохраняем лист с именами
        for (int i = 0; i < listOfUsers.Count; i++)
        {
            PlayerPrefs.SetString("listOfUsers" + i, listOfUsers[i]);
        }
        PlayerPrefs.SetInt("listLength", listOfUsers.Count);
    }

    //функция восстановления листов
    public void LoadList()
    {
        //загружаем лист с рекордами
        listOfRecords.Clear();

        //загружаем и проверяем длину списка
        if (PlayerPrefs.HasKey("listLength"))
        {
            listLength = PlayerPrefs.GetInt("listLength");
        }
        else
        {
            listLength = 3;
        }

        for (int i = 0; i < listLength; i++)
        {
            int num = PlayerPrefs.GetInt("listOfRecords" + i);
            listOfRecords.Add(num);
        }


        //загружаем лист с именами
        listOfUsers.Clear();

        for (int i = 0; i < listLength; i++)
        {
            string name = PlayerPrefs.GetString("listOfUsers" + i);
            listOfUsers.Add(name);
        }

    }

    //получаем данные об имени и очках
    public void LoadPointsAndName()
    {
        //проверяем наличие очков
        if (PlayerPrefs.HasKey("r"))
        {
            userPoints = PlayerPrefs.GetInt("r");
        }
        else
        {
            userPoints = 0;
        }

        ////проверяем наличие имени
        if (PlayerPrefs.HasKey("userName"))
        {
            userName = PlayerPrefs.GetString("userName");
        }
        else
        {
            userName = "No name";
        }
    }

    private void Awake()
    {
        //загружаем листы
        LoadList();
        //загружаем данные
        LoadPointsAndName();
        //определяем текстовый объект на сцене
        textRecord = FindObjectOfType<Text>();
    }

    private void Start()
    {
        //проверяем число на топ-3
        if (userPoints > listOfRecords[2])
        {
            listOfRecords[2] = userPoints;

            listOfRecords.Sort();
            listOfRecords.Reverse();
        }

        //если число попало, то добавляем имя
        indexPosition = listOfRecords.IndexOf(userPoints);
        Debug.Log("pos " + indexPosition);
        listOfUsers.Insert(indexPosition, userName);

        //вывод на экран
        textRecord.text = $"{listOfRecords[0]}\t{listOfUsers[0]}\n" +
            $"{listOfRecords[1]}\t{listOfUsers[1]}\n{listOfRecords[2]}\t{listOfUsers[2]}";


        //сбрасываем значения
        userName = "No name";
        userPoints = 0;
        PlayerPrefs.SetInt("r", userPoints);
        PlayerPrefs.SetString("userName", userName);
        //сохраняем листы
        SaveList();
        PlayerPrefs.SetString("userName", userName);
    }

}