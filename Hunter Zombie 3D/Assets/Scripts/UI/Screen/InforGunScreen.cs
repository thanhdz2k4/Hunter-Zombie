using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UIElements;

public class InforGunScreen : MenuScreen
{
    [Header("ID ELEMENTS IN SCREEN")]
    [SerializeField] string id_Change_Rate__Visual;
    [SerializeField] string id_Impact__Visual;
    [SerializeField] string id_Range__Visual;
    [SerializeField] string id_Stability__Visual;
    [SerializeField] string id_Reload__Visual;
    [SerializeField] string id_Description__Label;
    [SerializeField] string id_Back__Button;
    [SerializeField] string id_Consuming_Attack__Label;
    [SerializeField] string id_Rarity_Tiers__Label;
    [SerializeField] string id_Quantity_Bullet__Label;
    [SerializeField] string id_Gun_Image__Visual;
    [SerializeField] string id_Type_Gun__Visual; 

    [Header("GUN TYPE TEXTURE 2D")]
    [SerializeField] Texture2D Assault_Rifles_Image;
    [SerializeField] Texture2D DMRs_Image;
    [SerializeField] Texture2D Pistols_Image;
    [SerializeField] Texture2D ShotgunsImage;
    [SerializeField] Texture2D SMGs_Image;
    [SerializeField] Texture2D Sniper_Rifles_Image;


    VisualElement m__Gun_Image__Visual;
    VisualElement m_Change_Rate__Visual;
    VisualElement m__Impact__Visual;
    VisualElement m__Range__Visual;
    VisualElement m__Stability__Visual;
    VisualElement m__Reload__Visual;
    VisualElement m_Type_Gun__Visual;


    Button m__Back__Button;
    Label m__Description__Label;
    Label m__Consuming_Attack__Label;
    Label m__Rarity_Tiers__Label;
    Label m__Quantity_Bullet__Label;

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m__Gun_Image__Visual = m_Root.Q<VisualElement>(id_Gun_Image__Visual);
        m_Change_Rate__Visual = m_Root.Q<VisualElement>(id_Change_Rate__Visual);
        m__Impact__Visual = m_Root.Q<VisualElement>(id_Impact__Visual);
        m__Range__Visual = m_Root.Q<VisualElement>(id_Range__Visual);
        m__Stability__Visual = m_Root.Q<VisualElement>(id_Stability__Visual);
        m__Reload__Visual = m_Root.Q<VisualElement>(id_Reload__Visual);
        m_Type_Gun__Visual = m_Root.Q<VisualElement>(id_Type_Gun__Visual);
        
        m__Back__Button = m_Root.Q<Button>(id_Back__Button);

        m__Description__Label = m_Root.Q<Label>(id_Description__Label);
        m__Consuming_Attack__Label = m_Root.Q<Label>(id_Consuming_Attack__Label);
        m__Rarity_Tiers__Label = m_Root.Q<Label>(id_Rarity_Tiers__Label);
        m__Quantity_Bullet__Label = m_Root.Q<Label>(id_Quantity_Bullet__Label);
    }

    protected override void RegisterButtonCallBacks()
    {
        base.RegisterButtonCallBacks();
        m__Back__Button.RegisterCallback<ClickEvent>(HandleCloseScreenEvent);
    }

    private void HandleCloseScreenEvent(ClickEvent evt)
    {
        m_UIController.ShowGunShopScreen();
    }

    public void SetData(GunSO gunSO) 
    {
        m__Gun_Image__Visual.style.backgroundImage = gunSO.Texture2D;
        m_Change_Rate__Visual.style.width = new Length(gunSO.Charge_Rate, LengthUnit.Percent);
        m__Impact__Visual.style.width = new Length(gunSO.Impact, LengthUnit.Percent);
        m__Range__Visual.style.width = new Length(gunSO.Range, LengthUnit.Percent);
        m__Stability__Visual.style.width = new Length(gunSO.Stability, LengthUnit.Percent);
        m__Reload__Visual.style.width = new Length(gunSO.Reload, LengthUnit.Percent);
        m_Type_Gun__Visual.style.backgroundImage = Catetogize_Type(gunSO.Type_Gun);

        m__Description__Label.text = gunSO.Description;
        m__Consuming_Attack__Label.text = gunSO.Comsuming_Attack.ToString();
        m__Rarity_Tiers__Label.text = Catetogize_Rarity_Tiers(gunSO.Rarity_Tiers);
        m__Quantity_Bullet__Label.text = gunSO.Buttlet_Quantity.ToString();

    }

    private Texture2D Catetogize_Type(Type_Gun type_Gun)
    {
        switch (type_Gun)
        {
            case Type_Gun.Assault_Rifles:
                return Assault_Rifles_Image;
            case Type_Gun.DMRs:
                return DMRs_Image;
            case Type_Gun.Pistols:
                return Pistols_Image;
            case Type_Gun.Shotguns:
                return ShotgunsImage;
            case Type_Gun.SMG:
                return SMGs_Image;
            case Type_Gun.Sniper_Rifles:
                return Sniper_Rifles_Image;

        }
        return null;
    }

    private string Catetogize_Rarity_Tiers(Rarity_Tiers rarity_Tiers)
    {
        switch(rarity_Tiers)
        {
            case Rarity_Tiers.Common:
                return "C";
            case Rarity_Tiers.Uncommon:
                return "U";
            case Rarity_Tiers.Epic:
                return "E";
            case Rarity_Tiers.MyThic:
                return "M";
            case Rarity_Tiers.Legendary:
                return "L";
            case Rarity_Tiers.Rare:
                return "R";
        }

        return null;
    }
}
