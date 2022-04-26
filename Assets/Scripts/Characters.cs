using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Characters:IComparable<Characters>
{
    public string name;
    public int score;

    public Characters(string newName, int newScore)
    {
        name = newName;
        score = newScore;
    }

    public int CompareTo(Characters other)
    {
        if(other == null)
        {
            return 1;
        }

        //Return the difference in power.
        return score - other.score;
    }
}
