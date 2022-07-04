using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager2 : MonoBehaviour
{
    Dictionary<int, string[]> talk;
    Dictionary<int, Sprite> portray;
    public Sprite[] portrayArr;
    public Sprite[] PlayerPortray;
    public Sprite[] scene_npc_portray;
    public gamemanager2 manager;
    public questmanager2 questmanager;

    void Awake()
    {
        // �迭������ new�� �Ѵ�..
        talk = new Dictionary<int, string[]>();
        portray = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talk.Add(1000, new string[] { "�ѻѿ�~~?:0" });
        talk.Add(2000, new string[] {"���� ������ ����� �����ϴ� �����Ҿ�:0","������ �ܿ��� �� �� ���ٰ� �ϳ�?:0"});
        talk.Add(3000, new string[] {"�����ҿ� ����� ��������.:0"});
        talk.Add(4000, new string[] {"������ �����־� �� �� ����.:0"});
        talk.Add(100, new string[] { "�ܴ��غ��̴� ���̴�." });

        // ���� �ʻ�ȭ ������Ʈ
        portray.Add(1000, portrayArr[0]);
        portray.Add(1001, portrayArr[1]);
        portray.Add(2000, portrayArr[2]);
        portray.Add(4000, portrayArr[3]);
        portray.Add(2002, portrayArr[4]);

        talk.Add(1010, new string[] { "����......��....:0","���� ���� ������ �޶�� �� ����.:1" });
        talk.Add(2011, new string[] { "��~ ������ �� ��?:0", "���� ���������� ������ �ָ� ��!:0" });
        talk.Add(3012, new string[] { "���� ��Ҵ�! ���� ���� �꿡�� ����������~.:0" });

        talk.Add(1020, new string[] {"�����~~~!!:0","���� ���� ������ ����̴�.:1"});

        talk.Add(4030, new string[] { "������ ���̴� ���̴�. Ű�� �ʿ��� �� ����.:0" });
        talk.Add(2031, new string[] {"�ʰ� �꿡�� ���� �� ���̱���!:2","������Ű�� �����ٰ�! �����ϰ� ��~:2"});
        talk.Add(4032, new string[] {"���� ���ȴ�!:0"});
        talk.Add(5033, new string[] { "Ȳ�� ������ ȹ���ߴ�!!!:0", "�� �̻� �ٸ� ���� ���� �ʾƵ� �� �� ����~:0" });

        talk.Add(1, new string[] { "���� ���� ������ �̵��� �� �����." });
        talk.Add(31, new string[] { "���� ������ �̵��Ͻðھ��?" });
    }

    public string GetTalk(int id, int talkindex)
    {
        // key���� talk�ȿ� ���ٸ� �ش� npc�� �⺻ ��縦 ��ȯ�ϰ��Ѵ�.
        if (!talk.ContainsKey(id))
        {
            int index = (id / 1000) * 1000;
            if (talkindex == talk[index].Length)
                return null;
            else
            {
                return talk[index][talkindex];
            }
        }
        else
        {
            if (talk[id].Length == talkindex)
                return null;
            return talk[id][talkindex];
        }
    }

    public Sprite GetPortrait(int id, int portrayindex)
    {
        if(id==3000 || id==5000)
        {
            return portray[1001];
        }
        return portray[id + portrayindex];
    }

    public Sprite Scene_NPC_Portray()
    {
        return scene_npc_portray[0];
    }
}
