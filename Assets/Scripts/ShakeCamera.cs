using System.Collections;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private float shakeTIme;
    private float shakeIntensity;

    public void OnShakeCamera(float shakeTime = 1.0f, float shackIntensity = 0.1f)
    {
        this.shakeTIme = shakeTime;
        this.shakeIntensity = shackIntensity;

        StopCoroutine(nameof(ShakeByRotation));
        StartCoroutine(nameof(ShakeByRotation));
    }

    private IEnumerator ShakeByRotation()
    {
        // 흔들리기 직전의 회전 값
        Vector3 startRotation = transform.eulerAngles;
        // 회전의 경우 shakeIntensity에 더 큰 값이 필요하기 때문에 변수로 만들었음
        // (클래스 멤버변수로 선언해 외부에서 조작 가능)
        float power = 10f;

        while(shakeTIme > 0.0f)
        {
            // 회전하길 원하는 축만 지정해서 사용(회전하지 않을 축은 0으로 설정)
            // (클래스 멤버변수로 선언해 외부에서 조작하면 더 좋다)
            float x = 0;
            float y = 0;
            float z = Random.Range(-1f, 1f);
            transform.rotation = Quaternion.Euler(startRotation + new Vector3(x, y, z) * shakeIntensity * power);

            // 시간 감소
            shakeTIme -= Time.deltaTime;

            yield return null;
        }

        // 흔들리기 직전의 회전 값으로 설정
        transform.rotation = Quaternion.Euler(startRotation);
    }
}
