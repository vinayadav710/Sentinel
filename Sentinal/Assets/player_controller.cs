using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_controller : MonoBehaviour
{
    PlayerControls controls;

    Vector3 m_Movement;
    Animator m_Animator;
    public float turnSpeed;
    Rigidbody m_Rigidbody;

    public float RunningSpeed = 0;

    Quaternion m_Rotation = Quaternion.identity;

    void Awake() {
        controls = new PlayerControls();
        
        controls.Player.jump.performed += ctx => Jump();
    }

    void OnEnable() {
        controls.Player.Enable();
    }

    void OnDisable() {
        controls.Player.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
         m_Animator = GetComponent<Animator> ();
         m_Rigidbody = GetComponent<Rigidbody> ();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        //Debug.Log(horizontal);

        // Moves the charecter
        m_Movement.Set(horizontal, 0f, 0f);
        
        m_Movement.Normalize ();

          bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
          bool isWalking = hasHorizontalInput;
          m_Animator.SetBool("IsWalking", isWalking);

          Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
          m_Rotation = Quaternion.LookRotation (desiredForward);

         if(hasHorizontalInput)
        {
            m_Rigidbody.transform.Translate(m_Movement *RunningSpeed * Time.deltaTime, Space.World);
        }
    }

    void OnAnimatorMove ()
    {
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation (m_Rotation);
       
        
    }

    void Jump()
    {
        Debug.Log("Jumping");
        controls.Player.jump.performed += ctx => m_Animator.SetBool("IsJumping", true);
        controls.Player.jump.canceled += ctx => m_Animator.SetBool("IsJumping",false);
    }
}
