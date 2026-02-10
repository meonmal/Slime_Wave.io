using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 플레이어 이동 제어를 위한 Movement2D
    private Movement2D movement;

    private void Awake()
    {
        // Movement2D 컴포넌트 정보 가져오기
        movement = GetComponent<Movement2D>();
    }

    private void FixedUpdate()
    {
        // x축 이동
        movement.MoveToX();

        // 마우스 왼쪽 버튼을 누르는 동안 실행
        if (Input.GetMouseButton(0))
        {
            // y축 이동
            movement.MoveToY();
        }
    }
}
