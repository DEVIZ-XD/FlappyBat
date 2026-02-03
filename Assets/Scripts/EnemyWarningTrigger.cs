using UnityEngine;
using System.Collections;

public class EnemyWarningTrigger : MonoBehaviour
{
    [Header("Выбери предупреждения галочками")]
    [SerializeField] private bool showUpWarning = false;
    [SerializeField] private bool showMidWarning = false;
    [SerializeField] private bool showDownWarning = false;

    [Header("UI элементы")]
    [SerializeField] private GameObject upWarning;
    [SerializeField] private GameObject midWarning;
    [SerializeField] private GameObject downWarning;

    [Header("Мигание")]
    [SerializeField] private float blinkInterval = 0.3f;

    [Header("Звук")]
    [SerializeField] private AudioSource warningSound;

    private Coroutine blinkCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        EnableSelectedWarnings();
        blinkCoroutine = StartCoroutine(BlinkWarnings());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;
        }
        DisableAllWarnings();
    }

    private void EnableSelectedWarnings()
    {
        if (showUpWarning) upWarning.SetActive(true);
        if (showMidWarning) midWarning.SetActive(true);
        if (showDownWarning) downWarning.SetActive(true);
    }

    private void DisableAllWarnings()
    {
        upWarning.SetActive(false);
        midWarning.SetActive(false);
        downWarning.SetActive(false);
    }

    private IEnumerator BlinkWarnings()
    {
        while (true)
        {
            // Выключаем UI
            if (showUpWarning) upWarning.SetActive(false);
            if (showMidWarning) midWarning.SetActive(false);
            if (showDownWarning) downWarning.SetActive(false);

            yield return new WaitForSeconds(blinkInterval);

            // Включаем UI + играем звук
            EnableSelectedWarnings();
            if (warningSound) warningSound.Play();

            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
