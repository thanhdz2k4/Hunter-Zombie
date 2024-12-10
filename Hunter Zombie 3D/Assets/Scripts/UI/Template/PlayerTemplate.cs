using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class PlayerTemplate 
{
    string id_Name_Player__Label = "Name_Player_Template--Label";
    string id_Code_Player__Label = "Code_Player_Template--Label";
    string id_State_Player__Label = "State_Player_Template--Label";
    string id_Image_Player__Visual = "Avatar_Player_Template--Visual";
    string id_Frame_Player__Visual = "Frame_Player_Template--Visual";
    string id_Add_Player__Button = "Add_Friend_Template--Button";
    string id_Information_Player__Button = "Infor_Friend_Template--Button";

    string id_Online_State__Color = "#13FF00";
    string id_Offline_State_Color = "#FF0000";

    Label m_Name_Player__Label, m_Code_Player__Label, m_State_Player__Label;
    VisualElement m_Image_Player__Visual, m_Frame_Player__Visual;
    Button m_Add_Player__Button, m_Information_Player__Button;




    PlayerSO playerSO;
    GunSO gunSO;

    public event Action<string> Add_Friend_Event;
    public event Action<PlayerSO> Show_More_Information_Event;

    public PlayerTemplate(PlayerSO playerSO)
    {
        this.playerSO = playerSO;
        this.gunSO = this.playerSO.gunSO;
    }

     public void SetVisualElements(TemplateContainer itemComponent)
    {
        // Query the parts of the itemComponent
        m_Image_Player__Visual = itemComponent.Q(id_Image_Player__Visual);
        m_Frame_Player__Visual = itemComponent.Q(id_Frame_Player__Visual);

        m_Name_Player__Label = itemComponent.Q<Label>(id_Name_Player__Label);
        m_Code_Player__Label = itemComponent.Q<Label>(id_Code_Player__Label);
        m_State_Player__Label = itemComponent.Q<Label>(id_State_Player__Label);

        m_Add_Player__Button = itemComponent.Q<Button>(id_Add_Player__Button);
        m_Information_Player__Button = itemComponent.Q<Button>(id_Information_Player__Button);
        

       CheckNullElement(m_Image_Player__Visual, id_Image_Player__Visual);
       CheckNullElement(m_Frame_Player__Visual, id_Frame_Player__Visual);

       CheckNullElement(m_Name_Player__Label, id_Name_Player__Label);
       CheckNullElement(m_Code_Player__Label, id_Code_Player__Label);
       CheckNullElement(m_State_Player__Label, id_State_Player__Label);

       CheckNullElement(m_Add_Player__Button, id_Add_Player__Button);
       CheckNullElement(m_Information_Player__Button, id_Information_Player__Button);
    }

    private void CheckNullElement(VisualElement visualElement, string id)
    {
        if (visualElement == null)
            Debug.LogError($"VisualElement '{id}' not found.");
    }

    public void SetGameData(TemplateContainer itemComponent)
    {
        if (itemComponent == null)
            return;

        m_Image_Player__Visual.style.backgroundImage = playerSO.avatar_Image;
        m_Frame_Player__Visual.style.backgroundImage = playerSO.avatar_Frame;

        m_Name_Player__Label.text = "Name: " + playerSO.name_Player;
        m_State_Player__Label.text = "State: " + playerSO.state;
        m_Code_Player__Label.text = "Friend code: " + playerSO.code;

        if(playerSO.state == "Online")
        {
            SetColor(m_State_Player__Label, id_Online_State__Color);
        } else {
            SetColor(m_State_Player__Label, id_Offline_State_Color);
        }
        
    }

    public void SetColor(VisualElement element, string color) {
        Color newColor;
        if (ColorUtility.TryParseHtmlString(color, out newColor))
        {
            element.style.backgroundColor = newColor; // Set the background color
            return;
        }
    }

    public void ResigterEvent() 
    {
        m_Add_Player__Button.RegisterCallback<ClickEvent>(HandleAddFriend);
        m_Information_Player__Button.RegisterCallback<ClickEvent>(HandShowMoreInformation);

    }

    private void HandShowMoreInformation(ClickEvent evt)
    {
        Add_Friend_Event.Invoke(playerSO.name_Player);
    }

    private void HandleAddFriend(ClickEvent evt)
    {
        Show_More_Information_Event.Invoke(playerSO);
    }
}
