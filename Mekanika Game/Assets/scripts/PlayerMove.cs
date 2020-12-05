using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    
    // Start is called before the first frame update
    public static float speed;
    // private Rigidbody rb;
    // public float jumpForce = 5;
    // public CapsuleCollider col;
    // public LayerMask groundLayer;
    public static float upgrade;
    public static int saveCoin;
    public GameObject WinLose;
    public TextMeshProUGUI WinText;
    // Animator anim;

    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        // anim = GetComponent<Animator>();
        // col = GetComponent<CapsuleCollider>();
        
        
        speed = 10f;
        speed += upgrade;
        // Time.timeScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate((Vector3.forward*Time.deltaTime*speed) + (Vector3.up*Time.deltaTime*1.5f));
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate (Vector3.left*Time.deltaTime*5f);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate (Vector3.right*Time.deltaTime*5f);
        }
        // Bergerak();
    }
    // void Bergerak()
    // {
        // float x = Input.GetAxisRaw("Horizontal") * speed;
        // float y = Input.GetAxisRaw("Vertical") * speed;
        // Vector3 movePos= transform.right * x + transform.forward * y;
        // Vector3 newMovePos= new Vector3(movePos.x, rb.velocity.y, movePos.z);

        // rb.velocity = newMovePos;
        // rb.velocity = Vector3.right * gerak * speed;
        // rb.velocity = Vector3.forward * gerak * speed;
        // anim.SetFloat("Kecepatan", Mathf.Abs(gerak), 0.1f, Time.deltaTime); 
        // Debug.Log(Mathf.Abs(gerak));
        // if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        // {
        //     rb.AddForce(Vector3.up*jumpForce/2, ForceMode.Impulse);
        // }
    // }
    // private bool IsGrounded()
    // {
    //     return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .2f, groundLayer);
    //     // return false;
    // }
    void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.tag == "Energi")
        {
            Destroy(col.gameObject);
            speed += 2f;
        }
        
        else if(col.gameObject.tag == "Coin")
        {
            PlayerManager.coin += 1;
            // WinLoseCondition.collision=1;
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "Finish")
        {
            AI.level += 0.2f;
            PlayerPrefs.SetInt("coin", PlayerManager.coin);
            saveCoin += PlayerPrefs.GetInt("coin");
            
            WinLose.gameObject.SetActive(true);
            WinText.gameObject.SetActive(true);
            // Time.timeScale = 0;
        }
        else if(col.gameObject.tag == "Batu")
        {
            Destroy(col.gameObject);
        }     
    }
    //Win Lose Condition 
    public void RestartButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void MenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}