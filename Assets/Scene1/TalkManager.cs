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
        // 배열선언은 new로 한다..
        talk = new Dictionary<int, string[]>();
        portray = new Dictionary<int, Sprite>();
        GenerateData();
        Generate_Object_Talking();
    }

    void GenerateData()
    {
        talk.Add(1000, new string[] { "안녕?:0", "처음보는 얼굴인데 이곳에 처음 왔구나?:1" });
        talk.Add(2000, new string[] { "안녕? 내 이름은 LUDO야:0", "이 마을에는 어쩐 일이니?:1", "호수의 전설을 알고있니?:1" });
        talk.Add(100, new string[] { "평범한 박스이다." });
        talk.Add(200, new string[] { "누군가 공부한 흔적이 있는 책상이다." });

        //루나 초상화
        for(int i=0;i<4;i++)
        {
            portray.Add(1000 + i, portrayArr[i]);
        }
        //루도 초상화
        for(int i=4;i<8;i++)
        {
            portray.Add(2000 + (i-4), portrayArr[i]);
        }

        talk.Add(1010, new string[] { "안녕?:0", "이곳은 처음이구나?:1", "루도에게 가면 호수의 전설을 알려줄거야:1" });
        talk.Add(2011, new string[] { "안녕?:0", "아름다운 호수지?:1", "이 호수에는 전설이 있어:1", "내 깃발을 찾아주면 말해줄 수 있을거야:1" });
        talk.Add(1020, new string[] { "루도 깃발이 뭐라고?:1","내가 선물로 준 깃발인데 잃어버렸다고?:3" });
        talk.Add(2020, new string[] {"깃발을 찾으면 내게 가져다 줘~:1"});
        talk.Add(5020, new string[] {"루도의 깃발을 찾았다!"});
        talk.Add(2021, new string[] { "찾아줘서 고마워!:2","이젠 전설을 이야기 할 수 있겠어:1" });
        talk.Add(2030, new string[] {"이 호수에는 거대한 물고기가 산다고 전해져:1","아직까지 본사람이 없어서 어떻게 생겼는지는 아무도 몰라:0"});
        talk.Add(1, new string[] {"아직 다음 맵으로 이동할 수 없어요."});
        talk.Add(31, new string[] { "다음 맵으로 이동하시겠어요?" });
    }

    void Generate_Object_Talking()
    {
        talk.Add(0, new string[] {"전설이 전해진다고 내려오는 호수이다. 루도에게 전설을 들을 수 있을 것 같다:0"});
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
