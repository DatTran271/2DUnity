using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 6;
       
    public float dashDistance;
    public float dashCD;
    private bool isdashCD = false;
    
    private Rigidbody2D rb;
    private Vector2 movement;

    private Animator anim;
    private float horizontal = 0.0f;
    private float vertical = 0.0f;
    private bool isWalking;
    private bool isDash = false;

    public float attackCD;
    private bool isAttackCD = false;

    public GameObject arrowPrefab;
    public GameObject oldArrow;
    public GameObject newArrow;
    public float Arrowspeed;
    public int maxArrow;
    private int currentArrow;
    public float reloadTime;
    private bool isReloading = false;

    public GameObject arrowMusic;
    public GameObject swordMusic;
    public GameObject ReloadIcon;
    public GameObject slowIcon;
    public GameObject freezeIcon;
    public GameObject confusedIcon;
    public GameObject healText;

    public float getPosX, getPosY;
    private SaveManager save;

    public bool canMove;

    private void Awake()
    {
        save = FindObjectOfType<SaveManager>();
        save.LoadGame();
    }

    void Start()
    {
        speed = 6;
        canMove = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        arrowPrefab = oldArrow;
        currentArrow = maxArrow;
    }

    void Update()
    {
        //stop movement
        if (!canMove)
        {
            speed = 0; 
            anim.SetBool("isWalk", false);
            return;
        }
        else{
            
        }
        
     
        //movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x != 0 || movement.y != 0)
        {
            
            anim.SetFloat("X", movement.x);
            anim.SetFloat("Y", movement.y);
            if (!isWalking)
            {
                isWalking = true;
                anim.SetBool("isWalk", isWalking);
            }
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                anim.SetBool("isWalk", isWalking);
            }
        }
            
        //attack
        if (Input.GetButtonDown("Fire2"))
        {
            if (isAttackCD)
            {
                return;
            }
                
            anim.SetBool("isAttack", true);
            if (!isAttackCD)
            {
                Instantiate(swordMusic,transform.position,Quaternion.identity);
                StartCoroutine(WaitforAttackCD());
                return;
            }
        }
        anim.SetBool("isAttack", false);
             
        //dash
        if (Input.GetKeyDown(KeyCode.Space) && movement.x != 0)
        {
                
            if (isdashCD)
            {
                return;
            }
            anim.SetBool("isDash", true);
            rb.AddForce(movement.normalized * dashDistance);
                
            if (!isdashCD)
            {
                StartCoroutine(WaitforDashCD());
                return;
            }
          
        }
        anim.SetBool("isDash", false);
   
        //arrow
        if(isReloading){
            return;
        }
        Vector2 mouseCursorePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mouseCursorePos - rb.position;
        lookDir.Normalize();     
        if (Input.GetMouseButtonDown(0))
        {
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            arrow.GetComponent<Rigidbody2D>().velocity = lookDir * Arrowspeed;
            arrow.transform.Rotate(0.0f,0.0f,Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg);
            currentArrow--;
            Instantiate(arrowMusic,transform.position,Quaternion.identity);
               
        }
        if(currentArrow ==0 && !isReloading == true){
            StartCoroutine(Reload());
            return;
        }
             
    }
    // Effect slow
    public void SlowPlayer(int reduceSpeed)
    {
        StartCoroutine(WaitforSlow(reduceSpeed));
    }

    // Effect lose control
    public void LoseControlPlayer()
    {

        if (speed > 0)
        {
            speed = -6;
        }
        if (speed < 0)
        {
            StartCoroutine(WaitforControl());
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        ReloadIcon.SetActive(true);
        yield return new WaitForSeconds(reloadTime);
        currentArrow = maxArrow;
        isReloading = false;
        ReloadIcon.SetActive(false);
    }
        
    IEnumerator WaitforDashCD()
    {
        isdashCD = true;
        yield return new WaitForSeconds(dashCD);
        isdashCD = false;
    }

    IEnumerator WaitforAttackCD()
    {
        isAttackCD = true;
        yield return new WaitForSeconds(attackCD);
        isAttackCD = false;
    }

    // Wait for slow
    IEnumerator WaitforSlow(int reduceSpeed)
    {
        speed -= reduceSpeed;
        if (speed > 0)
        {
            slowIcon.SetActive(true);
            yield return new WaitForSeconds(4f);
            slowIcon.SetActive(false);
        }
        if (speed == 0)
        {
            freezeIcon.SetActive(true);
            slowIcon.SetActive(false);
            yield return new WaitForSeconds(2f);
            freezeIcon.SetActive(false);
        }
        speed = 6;

    }

    // Wait for control
    IEnumerator WaitforControl()
    {
        confusedIcon.SetActive(true);
        speed = -6;
        yield return new WaitForSeconds(4f);
        confusedIcon.SetActive(false);
        speed = 6;
    }

    public void BuffArrow()
    {
        StartCoroutine(TimeBuff());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Buff")
        {
            BuffArrow();
            HealthIndicator indicator = Instantiate(healText, transform.position, Quaternion.identity).GetComponent<HealthIndicator>();
            indicator.SetBuffText("Buff atk");
            other.gameObject.SetActive(false);
        }
    }

    IEnumerator TimeBuff()
    {
        //Debug.Log("buff time start");
        arrowPrefab = newArrow;
        yield return new WaitForSeconds(5f);
        arrowPrefab = oldArrow;
        //Debug.Log("buff time end");
    }

}

