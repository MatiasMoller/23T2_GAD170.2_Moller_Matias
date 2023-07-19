using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]

public class CrewmateApplication
{
    private static List<string> humanNames = new List<string>() { "John", "Emma", "Michael", "Sarah", "David", "Charlie", "Miguel", "Matilda", "Carla", "Emily" };
    private static List<string> humanHobbies = new List<string>() { "Painting", "Cooking", "Reading", "Gardening", "Playing an instrument", "Jogging", "Playing Video Games", "Eating", "Sleeping", "Skating" };
    private static List<string> parasiteHobbies = new List<string>() { "Conquering worlds", "Infiltrating societies", "Assimilating knowledge", "Manipulating minds", "Eating brains", "Shapeshifting", "Multiplying" };

    public bool isParasite;
    public bool hasParasiteHobby;
    public string name;
    public string hobby;

    public CrewmateApplication(bool isParasite)
    {
        name = humanNames[new System.Random().Next(0, humanNames.Count - 1)];
        this.isParasite = isParasite;
        hasParasiteHobby = (isParasite && UnityEngine.Random.Range(0, 2) == 1);

        if (hasParasiteHobby)
        {
            hobby = parasiteHobbies[new System.Random().Next(0, parasiteHobbies.Count - 1)];
        }
        else
        {
            hobby = humanHobbies[new System.Random().Next(0, humanHobbies.Count - 1)];
        }
    }
}

