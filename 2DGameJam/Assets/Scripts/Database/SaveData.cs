using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public Field fields;

    [Serializable]
    public class Field
    {
        public PlayerHP playerHP;
        public PlayerPoints playerPoints;
        public Character character;
        public CurrentLevel currentLevel;

        [Serializable]
        public class PlayerHP
        {
            public float integerValue;
        }

        [Serializable]
        public class PlayerPoints
        {
            public int integerValue;
        }

        [Serializable]
        public class Character
        {
            public string stringValue;
        }

        [Serializable]
        public class CurrentLevel
        {
            public int integerValue;
        }
    }
}
