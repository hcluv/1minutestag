using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{

       // GameObject TimerTex;
        public Text timerText;

        public float totalTime;
        float seconds;

        // Use this for initialization
        IEnumerator Start()
        {
             enabled = false;
             yield return new WaitForSeconds(3); //三秒待ってUpdate()を有効化してキーそのものを受け付けない
             enabled = true;
        }

        // Update is called once per frame
        void Update()
        {
            totalTime -= Time.deltaTime;
            seconds = totalTime;
            timerText.text = "残り時間:" + seconds.ToString();

            if(totalTime <= 0)
            {
            SceneManager.LoadScene("GameClear");
            }
        }
 }
