using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartSceneChanger : MonoBehaviour {

    float TimeCount = 2;
    private void Update()
    {
        TimeCount -= Time.deltaTime;
        if (TimeCount <= 0)
        {
            SceneManager.LoadScene("Title");
        }
    }
}
