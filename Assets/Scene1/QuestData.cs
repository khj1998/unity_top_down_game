using System.Collections;
using System.Collections.Generic;

public class QuestData
{
    public string questname;
    public int[] NPCid;

    public QuestData(string name,int[] id)
    {
        questname = name;
        NPCid = id;
    }
}
