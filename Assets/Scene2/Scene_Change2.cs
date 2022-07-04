using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene_Change2 : MonoBehaviour
{
    public GameObject yes;
    public GameObject no;
    public TalkManager2 talk;
    public questmanager2 quest_info;
    public Animator TalkPanel;
    public TypeEffect typing;
    public Image portray;
    public bool action;
    int talkindex;

    // Start is called before the first frame update

    public void Scene_manage(int id)
    {
        yes.SetActive(false);
        no.SetActive(false);
        //퀘스트번호가 퀘스트리스트 딕셔너리에 없다면 그 지역 퀘스트는 모두 끝난 것이다.
        bool not_finish = quest_info.questlist.ContainsKey(quest_info.questid);
        // 끝나지 않았다면 NPC의 이동못한다 대사. 끝났다면 이동할거냐고 묻는 대사 key값.
        id = not_finish ? id : (quest_info.questid) + id;
        string Talking = talk.GetTalk(id, talkindex);

        if (typing.isanim)
        {
            typing.SetMsg("");
            return;
        }

        if (Talking == null)
        {
            talkindex = 0;
            action = false;
            TalkPanel.SetBool("isTalking", action);
            return;
        }

        // Talking이 ""을 받아온다면 다음 스테이지 이동 여부를 묻는다.
        typing.SetMsg(Talking);
        action = true;
        talkindex++;
        portray.sprite = talk.Scene_NPC_Portray();
        TalkPanel.SetBool("isTalking", action);

        if (!not_finish)
        {
            yes.SetActive(true);
            no.SetActive(true);
        }
    }

    // 다음 스테이지 이동
    public void next_stage()
    {
        //세번째맵은 추후 업데이트 한다.
        action = false;
        TalkPanel.SetBool("isTalking", action);
        yes.SetActive(false);
        no.SetActive(false);
        return;
    }

    // 현재 스테이지에 머문다.
    public void now_stage()
    {
        action = false;
        TalkPanel.SetBool("isTalking", action);
        yes.SetActive(false);
        no.SetActive(false);
        return;
    }
}
