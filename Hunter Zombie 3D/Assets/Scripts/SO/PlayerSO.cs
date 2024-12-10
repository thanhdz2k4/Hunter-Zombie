using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Assets/Data/Player", menuName = "PlayerSO/Player")]
public class PlayerSO : ScriptableObject
{
    [Header("PLAYER'S INFORMATION")]
    public Texture2D avatar_Image;
    public Texture2D avatar_Frame;
    public  RenderTexture character_Model;
    public string name_Player;
    public string state;
    public string code;
    public string player_Level;
    public string character_Level;
    public int character_bar_Level;
    public int attack;
    public int armor;
    public int hp;

    [TextArea(0, 300)]
    public string description;

    [Header("GUN'S INFORMATION")]
    public GunSO gunSO;






}
