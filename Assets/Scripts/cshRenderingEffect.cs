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
            // 꺼짐 상태에서 켜짐 상태로 전환
            targetObject.SetActive(true);
            isActive = true;
            timer = 0f;
        }
        else if (isActive && timer >= onTime)
        {
            // 켜짐 상태에서 꺼짐 상태로 전환
            targetObject.SetActive(false);
            isActive = false;
            timer = 0f;

            if (offTime == 0.5f)
            {
                // offTime이 0.5초일 때 켜짐 상태로 전환
                targetObject.SetActive(true);
                isActive = true;
            }
        }

        if (!isActive && offTime == 0.5f && timer >= 0.5f)
        {
            // 꺼짐 상태에서 0.5초 후에 켜짐 상태로 전환
            targetObject.SetActive(true);
            isActive = true;
            timer = 0f;
        }
    }
}
