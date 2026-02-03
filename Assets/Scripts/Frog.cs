using UnityEngine;

public class Frog : MonoBehaviour
{
    public static float speed;
    private Rigidbody rb;

    [SerializeField] private float minJumpSpeed = 8f;
    [SerializeField] private float maxJumpSpeed = 12f;
    [SerializeField] private AudioClip jumpSound;

    private AudioSource source;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            float jumpSpeed = Random.Range(minJumpSpeed, maxJumpSpeed);
            rb.linearVelocity = Vector3.up * jumpSpeed;
            source.PlayOneShot(jumpSound);
        }
    }
}
