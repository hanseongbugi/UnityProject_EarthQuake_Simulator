using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Action : MonoBehaviour
{
    public GameObject Target; // ī�޶� ����ٴ� Ÿ��

    public float offsetX = 0.0f; // ī�޶��� x��ǥ
    public float offsetY = 3f; // ī�޶��� y��ǥ (���� ����)
    public float offsetZ = -6.0f; // ī�޶��� z��ǥ (�Ÿ� ����)

    public float CameraSpeed = 10.0f; // ī�޶��� �ӵ�
    Vector3 TargetPos; // Ÿ���� ��ġ
	private void Start()
	{
        Vector3 targetHeadPosition = new Vector3(Target.transform.position.x, offsetY, Target.transform.position.z);

        // Ÿ���� x, y, z ��ǥ�� ī�޶��� ��ǥ�� ���Ͽ� ī�޶��� ��ġ�� ����
        TargetPos = targetHeadPosition + Target.transform.forward * offsetZ + Target.transform.right * offsetX;

        // ī�޶��� �������� �ε巴�� �ϴ� �Լ�(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, Target.transform.rotation, Time.deltaTime * CameraSpeed);
    }
	void Update()
    {
        // ĳ������ �Ӹ� ��ġ ���
        Vector3 targetHeadPosition =new Vector3(Target.transform.position.x,  offsetY, Target.transform.position.z);

        // Ÿ���� x, y, z ��ǥ�� ī�޶��� ��ǥ�� ���Ͽ� ī�޶��� ��ġ�� ����
        TargetPos = targetHeadPosition + Target.transform.forward * offsetZ + Target.transform.right * offsetX;

        // ī�޶��� �������� �ε巴�� �ϴ� �Լ�(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, Target.transform.rotation, Time.deltaTime * CameraSpeed);
    }
}
