using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class InforPayerScreen : MenuScreen
{
    [Header("ID ELEMENTS IN SCRENE")]
    [SerializeField] string id_avatar__Image;
    [SerializeField] string id_Frame__Image;
    [SerializeField] string id_Add__Button;
    [SerializeField] string id_Level_Player__Label;
    [SerializeField] string id_Name_Player__Label;
    [SerializeField] string id_Level_bar__Visual;
    [SerializeField] string id_Attack__Label;
    [SerializeField] string id_Armor__Label;
    [SerializeField] string id_Hp__Label;
    [SerializeField] string id_State__Label;
    [SerializeField] string id_Code__Label;
    [SerializeField] string id_Description_Player__Label;
    [SerializeField] string id_Back__Button;
    [SerializeField] string id_Character_model__Texture2D;
    [SerializeField] string id_Level_Character__Label;
    
    [Header("ID ELEMENTS GUN IN SCREEN")]
    [SerializeField] string id_Name_Gun__Label;
    [SerializeField] string id_Change_Rate__Visual;
    [SerializeField] string id_Impace__Visual;
    [SerializeField] string id_Range__Visual;
    [SerializeField] string id_Stability__Visual;
    [SerializeField] string id_Reload__Visual;
    [SerializeField] string id_Description__Label;
    [SerializeField] string id_Gun__Image;


    VisualElement m_avatar__Image;
    VisualElement m_Frame__Image;
    Button m_Add__Button;
    Label m_Level_Player__Label;
    Label m_Name_Player__Label;
    VisualElement m_Level_bar__Visual;
    Label m_Attack__Label;
    Label m_Armor__Label;
    Label m_Hp__Label;
    Label m_State__Label;
    Label m_Code__Label;
    Label m_Description_Player__Label;
    Button m_Back__Button;
    VisualElement m_Character_model__Texture2D;
    Label m_Level_Character__Label;

    Label m_Name_Gun__Label;
    VisualElement m_Change_Rate__Visual;
    VisualElement m_Impace__Visual;
    VisualElement m_Range__Visual;
    VisualElement m_Stability__Visual;
    VisualElement  m_Reload__Visual;
    Label m_Description__Label;
    VisualElement m_Gun__Image;
    
    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_avatar__Image = m_Root.Q<VisualElement>(id_avatar__Image);
        m_Frame__Image = m_Root.Q<VisualElement>(id_Frame__Image);
        m_Add__Button = m_Root.Q<Button>(id_Add__Button);
        m_Level_Player__Label = m_Root.Q<Label>(id_Level_Player__Label);
        m_Name_Player__Label = m_Root.Q<Label>(id_Name_Player__Label);
        m_Level_bar__Visual = m_Root.Q<VisualElement>(id_Level_bar__Visual);
        m_Attack__Label = m_Root.Q<Label>(id_Attack__Label);
        m_Armor__Label = m_Root.Q<Label>(id_Armor__Label);
        m_Hp__Label = m_Root.Q<Label>(id_Hp__Label);
        m_State__Label = m_Root.Q<Label>(id_State__Label);
        m_Code__Label = m_Root.Q<Label>(id_Code__Label);
        m_Description_Player__Label = m_Root.Q<Label>(id_Description_Player__Label);
        m_Back__Button = m_Root.Q<Button>(id_Back__Button);
        m_Character_model__Texture2D = m_Root.Q<VisualElement>(id_Character_model__Texture2D);
        m_Level_Character__Label = m_Root.Q<Label>(id_Level_Character__Label);

        m_Name_Gun__Label = m_Root.Q<Label>(id_Name_Gun__Label);
        m_Change_Rate__Visual = m_Root.Q<VisualElement>(id_Change_Rate__Visual);
        m_Impace__Visual = m_Root.Q<VisualElement>(id_Impace__Visual);
        m_Range__Visual = m_Root.Q<VisualElement>(id_Range__Visual);
        m_Stability__Visual = m_Root.Q<VisualElement>(id_Stability__Visual);
        m_Reload__Visual = m_Root.Q<VisualElement>(id_Reload__Visual);
        m_Description__Label = m_Root.Q<Label>(id_Description__Label);
        m_Gun__Image = m_Root.Q<VisualElement>(id_Gun__Image);
             
    }

    protected override void RegisterButtonCallBacks()
    {
        base.RegisterButtonCallBacks();
        m_Add__Button.RegisterCallback<ClickEvent>(HandleAddFriendEvent);
        m_Back__Button.RegisterCallback<ClickEvent>(HandleBackScreen);
    }

    private void HandleBackScreen(ClickEvent evt)
    {
        m_UIController.ShowListPlayerScreen();
        HideScreen();
    }

    private void HandleAddFriendEvent(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    public void SetData(PlayerSO playerSO) 
    {
        GunSO gunSO = playerSO.gunSO;
        m_avatar__Image.style.backgroundImage = playerSO.avatar_Image;
        m_Frame__Image.style.backgroundImage = playerSO.avatar_Frame;
        m_Level_Player__Label.text = playerSO.player_Level;
        m_Name_Player__Label.text = playerSO.name_Player;
        m_Level_bar__Visual.style.width = new Length(playerSO.character_bar_Level, LengthUnit.Percent); ;
        m_Attack__Label.text = playerSO.attack.ToString();
        m_Armor__Label.text = playerSO.armor.ToString();
        m_Hp__Label.text = playerSO.hp.ToString();
        m_State__Label.text = playerSO.state.ToString();
        m_Code__Label.text = playerSO.code;
        m_Description_Player__Label.text = playerSO.description;
        AssignRenderTextureToBackground(m_Character_model__Texture2D, playerSO.character_Model);
        m_Level_Character__Label.text = playerSO.character_Level.ToString() ;

        m_Name_Gun__Label.text = gunSO.Name_Gun;
        m_Change_Rate__Visual.style.width = new Length(gunSO.Charge_Rate, LengthUnit.Percent);
        m_Impace__Visual.style.width = new Length(gunSO.Impact, LengthUnit.Percent) ;
        m_Range__Visual.style.width = new Length(gunSO.Range, LengthUnit.Percent) ;
        m_Stability__Visual.style.width = new Length(gunSO.Stability, LengthUnit.Percent) ;
        m_Reload__Visual.style.width = new Length(gunSO.Reload, LengthUnit.Percent);
        m_Description__Label.text = gunSO.Description;
        m_Gun__Image.style.backgroundImage = gunSO.Texture2D;
    }

    public void AssignRenderTextureToBackground(VisualElement element, RenderTexture renderTexture)
    {
        RenderTexture.active = renderTexture;
    
        // Create a new Texture2D with RenderTexture dimensions
        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);

        // Copy the RenderTexture into the Texture2D
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture.Apply();
    
        // Assign the Texture2D to the backgroundImage
        element.style.backgroundImage = new StyleBackground(texture);

        // Release RenderTexture
        RenderTexture.active = null;
    
    }

}
