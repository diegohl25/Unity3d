using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 5f;
    private bool ignoreNextCollision;

    private Vector3 startPosition;

    public int perfectPass;
    public float superSpeed = 8;
    private bool isSuperSpeedActive;
    private int perfectPassCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

  
    private void OnCollisionEnter(Collision collision){


        if(ignoreNextCollision){
            return;
        }

        if(isSuperSpeedActive && !collision.transform.GetComponent<GoalControl>()){
            Destroy(collision.transform.parent.gameObject, 0.2f);
        }

        if(collision.gameObject.GetComponent<DeathPart>() != null){
            GameManager.singleton.RestartLevel();
        }

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        ignoreNextCollision = true;
        Invoke("AllowNextCollision", 0.2f);

        perfectPass = 0;
        isSuperSpeedActive = false;
    }

    private void Update(){
        if(perfectPass >= perfectPassCount && !isSuperSpeedActive){
            isSuperSpeedActive = true;
            rb.AddForce(Vector3.down* superSpeed, ForceMode.Impulse);
        }
    }

    private void AllowNextCollision(){
        ignoreNextCollision = false;    
    }

    public void ResetBall(){
        transform.position = startPosition;
        rb.velocity = Vector3.zero;
    }

}

