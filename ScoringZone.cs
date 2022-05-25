using UnityEngine;
using UnityEngine.Events;


private AudioSource audioSource;

private void Start()
{
    audioSource = GetComponent<AudioSource>();
}
[RequireComponent(typeof(BoxCollider2D))]
public class ScoringZone : MonoBehaviour
{
    public UnityEvent scoreTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null) {
            scoreTrigger.Invoke();
        }

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

}
