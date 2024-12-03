using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public Image[] slides; // Assign your slide images in the Inspector
    public float slideDuration = 3f; // Time each slide stays on screen

    private int currentSlideIndex = 0;
    private float timer;

    void Start()
    {
        ShowSlide(0);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= slideDuration)
        {
            timer = 0f;
            currentSlideIndex++;

            if (currentSlideIndex >= slides.Length)
            {
                // Transition to the tutorial scene
                TransitionToTutorial();
                return;
            }
            else
            {
                ShowSlide(currentSlideIndex);
            }
        }
    }

    void TransitionToTutorial()
    {
        SceneManager.LoadScene("Tutorial"); // Load the tutorial scene
        Destroy(this.gameObject); // Immediately destroy the IntroManager object
    }

    void ShowSlide(int index)
    {
        // Loop through all slides and deactivate them
        for (int i = 0; i < slides.Length; i++)
        {
            slides[i].gameObject.SetActive(i == index); // Activate only the current slide
        }
    }

}
