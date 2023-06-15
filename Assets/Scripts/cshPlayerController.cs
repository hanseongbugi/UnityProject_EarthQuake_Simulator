using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshPlayerController : MonoBehaviour
{
    public float m_moveSpeed = 2.0f;
    private Animator m_animator;

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
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

}
