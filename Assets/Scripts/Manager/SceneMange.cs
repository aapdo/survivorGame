using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMange : MonoBehaviour
{
    public void onStartBtn() {
        SceneManager.LoadScene(1);
        Debug.Log(1);
    }
    public void onResetGame() { 
        SceneManager.LoadScene(0);
        Debug.Log(0);
    }
        
    

}
