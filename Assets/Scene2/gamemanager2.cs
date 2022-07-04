using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager2 : MonoBehaviour
{
    public TalkManager2 talkmanager;
    public Image PortrayImg;
    public TypeEffect talkText;
    public Text quest_text;
    public GameObject obj;
    public GameObject menu;
    public GameObject player;
    public bool isAction;
    public int talkindex;
    public questmanager2 questmanager;
    public Animator talkPanel;

    void Start()
    {
        GameLoad();
        if (!questmanager.questlist.ContainsKey(questmanager.questid))
            quest_text.text = "축하합니다! 황금코인을 찾았습니다!";
        else
            quest_text.text = questmanager.questlist[questmanager.questid].questname;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!questmanager.questlist.ContainsKey(questmanager.questid))
                quest_text.text = "축하합니다! 황금코인을 찾았습니다!";
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
        Object2 objdata = obj.GetComponent<Object2>();
        Talk(objdata.id, objdata.isNPC);
        talkPanel.SetBool("isTalking", isAction);
    }

    void Talk(int id, bool isNPC)
    {
        int questindex = questmanager.GetTalkIndex(id, isNPC);
        string talkdata = talkmanager.GetTalk(id + questindex, talkindex);

        if (talkText.isanim)
        {
            talkText.SetMsg("");
            return;
        }

        if (talkdata == null)
        {
            questmanager.checkquest(id);
            talkindex = 0;
            isAction = false;
            return;
        }

        if (isNPC)
        {
            talkText.SetMsg(talkdata.Split(':')[0]);
            PortrayImg.sprite = talkmanager.GetPortrait(id, int.Parse(talkdata.Split(':')[1]));
            PortrayImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.SetMsg(talkdata);
            PortrayImg.color = new Color(1, 1, 1, 0);
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
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetInt("QuestId", questmanager.questid);
        PlayerPrefs.SetInt("NPCindex", questmanager.NPCindex);
        // 몇번째 씬에 있는지도 저장해야한다.
        PlayerPrefs.SetInt("Scene_number", 2);
        PlayerPrefs.Save();

        menu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Reset_Data()
    {
        // 1번씬으로 모두 초기화 하는 것이다.
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Scene_number", 1);
        questmanager.questid = 10;
        questmanager.NPCindex = 0;
        player.transform.position = new Vector3(-11.48f, -3.68f, 0);
        SceneManager.LoadScene("start_scene");
        PlayerPrefs.Save();

        menu.SetActive(false);
    }
}
