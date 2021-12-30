using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerWizard : MonoBehaviour
{
    [Header("Player�Ѽ�")]
    private Rigidbody2D Rb;
    private Animator Anim;
    public Collider2D GroundSensor;
    public Collider2D RightSlopeSensor;
    public LayerMask Ground;
    private float Speed = 250, JumpForce = 750;
    private float m_timeSinceAttack = 0, m_timeCollect = 0;
    public float JumpCount;
    private bool jumpPressed;
    static public float PlayerDamage = 1, PlayerHealth = 10;
    static public bool isColliding;
    private Renderer myRender;
    private float facedirection, horizontalmove, JumpButton;
    [Header("Material")]
    public PhysicsMaterial2D hard;
    public PhysicsMaterial2D soft;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        myRender = GetComponent<Renderer>();
    }
    void Update()//�ˬd�O�_��J
    {
        Anim.SetFloat("running", Mathf.Abs(facedirection));
        if (GroundSensor.IsTouchingLayers(Ground))
        {
            JumpCount = 2;
        }
        horizontalmove = Input.GetAxis("Horizontal");
        facedirection = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && JumpCount > 0)
        {
            jumpPressed = true;
        }
        if (gameObject.transform.position.y <= -50)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetMouseButton(0))
        {
            Anim.SetBool("Attack", true);
            Anim.SetBool("NAttack", false);
        }
        else
        {
            Anim.SetBool("NAttack", true);
            Anim.SetBool("Attack", false);
        }
    }
    void FixedUpdate()
    {
        m_timeSinceAttack += Time.deltaTime;
        m_timeCollect += Time.deltaTime;
        Movement();
        if (PlayerHealth <= 0)
            Destroy(gameObject);
    }
    void Movement()
    {
        //�}�Ⲿ��
        if (horizontalmove != 0f)
        {
            Rb.velocity = new Vector2(horizontalmove * Speed * Time.deltaTime, Rb.velocity.y);//* Time.deltaTime
            //Anim.SetFloat("running", Mathf.Abs(facedirection));
        }

        //���ۤ�V
        if (facedirection > 0f)
        {
            transform.localScale = new Vector3(0.7f, 0.7f, 1);
        }
        if (facedirection < 0f)
        {
            transform.localScale = new Vector3(-0.7f, 0.7f, 1);
        }

        //�]�wMaterial �b�Ť��ɤ��d���
        if (GroundSensor.IsTouchingLayers(Ground))
            Rb.sharedMaterial = hard;
        else
            Rb.sharedMaterial = soft;

        //�]�w�W�שY
        if (RightSlopeSensor.IsTouchingLayers(Ground) && horizontalmove != 0f)
        {
            Rb.sharedMaterial = soft;
            //Rb.velocity = new Vector2(Rb.velocity.x, 4);
        }

        //�}����D �h�q���D if(Input.GetButtonDown("Jump"))
        if (jumpPressed && GroundSensor.IsTouchingLayers(Ground))
        {
            Rb.velocity = new Vector2(Rb.velocity.x, JumpForce * Time.deltaTime); //*Time.deltaTime
            JumpCount--;
            jumpPressed = false;
        }
        else if (jumpPressed && JumpCount > 0 && !GroundSensor.IsTouchingLayers(Ground))
        {
            Rb.velocity = new Vector2(Rb.velocity.x, JumpForce * Time.deltaTime); //*Time.deltaTime
            JumpCount--;
            jumpPressed = false;
        }
    }
    public void PlayerGetDamage(float damage)
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //�ߨ��Ĥ�
        if (collision.gameObject.tag == "Posion")
        {
            if (m_timeCollect >= 0.05)
            {
                if (PlayerHealth <= 8)
                {
                    Destroy(collision.gameObject);
                    PlayerHealth += 2;
                }
                else if (PlayerHealth == 9)
                {
                    Destroy(collision.gameObject);
                    PlayerHealth += 2;
                }
            }
            m_timeCollect = 0;
        }
        //�ߨ����
        if (collision.gameObject.tag == "Coin")
        {
            if (m_timeCollect >= 0.02)
            {
                Destroy(collision.gameObject);
                CoinCount.Coin += 1;
            }
            m_timeCollect = 0;
        }
    }
}