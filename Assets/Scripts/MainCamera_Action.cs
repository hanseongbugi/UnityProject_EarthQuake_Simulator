using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Action : MonoBehaviour
{
    public GameObject Target; // 카메라가 따라다닐 타겟

    public float offsetX = 0.0f; // 카메라의 x좌표
    public float offsetY = 3f; // 카메라의 y좌표 (높이 조절)
    public float offsetZ = -6.0f; // 카메라의 z좌표 (거리 조절)

    public float CameraSpeed = 10.0f; // 카메라의 속도
    Vector3 TargetPos; // 타겟의 위치
	private void Start()
	{
        Vector3 targetHeadPosition = new Vector3(Target.transform.position.x, offsetY, Target.transform.position.z);

        // 타겟의 x, y, z 좌표에 카메라의 좌표를 더하여 카메라의 위치를 결정
        TargetPos = targetHeadPosition + Target.transform.forward * offsetZ + Target.transform.right * offsetX;

        // 카메라의 움직임을 부드럽게 하는 함수(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, Target.transform.rotation, Time.deltaTime * CameraSpeed);
    }
	void Update()
    {
        // 캐릭터의 머리 위치 계산
        Vector3 targetHeadPosition =new Vector3(Target.transform.position.x,  offsetY, Target.transform.position.z);

        // 타겟의 x, y, z 좌표에 카메라의 좌표를 더하여 카메라의 위치를 결정
        TargetPos = targetHeadPosition + Target.transform.forward * offsetZ + Target.transform.right * offsetX;

        // 카메라의 움직임을 부드럽게 하는 함수(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, Target.transform.rotation, Time.deltaTime * CameraSpeed);
    }
}
