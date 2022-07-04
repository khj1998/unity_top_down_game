using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questmanager : MonoBehaviour
{
    public int questid;
    public int NPCindex;
    public Dictionary<int,QuestData> questlist;
    public GameObject[] Object;

    private void Awake()
    {
        questlist = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questlist.Add(10,new QuestData("마을 사람들과 대화하기",new int[2] { 1000, 2000 }));
        questlist.Add(20, new QuestData("루도의 깃발 찾아주기", new int[2] { 5000, 2000 }));
    }

    public int GetTalkIndex(int id,bool isNPC,bool notNPC_has_quest)
    {
        if (isNPC || notNPC_has_quest)
            return questid + NPCindex;
        else
            return 0;
    }

    public void checkquest(int id)
    {
        if (!questlist.ContainsKey(questid))
            return;
        if (questlist[questid].NPCid[NPCindex] == id)
            NPCindex++;

        Check_Coin_Valid();

        if (questlist[questid].NPCid.Length == NPCindex)
        {
            questid += 10;
            NPCindex = 0;
            return;
        }
    }

    void Check_Coin_Valid()
    {
        switch(questid)
        {
            case 10:
                if (NPCindex == questlist[10].NPCid.Length)
                {
                    Object[0].SetActive(true);
                }
                break;
            case 20:
                if (NPCindex == 1)
                    Object[0].SetActive(false);
                break;
        }
    }
}
