using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BUTTON : MonoBehaviour
{
   public void ButtonReload()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
