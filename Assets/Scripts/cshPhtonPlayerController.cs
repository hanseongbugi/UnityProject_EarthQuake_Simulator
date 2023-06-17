using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cshPhtonPlayerController : MonoBehaviourPun
{
    public float m_moveSpeed = 2.0f;
    private Animator m_animator;
    private cshAttackArea m_attackArea = null;
    public GameObject m_UI;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_attackArea = GetComponentInChildren<cshAttackArea>();
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            m_UI.SetActive(false);
            return;
        }

        PlayerMove();
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

        m_animator.SetTrigger("Down");

        //int cnt = m_attackArea.colliders.Count;

        for (int i = 0; i < m_attackArea.hideColliders.Count; ++i)
        {
            var collider = m_attackArea.hideColliders[i];
            //center += collider.transform.localPosition;

        }
        transform.rotation *= Quaternion.Euler(0f, 180f, 0f);

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
                obj.flag=1;
                cntBreak++;
            }

        }
        //if (cntBreak > 0) m_attackArea.colliders.Clear();
    }
}
