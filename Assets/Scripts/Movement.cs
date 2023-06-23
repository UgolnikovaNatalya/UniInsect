using UnityEngine;

/*
 * Класс описывающий передвижение объектов
 */
public class Movement : MonoBehaviour
{
    //массив точек, по которым двигаются объекты
    public Transform[] moveSpots;

    //точка к которой будет двигаться объект
    private int randomSpot;
    //скорость передвижения объекта
    private float speed = 2f;

    private void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    private void Update()
    {
        //описание передвижения объекта от точки к точке
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
        }
    }

}
