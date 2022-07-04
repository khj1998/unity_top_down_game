using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questdata2 : MonoBehaviour
{
    public string questname;
    public int[] NPCid;

    public questdata2(string name, int[] id)
    {
        questname = name;
        NPCid = id;
    }
}
