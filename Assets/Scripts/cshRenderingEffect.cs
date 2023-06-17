using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshRenderingEffect : MonoBehaviour
{
    public GameObject targetObject;
    private bool isActive = false;
    private float timer = 0f;
    private float offTime = 5f;
    private float onTime = 1f;

    public void StartToggling(GameObject target)
    {
        targetObject = target;
        isActive = false;
        timer = 0f;
    }

    private void Start()
    {
        targetObject.SetActive(false);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (!isActive && timer >= offTime)
        {
            // ���� ���¿��� ���� ���·� ��ȯ
            targetObject.SetActive(true);
            isActive = true;
            timer = 0f;
        }
        else if (isActive && timer >= onTime)
        {
            // ���� ���¿��� ���� ���·� ��ȯ
            targetObject.SetActive(false);
            isActive = false;
            timer = 0f;

            if (offTime == 0.5f)
            {
                // offTime�� 0.5���� �� ���� ���·� ��ȯ
                targetObject.SetActive(true);
                isActive = true;
            }
        }

        if (!isActive && offTime == 0.5f && timer >= 0.5f)
        {
            // ���� ���¿��� 0.5�� �Ŀ� ���� ���·� ��ȯ
            targetObject.SetActive(true);
            isActive = true;
            timer = 0f;
        }
    }
}
