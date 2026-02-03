using UnityEngine;

public class ObjectsMovement : MonoBehaviour
{
    public static float speed;


    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < -50)
        {
            Destroy(gameObject);
        }
    }
}
