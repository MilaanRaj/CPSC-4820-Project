using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class IntroManager : MonoBehaviour
{
    public Image[] slides;
    public float slideDuration = 3f;
    public float fadeDuration = 1f;
    public CanvasGroup blackBackground;
    private int currentSlideIndex = -1;
    private bool isTransitioning = false;
    private SlideTextManager textManager;

    void Start()
    {
        textManager = GetComponent<SlideTextManager>();
        DontDestroyOnLoad(blackBackground.gameObject);
        blackBackground.alpha = 1;
        foreach (var slide in slides)
        {
            slide.gameObject.SetActive(false);
        }
        StartCoroutine(StartIntro());
    }

    IEnumerator StartIntro()
    {
        yield return new WaitForEndOfFrame();
        yield return StartNextSlide();
    }

    void Update()
    {
        if (!isTransitioning && currentSlideIndex >= 0 &&
            Time.timeSinceLevelLoad >= (slideDuration + fadeDuration * 2) * (currentSlideIndex + 1))
        {
            StartCoroutine(StartNextSlide());
        }
    }

    IEnumerator StartNextSlide()
    {
        isTransitioning = true;

        if (currentSlideIndex >= 0)
        {
            yield return textManager.HideSlideText();
            yield return FadeBackground(0, 1);
            yield return FadeSlide(slides[currentSlideIndex], 1, 0);
        }

        currentSlideIndex++;

        if (currentSlideIndex >= slides.Length)
        {
            blackBackground.alpha = 1;
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("TutorialAlternateView");
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            Destroy(blackBackground.gameObject);
            yield break;
        }

        slides[currentSlideIndex].gameObject.SetActive(true);
        yield return FadeSlide(slides[currentSlideIndex], 0, 1);
        yield return FadeBackground(1, 0);
        yield return textManager.ShowSlideText(currentSlideIndex);

        isTransitioning = false;
    }

    IEnumerator FadeSlide(Image slide, float from, float to)
    {
        CanvasGroup canvasGroup = slide.GetComponent<CanvasGroup>();
        if (canvasGroup == null) yield break;

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = to;
        if (to == 0) slide.gameObject.SetActive(false);
    }

    IEnumerator FadeBackground(float from, float to)
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            blackBackground.alpha = Mathf.Lerp(from, to, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        blackBackground.alpha = to;
    }
}