using UnityEngine;

public class Stump : MonoBehaviour
{
    public static float speed;
    void Start()
    {
        
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
}
