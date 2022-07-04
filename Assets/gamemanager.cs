using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public TalkManager talkmanager;
    public Image PortrayImg;
    public TypeEffect talkText;
    public Text quest_text;
    public GameObject obj;
    public GameObject menu;
    public GameObject player;
    public bool isAction;
    public int talkindex;
    public questmanager questmanager;
    Sprite prev_image;
    public Animator Portray_anim;
    public Animator talkPanel;

    void Start()
    {
        if (PlayerPrefs.GetInt("Scene_number")==2)
        {
            SceneManager.LoadScene("Second_Scene");
        }
        GameLoad();
        if (!questmanager.questlist.ContainsKey(questmanager.questid))
            quest_text.text = "해당 지역 퀘스트 완료";
        else
            quest_text.text = questmanager.questlist[questmanager.questid].questname;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!questmanager.questlist.ContainsKey(questmanager.questid))
                quest_text.text = "해당 지역 퀘스트 완료";
            else
                quest_text.text = questmanager.questlist[questmanager.questid].questname;
            if (menu.activeSelf)
                menu.SetActive(false);
            else
                menu.SetActive(true);
        }
    }

    public void Action(GameObject Object)
    {
        obj = Object;
        if(obj.transform.tag=="water")
        {
            Talk(0, false,false);
            talkPanel.SetBool("isTalking",isAction);
        }
        else
        {
            ObjData objdata = obj.GetComponent<ObjData>();
            Talk(objdata.id, objdata.isNPC,objdata.notNPC_has_quest);
            talkPanel.SetBool("isTalking", isAction);
        }
    }

    void Talk(int id,bool isNPC,bool notNPC_has_quest)
    {
        int questindex= questmanager.GetTalkIndex(id, isNPC, notNPC_has_quest);
        string talkdata= talkmanager.GetTalk(id+questindex, talkindex);

        if(talkText.isanim)
        {
            talkText.SetMsg("");
            return;
        }

        if(talkdata==null)  
        {
            questmanager.checkquest(id);
            talkindex = 0;
            isAction = false;
            return;
        }

        if(isNPC)
        {
            talkText.SetMsg(talkdata.Split(':')[0]);
            if (id == 1)
                PortrayImg.sprite = talkmanager.Scene_NPC_Portray();
            else
                PortrayImg.sprite = talkmanager.GetPortrait(id, int.Parse(talkdata.Split(':')[1]));

            if(prev_image!=PortrayImg.sprite)
            {
                Portray_anim.SetTrigger("Move");
                prev_image = PortrayImg.sprite;
            }
            PortrayImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            if(id==0)
            {
                talkText.SetMsg(talkdata.Split(':')[0]);
                PortrayImg.sprite = talkmanager.GetPortrait(id,int.Parse(talkdata.Split(':')[1]));
                PortrayImg.color = new Color(1, 1, 1, 1);
            }
            else
            {
                talkText.SetMsg(talkdata);
                PortrayImg.color = new Color(1, 1, 1, 0);
            }
        }
        isAction = true;
        talkindex++;
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        player.transform.position = new Vector3(x, y, 0);
        questmanager.questid = PlayerPrefs.GetInt("QuestId");
        questmanager.NPCindex = PlayerPrefs.GetInt("NPCindex");
    }

    public void Continue()
    {
        menu.SetActive(false);
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("PlayerX",player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetInt("QuestId",questmanager.questid);
        PlayerPrefs.SetInt("NPCindex",questmanager.NPCindex);
        PlayerPrefs.SetInt("Scene_number", 1);
        PlayerPrefs.Save();

        menu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Reset_Data()
    {
        PlayerPrefs.DeleteAll();
        questmanager.questid = 10;
        questmanager.NPCindex = 0;
        player.transform.position = new Vector3(-11.48f,-3.68f,0);
        menu.SetActive(false);
    }
}