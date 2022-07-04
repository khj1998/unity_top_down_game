using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questmanager2 : MonoBehaviour
{
    public int questid;
    public int NPCindex;
    public Dictionary<int, QuestData> questlist;
    public GameObject[] wallobject;
    public GameObject coin;

    private void Awake()
    {
        questlist = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questlist.Add(10, new QuestData("펫에게 줄 물 구하기", new int[3] { 1000, 2000,3000}));
        questlist.Add(20, new QuestData("펫에게 물 전달해주기", new int[1] {1000}));
        questlist.Add(30, new QuestData("벽 부수고 들어가기", new int[4] { 4000, 2000,4000,5000}));
    }

    public int GetTalkIndex(int id, bool isNPC)
    {
        if (isNPC)
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

        check_object();

        if (questlist[questid].NPCid.Length == NPCindex)
        {
            questid += 10;
            NPCindex = 0;
            return;
        }
    }

    void check_object()
    {
        if(NPCindex+questid==33)
        {
            wallobject[0].SetActive(false);
            wallobject[1].SetActive(false);
        }
        else if(NPCindex + questid == 34)
        {
            coin.SetActive(false);
        }
    }
}
