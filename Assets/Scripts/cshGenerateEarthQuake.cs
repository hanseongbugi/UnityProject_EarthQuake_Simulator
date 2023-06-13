using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshGenerateEarthQuake : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; // ������ �ӵ�
    public float movementRange = 10f; // �̵� ������ ����

    private Vector3 targetPosition; // ��ǥ ��ġ

    void Start()
    {
        SetRandomTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // ��ǥ ��ġ�� �����ϸ� ���ο� ��ǥ ��ġ ����
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }

    }
    private void SetRandomTargetPosition()
    {
        // ������ x�� z ��ǥ ����
        float randomX = Random.Range(-movementRange, movementRange);
        float randomY = Random.Range(-movementRange, movementRange);
        float randomZ = Random.Range(-movementRange, movementRange);

        // ���ο� ��ǥ ��ġ ����
        targetPosition = new Vector3(randomX, randomY, randomZ);
    }
}
