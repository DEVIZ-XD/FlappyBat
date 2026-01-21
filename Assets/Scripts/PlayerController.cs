using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float rotatePower;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float speed;
    [SerializeField] private AudioClip jumpSound;

    private AudioSource source;
    private Rigidbody rb;

 
    private void Start()
    {
        Stump.speed = speed;
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            source.PlayOneShot(jumpSound);
            rb.linearVelocity = Vector3.up * jumpSpeed;
        }
        transform.eulerAngles = new Vector3(rb.linearVelocity.y * rotatePower, -90, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene("Game");
    }

    private void OnTriggerEnter(Collider collision)
    {
        Score.score++;
    }
}