using System.Collections;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    private float _delayToDestroy = 2f;

    [SerializeField]
    public AudioSource clip;

    private void Start()
    {
        clip = GetComponent<AudioSource>();
        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        clip.Play();

        yield return new WaitForSeconds(_delayToDestroy);
        Destroy(gameObject);
    }
}
