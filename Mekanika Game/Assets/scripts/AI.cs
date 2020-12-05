using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AI : MonoBehaviour
{
    public GameObject WinLose;
    public TextMeshProUGUI LoseText;
    public static float speedAi;
    public static float level;
    public LayerMask groundLayer;
    private Rigidbody rb;
    public float jumpForce = 1;
    public CapsuleCollider col;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        speedAi = 0.2f;
        speedAi += level;
    }

    // Update is called once per frame
    void Update()
    {
    if (IsGrounded())
    {
        rb.AddForce(Vector3.up*jumpForce/5, ForceMode.Impulse);
            //   StartCoroutine(JumpAnim());
            anim.SetTrigger("Jump");
    }
        transform.Translate (Vector3.forward*Time.deltaTime*speedAi);//+(Vector3.up*Time.deltaTime*0.1f));
        
    //     if(Input.GetKeyDown(KeyCode.LeftArrow))
    //     {
    //         transform.position += Vector3.left*Time.deltaTime*1f;
    //     }
    //     if(Input.GetKeyDown(KeyCode.RightArrow))
    //     {
    //         transform.position += Vector3.right*Time.deltaTime*1f;
    //     }
    }
    private bool IsGrounded()
    {

        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .1f/2, groundLayer);
        // return false;
    }
    void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.tag == "Finish")
        {
            WinLose.gameObject.SetActive(true);
            LoseText.gameObject.SetActive(true);
        }
        if(col.gameObject.tag == "Energi")
        {
            Destroy(col.gameObject);
            speedAi += 0.1f;
        }
        
        else if(col.gameObject.tag == "Coin")
        {
            // WinLoseCondition.collision=1;
            Destroy(col.gameObject);
        }
    }
    public void RestartButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void MenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}