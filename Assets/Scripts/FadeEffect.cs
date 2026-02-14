using System.Collections;
using TMPro;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    // 페이드 되는 시간
    [SerializeField]
    private float fadeTime;
    // 페이트 효과에 사용되는 Text
    private TextMeshProUGUI textFade;

    private void Awake()
    {
        textFade = GetComponent<TextMeshProUGUI>();

        StartCoroutine(FadeInOut());
    }

    /// <summary>
    /// Fade In <-> Fade Out 무한 반복
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeInOut()
    {
        while (true)
        {
            yield return StartCoroutine(Fade(1, 0));

            yield return StartCoroutine(Fade(0, 1));
        }
    }

    /// <summary>
    /// 텍스트의 알파 값을 바꾸는 코루틴 함수
    /// </summary>
    /// <param name="start">시작 알파 값</param>
    /// <param name="end">종료 알파 값</param>
    /// <returns></returns>
    private IEnumerator Fade(float start, float end)
    {
        float percent = 0;

        while(percent < 1)
        {
            percent += Time.deltaTime / fadeTime;

            Color color = textFade.color;
            color.a = Mathf.Lerp(start, end, percent);
            textFade.color = color;

            yield return null;
        }
    }
}
