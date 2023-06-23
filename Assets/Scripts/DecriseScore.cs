using UnityEngine;

/*
 * Класс для уменьшения очков
 * в случае, если игрок промахнулся
 * по насекомому
 */
public class DecriseScore : MonoBehaviour
{
    //ссылка на объект класса Score
    public Score scores;
    //ссылка на объект класса InsectSpawn
    public InsectSpawn timer;


    private void Start()
    {
        //Привязка к объектам, указанных классов
        scores = FindObjectOfType<Score>(); 
        timer = FindObjectOfType<InsectSpawn>();
    }

    //обработчик нажатия на экран смартфона или мышь
    private void OnMouseDown()
    {
        //снятие очков пока их общее количество не меньше 0
        if (timer.gameTimer > 0)
        {
            scores.Miss();
        } 
        
    }
}
