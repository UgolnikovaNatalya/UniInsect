using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    private Text records;


    private List<int> results = new List<int> { 0, 0, 0 };
    private List<string> usersName = new List<string> {"", "", ""};

    private int savedListCount;
    
    private int userRes;
    private int resPosition;
    private string nameUser;

    private const string recCount = "listCount";
    private const string listRec = "listResults";

    private const string listName = "names";

    public void SaveList()
    {
        //сохраняем лист с рекордами
        for (int i = 0; i < results.Count; i++)
        {
            PlayerPrefs.SetInt(listRec + i, results[i]);
        }
        PlayerPrefs.SetInt(recCount, results.Count);

        //сохраняем лист с именами
        for (int i = 0; i < usersName.Count; i++)
        {
            PlayerPrefs.SetString(listName + i, usersName[i]);
        }
        PlayerPrefs.SetInt(recCount, usersName.Count);
    }

    public void LoadList()
    {
        //загружаем лист с рекордами
        results.Clear();
        savedListCount = PlayerPrefs.GetInt(recCount);

        for (int i = 0; i < savedListCount; i++)
        {
            int num = PlayerPrefs.GetInt(listRec + i);
            results.Add(num);
        }

        //загружаем лист с именами
        usersName.Clear();
        savedListCount = PlayerPrefs.GetInt(recCount);

        for (int i = 0; i < savedListCount; i++)
        {
            string name = PlayerPrefs.GetString(listName + i);
            usersName.Add(name);
        }
    }

    private void Awake()
    {
        Debug.LogError("AWAKE");

        LoadList();

        userRes = PlayerPrefs.GetInt("r");
        nameUser = PlayerPrefs.GetString ("username");

        if (nameUser == null || nameUser == "")
        {
            nameUser = "No name";
        }

    } 

    private void Start()
    {
        Debug.LogError("START");

        records = FindObjectOfType<Text>();

        if (userRes > results[2])
        {
            results[2] = userRes;

            results.Sort();
            results.Reverse();

        }

        for (int i = 0; i < results.Count; i++)
        {
            if (results[i] == userRes)
            {
                resPosition = results.IndexOf(results[i]);
            }

        }
            Debug.LogError("IndexOf " + resPosition);

        usersName.Insert(resPosition, nameUser);

        SaveList();

        userRes = 0;
        PlayerPrefs.SetInt("r", userRes);
        nameUser = "";
        PlayerPrefs.SetString("username", nameUser);

        records.text = $"{usersName[0]} {results[0]}\n{usersName[1]} {results[1]}\n{usersName[2]} {results[2]}";





    }

}