using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [Header("Player參數")]
    private     Rigidbody2D     Rb;
    private     Animator        Anim;
    public      Collider2D      GroundSensor;
    public Collider2D RightSlopeSensor;
    public      LayerMask       Ground;
    private     float           Speed=250,JumpForce=750;
    private     float           m_timeSinceAttack = 0,m_timeCollect=0;
    public float JumpCount;
    private     int             num_Attack=0;
    private     bool            HasMouseBeenPressed = false,NoGetDamage,jumpPressed;
    public      float           PlayerDamage=3, PlayerHealth=10,MoreDamage=6;
    static      public          bool isColliding;
    public int Blinks;
    public float times,deadzonecount;
    private Renderer myRender;
    public static float facedirection, horizontalmove, JumpButton;
    public Button A_Button, B_Button, X_Button, Y_Button;
    public GameObject EnterEndZone;
    [Header("Material")]
    public PhysicsMaterial2D hard;
    public PhysicsMaterial2D soft;
    [Header("Dash")]
    public float dashTime;
    static public float dashTimeLeft;
    private float lastDash;
    public float dashCoolDown;
    public float dashSpeed;
    private bool isDashing;
    public Image DashBar;
    [Header("Timeskill")]
    private float fixedDeltaTime;
    private bool SlowMoveBuffer;
    public float SlowMoveTimeMax;
    private bool SlowMoveStartCount;
    private float SlowMoveTime;
    public GameObject SlowMoveMask;
    private float lastTimeSkill;
    public float TimeCoolDown;
    public Image TimeBar;

    public AudioSource atk1, atk2;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        myRender = GetComponent<Renderer>();
        A_Button.onClick.AddListener(() => {
            HasMouseBeenPressed = true;
        });

        B_Button.onClick.AddListener(() => {
            if (JumpCount > 0)
            {
                jumpPressed = true;
            }
        });

        X_Button.onClick.AddListener(() => {
            if (Time.time >= (lastDash + dashCoolDown))
            {
                ReadytoDash();
            }
        });

        Y_Button.onClick.AddListener(() => {
            if (TimeBar.fillAmount == 1)
            {
                SlowMoveBuffer = true;
            }
        });
    }
    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }
    void Update()//檢查是否輸入
    {
        if (GroundSensor.IsTouchingLayers(Ground))
        {
            JumpCount = 2;
            Anim.SetBool("jumping", false);
        }
        if (Input.GetButton("Fire1"))
            HasMouseBeenPressed = true;
        if (Input.GetButton("Fire2"))
        {
            if(Time.time>=(lastDash + dashCoolDown)&& facedirection != 0)
            {
                ReadytoDash();
            }
        }
        if (Input.GetMouseButton(2)  && TimeBar.fillAmount ==1)
        {
            SlowMoveBuffer = true;
        }
        //horizontalmove = Input.GetAxis("Horizontal");
        //facedirection = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && JumpCount >0)
        {
            jumpPressed = true;
        }
    }
    void FixedUpdate()
    {
        DashBar.fillAmount += 1.0f / dashCoolDown * Time.deltaTime;
        TimeBar.fillAmount += 1.0f / TimeCoolDown * Time.deltaTime;
        deadzonecount += Time.deltaTime;
        m_timeSinceAttack += Time.deltaTime;
        m_timeCollect += Time.deltaTime;
        ClearAtk();
        SwitchAnim();
        Movement();
        healthCheck();
        SlowMoveCount();
        Dash();
        StaticCharactor.playerdamage = PlayerDamage;
    }
    void ClearAtk()
    {
        if (!Anim.GetNextAnimatorStateInfo(0).IsName("Attack1") || !Anim.GetNextAnimatorStateInfo(0).IsName("Attack2")
         || !Anim.GetNextAnimatorStateInfo(0).IsName("Attack3"))
        {
            isColliding = false;
        }
    }
    void Movement()
    {
        //腳色移動
        if (horizontalmove != 0f)
        {
            Rb.velocity = new Vector2(horizontalmove * Speed * Time.deltaTime, Rb.velocity.y);//* Time.deltaTime
            //Anim.SetFloat("running", Mathf.Abs(facedirection));
        }

        //面相方向
        if (facedirection > 0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (facedirection < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //設置攻擊時減慢速度
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") ||
        Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2") || Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
        {
            if (GroundSensor.IsTouchingLayers(Ground))
            {
                Speed = 100;
            }
        }
        else
            Speed = 250;
        
        //設定Material 在空中時不卡牆壁
        if (GroundSensor.IsTouchingLayers(Ground) && horizontalmove==0)
        {
            Rb.sharedMaterial = hard;
        }
        else
        {
            Rb.sharedMaterial = soft;
        }

        //設定上斜坡
        if (RightSlopeSensor.IsTouchingLayers(Ground) && horizontalmove != 0f && dashTimeLeft ==0)
        {
            Rb.sharedMaterial = soft;
            //Rb.velocity = new Vector2(Rb.velocity.x, 4);
        }

        //腳色跳躍 多段跳躍 if(Input.GetButtonDown("Jump"))
        if (jumpPressed && GroundSensor.IsTouchingLayers(Ground))
        {
            Rb.velocity = new Vector2(Rb.velocity.x, JumpForce * Time.deltaTime); //*Time.deltaTime
            Anim.SetBool("jumping", true);
            Anim.SetBool("falling", false);
            JumpCount--;
            jumpPressed = false;
        }
        else if(jumpPressed && JumpCount>0 && !GroundSensor.IsTouchingLayers(Ground))
        {
            Rb.velocity = new Vector2(Rb.velocity.x, JumpForce * Time.deltaTime); //*Time.deltaTime
            Anim.SetBool("jumping", true);
            Anim.SetBool("falling", false);
            JumpCount--;
            jumpPressed = false;
        }
    }
    void SwitchAnim()
    {
        Anim.SetFloat("running", Mathf.Abs(facedirection));
        if (HasMouseBeenPressed)
        {
            if (HasMouseBeenPressed && m_timeSinceAttack > 0.4f)
            {
                num_Attack++;

                if (num_Attack > 3)
                    num_Attack = 1;
                if (m_timeSinceAttack > 1.2f)
                    num_Attack = 1;
                Anim.SetTrigger("attack" + num_Attack);

                m_timeSinceAttack = 0;
            }
            HasMouseBeenPressed = false;
        }
        Anim.SetBool("idle", false);
        if (Rb.velocity.y < -0.5f && !GroundSensor.IsTouchingLayers(Ground))
        {
            Anim.SetBool("falling", true);
        }
        if (Anim.GetBool("jumping"))
        {

            if (Rb.velocity.y < 0)
            {
                Anim.SetBool("jumping", false);
                Anim.SetBool("falling", true);
            }
        }
        else if (GroundSensor.IsTouchingLayers(Ground))
        {
            Anim.SetBool("falling", false);
            Anim.SetBool("idle", true);
        }
        if (SlowMoveBuffer)
        {
            Anim.SetTrigger("skill");
            SlowMoveBuffer = !SlowMoveBuffer;
        }
    }
    public void PlayerGetDamage(float damage)
    {
        if (!NoGetDamage)
        {
            StaticCharactor.health -= damage;
            Setting.Instance.shakecamera(3f,.2f);
            BlinkPlayer(Blinks,times);
        }
    }
    void BlinkPlayer(int numblinks,float seconds)
    {
        StartCoroutine(DoBlinks(numblinks, seconds));
    }
    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        NoGetDamage = true;
        for (int i = 0; i < numBlinks * 2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
        NoGetDamage = false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //撿取藥水
        if (collision.gameObject.tag == "Posion")
        {
            if (m_timeCollect >= 0.05)
            {
                if (StaticCharactor.health <= 8)
                {
                    Destroy(collision.gameObject);
                    StaticCharactor.health += 2;
                }
                else if (StaticCharactor.health == 9)
                {
                    Destroy(collision.gameObject);
                    StaticCharactor.health += 2;
                }
            }
            m_timeCollect = 0;
        }
        //撿到金幣
        if (collision.gameObject.tag == "Coin")
        {
            if (m_timeCollect >= 0.02)
            {
                Destroy(collision.gameObject);
                CoinCount.Coin += 1;
                CoinCount.coinsoundplay();
            }
            m_timeCollect = 0;
        }
        //結束區域
        if (collision.gameObject.tag == "EndZone")
        {
            EnterEndZone.SetActive(true);
        }
        //死亡區域
        if (collision.gameObject.tag == "DeadZone")
        {
            if (deadzonecount > 0.3f)
            {
                StaticCharactor.lastheart -= 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                deadzonecount = 0;
            }
        }
    }
    void ReadytoDash()
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;
        DashBar.fillAmount = 0;
    }
    void Dash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                Rb.velocity = new Vector2(dashSpeed * transform.localScale.x * Time.deltaTime, Rb.velocity.y);

                dashTimeLeft -= Time.deltaTime;

                ShadowPoll.instance.GetFromPool();
                NoGetDamage = true;
            }
            if (dashTimeLeft <= 0)
            {
                Rb.velocity = new Vector2(0, Rb.velocity.y);
                isDashing = false;
                NoGetDamage = false;
            }
        }
    }
    public void SlowMoveEnable()
    {
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        SlowMoveStartCount = true;
        SlowMoveTime = SlowMoveTimeMax;
        SlowMoveMask.SetActive(true);
        StaticCharactor.playerdamage = MoreDamage;
        JumpForce = JumpForce * 2f;
    }
    void SlowMoveCount()
    {
        if (SlowMoveStartCount)
        {
            lastTimeSkill = Time.time;
            SlowMoveTime -= Time.deltaTime;
            TimeBar.fillAmount = 0;
            if (SlowMoveTime <= 0)
            {
                SlowMoveMask.SetActive(false);
                StaticCharactor.playerdamage = 3;
                Time.timeScale = 1f;
                JumpForce = JumpForce / 2f;
                Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
                SlowMoveStartCount = !SlowMoveStartCount;
            }
        }
    }
    private void healthCheck()
    {
        if (StaticCharactor.health <= 0)
        {
            StaticCharactor.lastheart -= 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void atk1sound()
    {
        atk1.Play();
    }
    public void atk2sound()
    {
        atk2.Play();
    }
}
