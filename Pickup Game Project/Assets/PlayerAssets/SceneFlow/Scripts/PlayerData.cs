using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData/NewPlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public int Playerscore;
    public float VolumeLevel = 1.0f;
    public float SoundFxLevel = 1.0f;
}
