using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshGenerateEarthQuake : MonoBehaviour
{
    public float movementRange = 0.3f; // 이동 가능한 범위
    public Slider speedSlider; // Slider UI 요소를 가리키는 변수
    public float minSpeed = 1f; // 최소 속도
    public float maxSpeed = 10f; // 최대 속도
    private float currentSpeed; // 현재 속도
    private Vector3 targetPosition; // 목표 위치
    public GameObject destroyEffectPrefab;

    private void Start()
    {
        currentSpeed = 0;
        SetRandomTargetPosition();

    }

    private void Update()
    {
        currentSpeed = speedSlider.value;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }

    }
	private void OnTriggerEnter(Collider collision)
	{
		if (collision.CompareTag("Bullet"))
		{
            //Instantiate()
            Instantiate(destroyEffectPrefab, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
		}
	}

	public void OnSpeedChanged()
    {
        currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, speedSlider.value / speedSlider.maxValue);
    }

    private void SetRandomTargetPosition()
    {
        float randomX = Random.Range(-movementRange, movementRange);
        float randomY = Random.Range(-movementRange, movementRange);
        float randomZ = Random.Range(-movementRange, movementRange);

        targetPosition = new Vector3(randomX, randomY, randomZ);
    }

}
