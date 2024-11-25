using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassScorePoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        GameManager.singleton.AddScore(1);
        FindObjectOfType<Control>().perfectPass++;;
    }
}
