using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public float LimitTime;
    public TextMeshProUGUI text_timer;

    void Update() // 제한시간
    {
        LimitTime -= Time.deltaTime;
        text_timer.text = "제한시간 : " + Mathf.Round(LimitTime);
        
        if (LimitTime <= 0f)
        {
            StopTimer();
        }
    }

    void StopTimer()
    {
        Time.timeScale = 0f;
        Debug.Log("제한시간이 종료되어서 게임이 종료되었습니다.");
    }
}
