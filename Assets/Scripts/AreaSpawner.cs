using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    // 구역 프리팹 배열
    [SerializeField]
    private GameObject[] areaPrefabs;
    // 플레이어의 Transform 정보(새로운 구역 생성용)
    [SerializeField]
    private Transform player;
    // 게임 시작 시 최초 생성되는 구역 개수
    [SerializeField]
    private int spawnAreaAtStart = 2;
    // 구역 사이의 거리
    [SerializeField]
    private float distanceToNext = 30;

    // 구역은 생성된 순서대로 삭제하기 때문에 Queue에 저장 후 삭제
    private Queue<GameObject> queueAreas;
    // 구역 인덱스(배치되는 구역의 위치 연산에 활용)
    private int areaIndex = 0;

    private void Awake()
    {
        // queueAreas에 메모리를 할당
        queueAreas = new Queue<GameObject>();

        for(int i =0; i<spawnAreaAtStart; i++)
        {
            SpawnArea();
        }
    }

    private void Update()
    {
        int playerIndex = (int)(player.position.y / distanceToNext);

        if(playerIndex == areaIndex - 1)
        {
            SpawnArea();
            // 큐 목록에서 가장 앞에 있는 구역 삭제
            Destroy(queueAreas.Dequeue());
        }
    }

    private void SpawnArea()
    {
        // 여러 개의 구역 중 임의의 구역 인덱스 선택
        int index = Random.Range(0, areaPrefabs.Length);

        // 선택된 index번째 구역 생성
        GameObject clone = Instantiate(areaPrefabs[index]);

        // 구역이 배치 되는 위치 설정(0, distanceToNext * areaIndex, 0)
        clone.transform.position = Vector3.up * distanceToNext * areaIndex;

        // 구역이 배치되는 y위치를 계속 증가시켜주기 위해 구역이 생성될 때마다 증가
        areaIndex++;

        queueAreas.Enqueue(clone);
    }
}
