using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject WinMenu;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WinMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
