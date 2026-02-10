using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField]
    private float xMoveSpeed = 2.5f;        // 좌우 이동 속도
    [SerializeField]
    private float xDelta = 2f;                 // 좌/우 변동 값(이동 범위)
    private float xStartPosition;             // x축 시작 위치

    [Header("Vertical Movement")]
    [SerializeField]
    private float yMoveSpeed = 0.2f;        // 전진 이동속도
    private Rigidbody2D rigid2D;              // AddForceY() 사용을 위한 Rigidbody2D 컴포넌트

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();

        // x축 시작 위치를 현재 자신의 x축의 값을 할당
        xStartPosition = transform.position.x;
    }

    /// <summary>
    /// x축 이동을 위해 외부에서 호출할 함수
    /// </summary>
    public void MoveToX()
    {
        // x축 이동 값 계산(x축 시작 위치 + 변위 값)
        float x = xStartPosition + Mathf.Sin(Time.time * xMoveSpeed) * xDelta;
        // x축 이동
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    /// <summary>
    /// Rigidbody2D를 이용해 y축을 이동시키는 함수
    /// </summary>
    public void MoveToY()
    {
        // AddForceY()를 이용해 위로 이동하는 힘을 준다.
        rigid2D.AddForceY(yMoveSpeed, ForceMode2D.Impulse);
    }
}
