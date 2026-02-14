using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StageController stageController;
    [SerializeField]
    private ShakeCamera shakeCamera;
    // 플레이어 사망 효과
    [SerializeField]
    private GameObject playerDieEffect;
    // 플레이어 이동 제어를 위한 Movement2D
    private Movement2D movement;

    private void Awake()
    {
        // Movement2D 컴포넌트 정보 가져오기
        movement = GetComponent<Movement2D>();
    }

    private void FixedUpdate()
    {
        // 플레이어가 사망한 상태에서는 조작 불가능
        if(stageController.IsGameOver == true)
        {
            return;
        }

        // x축 이동
        movement.MoveToX();

        // 마우스 왼쪽 버튼을 누르는 동안 실행
        if (Input.GetMouseButton(0))
        {
            // y축 이동
            movement.MoveToY();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            // 아이템 획득으로 점수 +1
            stageController.IncreaseScore(1);

            // 충돌한 게임 오브젝트(점수 아이템) 삭제
            collision.GetComponent<Item>().Exit();
        }
        else if (collision.CompareTag("Obstacle"))
        {
            shakeCamera.OnShakeCamera(0.5f, 0.1f);
            // 플레이어 사망 효과 재생
            Instantiate(playerDieEffect, transform.position, Quaternion.identity);

            // 플레이어가 장애물과 충돌해 사망하면 물리 효과를 받지 않도록 하기 위해 Rigidbody2D 컴포넌트 삭제
            Destroy(GetComponent<Rigidbody2D>());

            stageController.GameOver();
        }
    }
}
