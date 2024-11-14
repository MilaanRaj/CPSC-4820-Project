using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI progressText;

    public float FillSpeed = 0.5f;
    private float targetProgress = 0f;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;  // Prevents the scene from activating until loading is complete

        loadingScreen.SetActive(true);
        slider.value = 0f;

        while (!operation.isDone)
        {
            // Update the target progress based on loading progress
            targetProgress = operation.progress;

            // Smoothly increase the slider value towards targetProgress
            slider.value = Mathf.MoveTowards(slider.value, targetProgress, FillSpeed * Time.deltaTime);

            // Update the progress text to reflect the slider's current value
            progressText.text = Mathf.RoundToInt(slider.value * 100f) + "%";

            // If loading is done, activate the scene
            if (operation.progress >= 0.9f)
            {
                targetProgress = 1f; // Fully load the slider
                slider.value = Mathf.MoveTowards(slider.value, targetProgress, FillSpeed * Time.deltaTime);

                // Update text when slider reaches 100%
                progressText.text = Mathf.RoundToInt(slider.value * 100f) + "%";

                // Wait until the slider is fully filled
                if (slider.value >= 0.9f)
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}
