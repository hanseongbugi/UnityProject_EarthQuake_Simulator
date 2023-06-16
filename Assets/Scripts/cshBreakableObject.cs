using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBreakableObject : MonoBehaviour
{
    public GameObject destroyEffectPrefab;

    public void PlayEffect()
    {
        Instantiate(destroyEffectPrefab, transform.localPosition, Quaternion.identity);

    }

}
