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
        // 배열선언은 new로 한다..
        talk = new Dictionary<int, string[]>();
        portray = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talk.Add(1000, new string[] { "뿌뿌우~~?:0" });
        talk.Add(2000, new string[] {"여긴 저수지 용수를 관리하는 발전소야:0","관리자 외에는 들어갈 수 없다고 하네?:0"});
        talk.Add(3000, new string[] {"발전소에 연결된 저수지다.:0"});
        talk.Add(4000, new string[] {"벽으로 막혀있어 갈 수 없다.:0"});
        talk.Add(100, new string[] { "단단해보이는 돌이다." });

        // 추후 초상화 업데이트
        portray.Add(1000, portrayArr[0]);
        portray.Add(1001, portrayArr[1]);
        portray.Add(2000, portrayArr[2]);
        portray.Add(4000, portrayArr[3]);
        portray.Add(2002, portrayArr[4]);

        talk.Add(1010, new string[] { "우우우......우....:0","대충 물을 가져다 달라는 말 같다.:1" });
        talk.Add(2011, new string[] { "아~ 펫한테 줄 물?:0", "위에 저수지에서 가져다 주면 돼!:0" });
        talk.Add(3012, new string[] { "물을 담았다! 이제 물을 펫에게 전달해주자~.:0" });

        talk.Add(1020, new string[] {"우우우우~~~!!:0","목이 많이 말랐던 모양이다.:1"});

        talk.Add(4030, new string[] { "굳건해 보이는 벽이다. 키가 필요할 것 같다.:0" });
        talk.Add(2031, new string[] {"너가 펫에게 물을 준 아이구나!:2","발전소키를 빌려줄게! 구경하고 와~:2"});
        talk.Add(4032, new string[] {"벽이 열렸다!:0"});
        talk.Add(5033, new string[] { "황금 동전을 획득했다!!!:0", "더 이상 다른 곳을 가지 않아도 될 것 같다~:0" });

        talk.Add(1, new string[] { "아직 다음 맵으로 이동할 수 없어요." });
        talk.Add(31, new string[] { "다음 맵으로 이동하시겠어요?" });
    }

    public string GetTalk(int id, int talkindex)
    {
        // key값이 talk안에 없다면 해당 npc의 기본 대사를 반환하게한다.
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
