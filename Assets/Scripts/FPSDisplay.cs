using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    private float fps;
    [SerializeField] TMPro.TextMeshProUGUI FPSCounterText;
    public enum limits
    {
        noLimit = 0,
        limit30 = 30,
        limit60 = 60,
        limit120 = 120,
        limit240 = 120,
    }

    [SerializeField] limits limit;

    private void Awake()
    {
        Application.targetFrameRate = (int)limit;
    }
    void Start()
    {
        InvokeRepeating("GetFPS", 1, 1);
    }

    private void GetFPS()
    {
        fps = (int)(1f / Time.unscaledDeltaTime);
        FPSCounterText.text = "FPS: " + fps.ToString();
    }
}
