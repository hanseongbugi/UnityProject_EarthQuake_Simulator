using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBreakableObject : MonoBehaviour
{
    //public GameObject destroyEffectPrefab;
    public int flag = 0;
    public float distanceFromHead = 2.0f; // �÷��̾� �Ӹ��κ����� �Ÿ�
    public void PlayEffect()
    {
        flag = 1;
        //Instantiate(destroyEffectPrefab, transform.localPosition, Quaternion.identity);
    }
  
    public GameObject player; // �÷��̾� ���� ������Ʈ�� Inspector���� �Ҵ��ؾ� �մϴ�.
 
    
    public void PlayShield()
	{
        flag = 1;
	}
    void Update()
    {
        if (flag == 1)
        {
            Vector3 headPosition = new Vector3(player.transform.position.x , 2.0f, player.transform.position.z);
            this.gameObject.transform.position = headPosition;
            this.gameObject.transform.rotation = player.transform.rotation * Quaternion.Euler(0f, 0f, 90f);



        }

    }
	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Bullet"))
        {
            //Instantiate()
            //Instantiate(destroyEffectPrefab, collision.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

}
