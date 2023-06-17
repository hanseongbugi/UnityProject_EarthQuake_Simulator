using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class cshPhtonGenerateEarthQuake : MonoBehaviourPun
{
    public float movementRange = 0.3f; // 이동 가능한 범위
    public Slider speedSlider; // Slider UI 요소를 가리키는 변수
    public float minSpeed = 1f; // 최소 속도
    public float maxSpeed = 10f; // 최대 속도
    private float currentSpeed; // 현재 속도
    private Vector3 targetPosition; // 목표 위치
    

    private void Start()
    {
        currentSpeed = 0;
        SetRandomTargetPosition();

    }

    private void Update()
    {
        if (speedSlider!=null)
        {
            //Debug.Log("update");
            PhotonView pv = GetComponent<PhotonView>();
            pv.RPC("SyncSliderValue", RpcTarget.All, speedSlider.value);

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                SetRandomTargetPosition();
            }
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
    [PunRPC]
    private void SyncSliderValue(float value)
    {
        currentSpeed = value;
        speedSlider.value = value;
    }
}
