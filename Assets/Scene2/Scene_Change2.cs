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
        //����Ʈ��ȣ�� ����Ʈ����Ʈ ��ųʸ��� ���ٸ� �� ���� ����Ʈ�� ��� ���� ���̴�.
        bool not_finish = quest_info.questlist.ContainsKey(quest_info.questid);
        // ������ �ʾҴٸ� NPC�� �̵����Ѵ� ���. �����ٸ� �̵��Ұųİ� ���� ��� key��.
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

        // Talking�� ""�� �޾ƿ´ٸ� ���� �������� �̵� ���θ� ���´�.
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

    // ���� �������� �̵�
    public void next_stage()
    {
        //����°���� ���� ������Ʈ �Ѵ�.
        action = false;
        TalkPanel.SetBool("isTalking", action);
        yes.SetActive(false);
        no.SetActive(false);
        return;
    }

    // ���� ���������� �ӹ���.
    public void now_stage()
    {
        action = false;
        TalkPanel.SetBool("isTalking", action);
        yes.SetActive(false);
        no.SetActive(false);
        return;
    }
}
