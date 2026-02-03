using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private float speed;


    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < -100)
        {
            Destroy(gameObject);
        }
    }
}
