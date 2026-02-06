using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float rotatePower;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float stumpSpeed;
    [SerializeField] private float frogSpeed;
    [SerializeField] private float backgroundSpeed;
    [SerializeField] private float speed;
    [SerializeField] private AudioClip jumpSound;

    private AudioSource source;
    private Rigidbody rb;

 
    private void Start()
    {
        Stump.speed = stumpSpeed;
        Frog.speed = frogSpeed;
        ObjectsMovement.speed = speed;
        BackgroundMovement.speed = backgroundSpeed;
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        rb.linearVelocity = Vector3.up * jumpSpeed;
        source.PlayOneShot(jumpSound);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            source.PlayOneShot(jumpSound);
            rb.linearVelocity = Vector3.up * jumpSpeed;
        }
        transform.eulerAngles = new Vector3(rb.linearVelocity.y * rotatePower, -90, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("trap"))
        {
            Score.score++;
        }
    }
}