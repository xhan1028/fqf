using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public float LimitTime;
    public TextMeshProUGUI text_timer;

    void Update() // ���ѽð�
    {
        LimitTime -= Time.deltaTime;
        text_timer.text = "���ѽð� : " + Mathf.Round(LimitTime);
        
        if (LimitTime <= 0f)
        {
            StopTimer();
        }
    }

    void StopTimer()
    {
        Time.timeScale = 0f;
        Debug.Log("���ѽð��� ����Ǿ ������ ����Ǿ����ϴ�.");
    }
}
