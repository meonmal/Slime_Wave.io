using UnityEngine;

public class Rotator : MonoBehaviour
{
    // 회전 속도(+- 방향도 함께 설정)
    [SerializeField]
    private float rotateSpeed = 50f;
    // 회전 방향
    private Vector3 rotateAxis = Vector3.forward;

    private void Update()
    {
        // 2D 게임이기 때문에 z축 회전만 하도록 Vector3.forward 방향으로 설정
        transform.Rotate(rotateAxis, rotateSpeed * Time.deltaTime);
    }
}
