using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cshPhtonBreakableObject : MonoBehaviourPun
{
    public GameObject destroyEffectPrefab;

    public void PlayEffect()
    {
        PhotonNetwork.Instantiate(destroyEffectPrefab.name, transform.localPosition, Quaternion.identity);
    }
}
