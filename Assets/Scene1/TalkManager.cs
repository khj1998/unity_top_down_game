using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talk;
    Dictionary<int, Sprite> portray;
    public Sprite[] portrayArr;
    public Sprite[] PlayerPortray;
    public Sprite[] scene_npc_portray;
    public gamemanager manager;
    public questmanager questmanager;

    void Awake()
    {
        // �迭������ new�� �Ѵ�..
        talk = new Dictionary<int, string[]>();
        portray = new Dictionary<int, Sprite>();
        GenerateData();
        Generate_Object_Talking();
    }

    void GenerateData()
    {
        talk.Add(1000, new string[] { "�ȳ�?:0", "ó������ ���ε� �̰��� ó�� �Ա���?:1" });
        talk.Add(2000, new string[] { "�ȳ�? �� �̸��� LUDO��:0", "�� �������� ��¾ ���̴�?:1", "ȣ���� ������ �˰��ִ�?:1" });
        talk.Add(100, new string[] { "����� �ڽ��̴�." });
        talk.Add(200, new string[] { "������ ������ ������ �ִ� å���̴�." });

        //�糪 �ʻ�ȭ
        for(int i=0;i<4;i++)
        {
            portray.Add(1000 + i, portrayArr[i]);
        }
        //�絵 �ʻ�ȭ
        for(int i=4;i<8;i++)
        {
            portray.Add(2000 + (i-4), portrayArr[i]);
        }

        talk.Add(1010, new string[] { "�ȳ�?:0", "�̰��� ó���̱���?:1", "�絵���� ���� ȣ���� ������ �˷��ٰž�:1" });
        talk.Add(2011, new string[] { "�ȳ�?:0", "�Ƹ��ٿ� ȣ����?:1", "�� ȣ������ ������ �־�:1", "�� ����� ã���ָ� ������ �� �����ž�:1" });
        talk.Add(1020, new string[] { "�絵 ����� �����?:1","���� ������ �� ����ε� �Ҿ���ȴٰ�?:3" });
        talk.Add(2020, new string[] {"����� ã���� ���� ������ ��~:1"});
        talk.Add(5020, new string[] {"�絵�� ����� ã�Ҵ�!"});
        talk.Add(2021, new string[] { "ã���༭ ����!:2","���� ������ �̾߱� �� �� �ְھ�:1" });
        talk.Add(2030, new string[] {"�� ȣ������ �Ŵ��� ����Ⱑ ��ٰ� ������:1","�������� ������� ��� ��� ��������� �ƹ��� ����:0"});
        talk.Add(1, new string[] {"���� ���� ������ �̵��� �� �����."});
        talk.Add(31, new string[] { "���� ������ �̵��Ͻðھ��?" });
    }

    void Generate_Object_Talking()
    {
        talk.Add(0, new string[] {"������ �������ٰ� �������� ȣ���̴�. �絵���� ������ ���� �� ���� �� ����:0"});
        portray.Add(0, PlayerPortray[0]);
    }

    public string GetTalk(int id, int talkindex)
    {
        if(!talk.ContainsKey(id))
        {
            int index = (id / 1000) * 1000;
            if (talkindex == talk[index].Length)
                return null;
            else
                return talk[index][talkindex];
        }
        else
        {
            if (talk[id].Length == talkindex)
                return null;
            return talk[id][talkindex];
        }
    }

    public Sprite GetPortrait(int id,int portrayindex)
    {
        if (id == 0)
            return PlayerPortray[id];
        else
            return portray[id + portrayindex];
    }

    public Sprite Scene_NPC_Portray()
    {
        return scene_npc_portray[0];
    }
}
