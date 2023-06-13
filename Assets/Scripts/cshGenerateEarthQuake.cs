using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshGenerateEarthQuake : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; // 움직임 속도
    public float movementRange = 10f; // 이동 가능한 범위

    private Vector3 targetPosition; // 목표 위치

    void Start()
    {
        SetRandomTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // 목표 위치에 도착하면 새로운 목표 위치 설정
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }

    }
    private void SetRandomTargetPosition()
    {
        // 랜덤한 x와 z 좌표 생성
        float randomX = Random.Range(-movementRange, movementRange);
        float randomY = Random.Range(-movementRange, movementRange);
        float randomZ = Random.Range(-movementRange, movementRange);

        // 새로운 목표 위치 설정
        targetPosition = new Vector3(randomX, randomY, randomZ);
    }
}
