using UnityEngine;

public class CamShake : MonoBehaviour
{
    [SerializeField] private Animator camShake;
    [SerializeField] private AudioClip quakeSound;

    private AudioSource source;

    private void Shake()
    {
        camShake.SetTrigger("Shake");
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Shake();
            source.PlayOneShot(quakeSound);
        }
    }
}
