using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public static float speed;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
