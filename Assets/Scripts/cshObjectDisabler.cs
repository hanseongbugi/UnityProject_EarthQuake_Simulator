using UnityEngine;

public class cshObjectDisabler : MonoBehaviour
{
    public float delay = 3f;
    public GameObject targetObject;

    private void Start()
    {
        Invoke("DisableObject", delay);
    }

    private void DisableObject()
    {
        targetObject.SetActive(false);
    }
}
