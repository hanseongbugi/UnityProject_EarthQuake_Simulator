using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class cshPlayerController : MonoBehaviour
{
    public float m_moveSpeed = 2.0f;
    private Animator m_animator;
    private cshAttackArea m_attackArea = null;
    public float HP;
    private bool flag = true;
    public GameObject HpBarObject;
    public Slider HpBar;
    //public GameObject HpBar;
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_attackArea = GetComponentInChildren<cshAttackArea>();
        HP = 10;
        HpBarObject = GameObject.Find("Canvas/HP");
    }

    void Update()
    {
        PlayerMove();
        flag = true;
        //Debug.Log(HP);
        //if (HP == 0) SceneManager.LoadScene("EndScene");
        HpBarObject.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1.8f, 0));
        //HpBar.value = 0.3f;
        UpdateHpBar();
    }

    void UpdateHpBar() //초기 hp 10 -> VALUE =0~1
    {
        HpBar.value = (HP * 1/10);
    }

    private void OnTriggerEnter(Collider collision)
	{
		if (collision.CompareTag("Bullet"))
		{
			if (flag && HP>0)
			{
                HP--;
                Debug.Log("HIT");
                flag = false;
            }
            

        }
	}
	void PlayerMove()
    {
        
        CharacterController controller = GetComponent<CharacterController>();
        float gravity = 20.0f;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveHorizontal = Vector3.right * h;
        Vector3 moveVertical = Vector3.forward * v;
        Vector3 velocity = (moveHorizontal + moveVertical).normalized;
        
        m_animator.SetFloat("Move", velocity.magnitude);

        if (velocity.magnitude > 0.5)
        {
            transform.LookAt(transform.position + velocity);
        }
        velocity.y -= gravity * Time.deltaTime;

        controller.Move(velocity * m_moveSpeed * Time.deltaTime);

    }
    public bool CanAttack()
    {
        return 0 < m_attackArea.colliders.Count;
    }
    public bool CanHide()
    {
        return 0 < m_attackArea.hideColliders.Count;
    }
    public void OnVirtualPadHide()
    {

        if (this == null) { return; }
       // transform.rotation *= Quaternion.Euler(1f,180f,1f);
       // m_animator.SetBool("Down", true);

        //int cnt = m_attackArea.colliders.Count;

        for (int i = 0; i < m_attackArea.hideColliders.Count; ++i)
        {
            var collider = m_attackArea.hideColliders[i];
            //center += collider.transform.localPosition;
            
        }
        //StartCoroutine(HideCharacterForSeconds(3f));
        gameObject.SetActive(false);
        //m_animator.SetBool("Jump", false);
        Invoke("ShowCharacter", 3f);
    
     }
    private void ShowCharacter()
    {
        // 캐릭터를 다시 표시
        gameObject.SetActive(true);
        m_animator.SetBool("Down", false); // 숨기기 애니메이션 상태를 해제
    }
    public void OnVirtualPadAttack()
    {
        if (this == null) { return; }

        m_animator.SetTrigger("Attack");

       // int cnt = m_attackArea.colliders.Count;
        int cntBreak = 0;

        for (int i = 0; i < m_attackArea.colliders.Count; ++i)
        {
            var collider = m_attackArea.colliders[i];

            var obj = collider.GetComponent<cshBreakableObject>();
            if (obj != null)
            {
                obj.PlayEffect();
                cntBreak++;
            }
            
        }

        //if (cntBreak > 0) m_attackArea.colliders.Clear();
    }

}
