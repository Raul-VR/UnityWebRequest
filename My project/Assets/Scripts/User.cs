using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class User
{
    public string group;
    public string listNumber;
    public List<Level> history;
}

[System.Serializable]

public class Level
{
    public string level;
    public string score;
}