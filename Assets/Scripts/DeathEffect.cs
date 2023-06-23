using System.Collections;
using UnityEngine;

/*
 * Класс для проигрывания аудио при убийстве 
 */
public class DeathEffect : MonoBehaviour
{
    //время после которого, уничтожится объект
    private float _delayToDestroy = 2f;

    //проигрывание звука
    public AudioSource clip;

    private void Start()
    {
        //создание ссылки на аудио
        clip = GetComponent<AudioSource>();
        //старт корутины
        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        //проигрывание аудио
        clip.Play();

        //остановка корутины на 2 секунды
        //с последующим уничтожением объекта (аудио)
        yield return new WaitForSeconds(_delayToDestroy);
        Destroy(gameObject);
    }
}
