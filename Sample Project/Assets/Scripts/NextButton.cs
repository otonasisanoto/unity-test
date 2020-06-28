using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class NextButton : MonoBehaviour
{
    public void OnClick()
    {
        PlayerController.currentStage += 1; // 次のシーンに変更
        SceneManager.LoadScene (PlayerController.currentStage); 
        Time.timeScale = 1;
    }
}
