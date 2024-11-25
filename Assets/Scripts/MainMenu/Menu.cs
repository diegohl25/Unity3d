using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void EmpezarJuego(){
        SceneManager.LoadScene("GameScene");
    }

    public void SalirDelJuego(){
        Application.Quit();
    }
}
