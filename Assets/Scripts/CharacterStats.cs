using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class CharacterStats {

    [SerializeField]
    public int baseValue;

    public int GetValue()
    {
        return baseValue;
    }
}

