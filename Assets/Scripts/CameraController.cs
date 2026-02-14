using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;                       // 카메라가 쫓아다닐 대상(플레이어)
    [SerializeField]
    private float yOffset = 8;                       // y 위치 값
    [SerializeField]
    private float smoothTime = 0.3f;               // 부드럽게 이동하는 시간
    private Vector3 velocity = Vector3.zero;      // 값의 변화량(= 현재 속도)
    // 배경 색상 변경을 위한 Camera
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        // 월드 좌표 = TransformPoint(로컬 좌표)
        // 로컬 상의 좌표 기준으로 항상 (0, yOffset, -10)을 유지하도록 월드 좌표를 설정한다.
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, yOffset, -10));
        targetPosition = new Vector3(0, targetPosition.y, targetPosition.z);

        // 목표 위치까지 부드럽게 이동할 때 사용하는 메소드
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    public void ChangeBackgroundColor()
    {
        // 0.1 단위로 0.0 ~ 1.0 사이의 값 중 임의의 값 선택
        float colorHue = Random.Range(0, 10);
        colorHue *= 0.1f;
        mainCamera.backgroundColor = Color.HSVToRGB(colorHue, 0.6f, 0.8f);
    }
}
