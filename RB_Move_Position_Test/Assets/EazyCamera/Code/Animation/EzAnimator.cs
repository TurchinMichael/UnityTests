using UnityEngine;
using System.Collections;

public class EzAnimator : MonoBehaviour
{
	[SerializeField] private EzMotor m_controlledCharacter = null;
    private Animator m_animator = null;
    CharacterController m_characterController;

    // Anim hashes
    private int m_speedHash = -1;
    //private int m_directionHash = -1;

    private void Awake()
    {
        m_animator = this.GetComponent<Animator>();
        m_speedHash = Animator.StringToHash("Speed");
        m_characterController = GetComponent<CharacterController>();
        //m_directionHash = Animator.StringToHash("Direction");
    }

    private void Start()
    {
        if (m_controlledCharacter == null)
        {
            m_controlledCharacter = this.transform.root.GetComponentInChildren<EzMotor>();
        }
    }

    private void Update()
    {
        m_animator.SetFloat(m_speedHash, m_controlledCharacter.GetNormalizedSpeed());

        //UnderWater = false;
        

        if (Input.GetButtonDown("Jump") && !UnderWater && m_characterController.isGrounded)
        {
            m_animator.SetTrigger("jump");
        }

        //if (Input.GetKeyDown(KeyCode.E) && !UnderWater && m_characterController.isGrounded)
        //{
        //    m_animator.SetBool("shift_jump", !m_animator.GetBool("shift_jump"));
        //}

        //m_animator.gravityWeight

        if (Input.GetButtonDown/*GetKeyDown*/("Fire1"/*KeyCode.F*/))
        {
            m_animator.SetTrigger("attack");
        }
    }

    public bool UnderWater
    {get;set;}
}
