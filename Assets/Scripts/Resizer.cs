using System.Collections;
using UnityEngine;

public class Resizer : MonoBehaviour
{
    // 시작 크기(transform.localScale)
    private Vector3 startSize;

    // 종료 크기
    [SerializeField]
    private Vector3 endSize;
    // 크기 변화에 소요되는 시간
    [SerializeField]
    private float resizeTime;

    private IEnumerator Start()
    {
        startSize = transform.localScale;

        while (true)
        {
            // resizeTime동안 start에서 end로 크기 변화
            yield return StartCoroutine(Resize(startSize, endSize, resizeTime));

            // resizeTime동안 end에서 start로 크기 변환
            yield return StartCoroutine(Resize(endSize, startSize, resizeTime));
        }
    }

    /// <summary>
    /// 해당 오브젝트의 크기를 변환시키는 코루틴
    /// </summary>
    /// <param name="start">시작 크기</param>
    /// <param name="end">종료 크기</param>
    /// <param name="time">변환되는 시간</param>
    /// <returns></returns>
    private IEnumerator Resize(Vector3 start, Vector3 end, float time)
    {
        // start에서 end까지 반환할 값
        float percent = 0;

        while(percent < 1)
        {
            // perent를 계속 늘려주다가 1이 되면 반복문 실행 종료
            percent += Time.deltaTime / time;

            // 오브젝트의 크기를 변경
            transform.localScale = Vector3.Lerp(start, end, percent);

            yield return null;
        }
    }
}
