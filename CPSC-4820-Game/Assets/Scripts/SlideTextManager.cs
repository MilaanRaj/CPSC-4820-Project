using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class SlideTextManager : MonoBehaviour
{
    [System.Serializable]
    public class SlideText
    {
        [TextArea(3, 10)]
        public string text;
        public Vector2 boxSize = new Vector2(1000, 150);
    }

    public SlideText[] slideTexts;
    public float typewriterSpeed = 0.05f;
    public float textFadeDuration = 1f;
    public GameObject textBoxPrefab;

    private GameObject currentTextBox;
    private CanvasGroup textBoxCanvasGroup;
    private TMP_Text tmpText;
    private Canvas parentCanvas;

    void Start()
    {
        parentCanvas = GetComponentInParent<Canvas>();
        if (textBoxPrefab != null)
        {
            GameObject existingBox = GameObject.Find(textBoxPrefab.name + "(Clone)");
            if (existingBox != null) Destroy(existingBox);

            currentTextBox = Instantiate(textBoxPrefab, parentCanvas.transform);
            textBoxCanvasGroup = currentTextBox.GetComponent<CanvasGroup>();
            tmpText = currentTextBox.GetComponentInChildren<TMP_Text>();

            // Force background color
            Image panelImage = currentTextBox.GetComponent<Image>();
            if (panelImage != null)
            {
                panelImage.color = new Color(0, 0, 0, 0.85f);
                Debug.Log($"Panel color set to: {panelImage.color}");
            }
            else
            {
                Debug.Log("No Image component found!");
            }

            // Force the box to stretch almost full width
            RectTransform rectTransform = currentTextBox.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0.02f, 0);
            rectTransform.anchorMax = new Vector2(0.98f, 0);
            rectTransform.pivot = new Vector2(0.5f, 0);
            rectTransform.anchoredPosition = new Vector2(0, 100);
            rectTransform.sizeDelta = new Vector2(0, 200);

            if (tmpText != null)
            {
                RectTransform textRect = tmpText.GetComponent<RectTransform>();
                textRect.anchorMin = Vector2.zero;
                textRect.anchorMax = Vector2.one;
                textRect.offsetMin = Vector2.zero;
                textRect.offsetMax = Vector2.zero;

                tmpText.alignment = TextAlignmentOptions.Center;
                tmpText.fontSize = 84;
                tmpText.margin = new Vector4(20, 10, 20, 10);
                tmpText.enableWordWrapping = true;
            }

            textBoxCanvasGroup.alpha = 0;
        }
    }

    public IEnumerator ShowSlideText(int slideIndex)
    {
        if (slideIndex >= slideTexts.Length || currentTextBox == null) yield break;

        tmpText.text = "";
        RectTransform rectTransform = currentTextBox.GetComponent<RectTransform>();
        rectTransform.sizeDelta = slideTexts[slideIndex].boxSize;

        Image panelImage = currentTextBox.GetComponent<Image>();
        if (panelImage != null)
        {
            Color startColor = panelImage.color;
            startColor.a = 0;
            panelImage.color = startColor;
        }

        yield return FadeTextBox(0, 1);

        string fullText = slideTexts[slideIndex].text;
        foreach (char c in fullText)
        {
            tmpText.text += c;
            yield return new WaitForSeconds(typewriterSpeed);
        }
    }

    public IEnumerator HideSlideText()
    {
        if (currentTextBox == null) yield break;
        yield return FadeTextBox(1, 0);
    }

    private IEnumerator FadeTextBox(float from, float to)
    {
        float elapsedTime = 0f;
        while (elapsedTime < textFadeDuration)
        {
            textBoxCanvasGroup.alpha = Mathf.Lerp(from, to, elapsedTime / textFadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        textBoxCanvasGroup.alpha = to;
    }
}