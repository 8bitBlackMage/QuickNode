using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    public float speed;
    Vector3 Change;
    private Rigidbody2D m_RidgidBody;
    private Animator m_Animator;
    public bool freeze = false;
    PlayerMover()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        m_RidgidBody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void FixedUpdate()
    {
        Change = Vector3.zero;
        Change.x = Input.GetAxisRaw("Horizontal");
        Change.y = Input.GetAxisRaw("Vertical");
        if (Change != Vector3.zero)
        {
            Move();
            m_Animator.SetFloat("MoveX", Change.x);
            m_Animator.SetFloat("MoveY", Change.y);
            m_Animator.SetBool("Moving", true);
        }
        else
        {
            m_Animator.SetBool("Moving", false);
        }

    }

    void Move()
    {
        if (freeze == false)
        {
            m_RidgidBody.MovePosition(
                transform.position + Change * speed * Time.deltaTime);
        }
        }

}
