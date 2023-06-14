using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private int lastDir;
    public string[] staticDirection =
        { "Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE" };

    public string[] runDirection =
        { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void SetDirection(Vector2 dircetion)
    {
        if (dircetion.magnitude < 0.01)
        {
            anim.Play(staticDirection[lastDir]);
        }
        else
        {
            lastDir = DirectionToIndex(dircetion);
            anim.Play(runDirection[lastDir]);
        }
    }

    private int DirectionToIndex(Vector2 _dircetion)
    {
        Vector2 norDir = _dircetion.normalized;
        float step = 360 / 8;
        float offset = step / 2;

        float angle = Vector2.SignedAngle(Vector2.up, norDir);
        angle += offset;

        if (angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
}
