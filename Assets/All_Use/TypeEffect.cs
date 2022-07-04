using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public Text gametext;
    string Target_Msg;
    public float type_speed;
    public GameObject End_Cursor;
    int index;
    public bool isanim;

    public void SetMsg(string msg)
    {
        if(isanim)
        {
            CancelInvoke();
            gametext.text = Target_Msg;
            EndMsg();
        }
        else
        {
            Target_Msg = msg;
            StartMsg();
        }
    }

    public void StartMsg()
    {
        End_Cursor.SetActive(false);
        gametext.text = "";
        index =0;
        Typing();
    }

    public void Typing()
    {
        if (gametext.text == Target_Msg)
        {
            EndMsg();
            return;
        }
        isanim = true;
        gametext.text += Target_Msg[index];
        index += 1;
        Invoke("Typing",1.0f/type_speed);
    }

    public void EndMsg()
    {
        End_Cursor.SetActive(true);
        isanim = false;
        Target_Msg = "";
    }

}
