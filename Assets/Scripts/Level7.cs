using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level7 : MonoBehaviour
{
    void Start()
    {
        Invoke("Win", 5f);
    }

    void Win()
    {
        SceneManager.LoadScene("Level 8", LoadSceneMode.Single);
    }
}
