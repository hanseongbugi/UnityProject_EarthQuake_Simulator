using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshAttackArea : MonoBehaviour
{
    public List<Collider> colliders
    {
        get
        {
            if (0 < colliderList.Count)
            {
                //  현재 colliders 리스트에 객체중 null인 것은 제거하여 colliderList에 저장 후 반환
                colliderList.RemoveAll(c => c == null);
            }
            return colliderList;
        }
    }
    private List<Collider> colliderList = new List<Collider>();
    public List<Collider> hideColliders
    {
        get
        {
            if (0 < hideColliderList.Count)
            {
                //  현재 colliders 리스트에 객체중 null인 것은 제거하여 colliderList에 저장 후 반환
                hideColliderList.RemoveAll(c => c == null);
            }
            return hideColliderList;
        }
    }
    private List<Collider> hideColliderList = new List<Collider>();

    public List<Collider> bulletColliders
    {
        get
        {
            if (0 < bulletColliderList.Count)
            {
                //  현재 colliders 리스트에 객체중 null인 것은 제거하여 colliderList에 저장 후 반환
                bulletColliderList.RemoveAll(c => c == null);
            }
            return bulletColliderList;
        }
    }
    private List<Collider> bulletColliderList = new List<Collider>();


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BreakableObject"))
        {
            colliders.Add(other);
        }
        if (other.CompareTag("HideObject"))
        {
            hideColliders.Add(other);
        }
        if (other.CompareTag("Bullet"))
        {
            bulletColliders.Add(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("exit");
        if (other.CompareTag("BreakableObject"))
        {
            Debug.Log("breakable");
            colliders.Remove(other);
        }
        if (other.CompareTag("HideObject"))
        {
            Debug.Log("HideObject");
            hideColliders.Remove(other);
        }
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Bullet");
            bulletColliders.Remove(other);
        }
    }

}
