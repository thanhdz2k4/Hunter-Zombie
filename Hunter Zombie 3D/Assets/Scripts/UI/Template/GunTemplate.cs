using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class GunTemplate 
{
    public event Action<GunSO> BuyItemClicked;
    public event Action<GunSO> InforItemClicked;

    const string id_Image_Item__VisualElement = "Image_Gun--Component";
    const string id_Name_Item__Label = "Name_Gun--Component";
    const string id_Buy_Item__Button = "Buy_Gun_Button--Component";
    const string id_Infor_Item__Button = "Infor_Gun_Button--Component";

    const string id_Common_item__Color = "#00FF19";
    const string id_Uncommon_item__Color = "#00FFE2";
    const string id_Rare_item__Color = "#0028FF";
    const string id_Epic_item__Color = "#FF00FD";
    const string id_Legendary_item__Color = "#FF0800";
    const string id_MyThic_item__Color = "#FFEE00";


    GunSO gunSO;

    //visual elements
    VisualElement m_Image__Item;
    Label m_Name__Item;
    Button m_Buy_Item__Button;
    Button m_Infor_Item__Button;

    public GunTemplate(GunSO gunSO) 
    {
        this.gunSO = gunSO;
    }

    public void SetVisualElements(TemplateContainer itemComponent)
    {
        m_Image__Item = itemComponent.Q(id_Image_Item__VisualElement);
        m_Name__Item = itemComponent.Q<Label>(id_Name_Item__Label);
        m_Buy_Item__Button = itemComponent.Q<Button>(id_Buy_Item__Button);
        m_Infor_Item__Button = itemComponent.Q<Button>(id_Infor_Item__Button);
        CheckError(m_Image__Item, id_Image_Item__VisualElement);
        CheckError(m_Name__Item, id_Name_Item__Label);
        CheckError(m_Buy_Item__Button, id_Buy_Item__Button);
        CheckError(m_Infor_Item__Button, id_Infor_Item__Button);

    }

    private void CheckError(VisualElement visualElement, string id) 
    {
        if(visualElement == null)  Console.WriteLine($"VisualElement '{visualElement}' not found. With id :{id}" );
    }


    public void SetGameData(TemplateContainer itemComponent)
    {
        if (itemComponent == null)
            return;

        // basic name and image
        m_Image__Item.style.backgroundImage = gunSO.Texture2D;
        m_Name__Item.text = gunSO.Name_Gun;
        m_Buy_Item__Button.text = gunSO.Price.ToString();
        SetColor(m_Image__Item, CategorizeGun(gunSO));

        
    }

    private string CategorizeGun(GunSO gunSO) 
    {
        switch (gunSO.Rarity_Tiers)
        {
            case Rarity_Tiers.Common:
                return id_Common_item__Color;
            case Rarity_Tiers.Uncommon:
                return id_Uncommon_item__Color;
            case Rarity_Tiers.Epic:
                return id_Epic_item__Color;
            case Rarity_Tiers.Legendary:
                return id_Legendary_item__Color;
            case Rarity_Tiers.MyThic:
                return id_MyThic_item__Color;
            case Rarity_Tiers.Rare:
                return id_Rare_item__Color;
        }
        return null;
    }

    private void SetColor(VisualElement visualElement, string color)
    {
        Color newColor;
       
        if (ColorUtility.TryParseHtmlString(color, out newColor))
        {
            newColor.a = 0.2f;
            visualElement.style.backgroundColor = newColor; 
            return;
        }
    }

    public void RegisterCallbacks()
    {
        m_Buy_Item__Button.RegisterCallback<ClickEvent>(BuyGunEvent);
        m_Infor_Item__Button.RegisterCallback<ClickEvent>(InforGunEvent);
    }

    private void InforGunEvent(ClickEvent evt)
    {
        InforItemClicked?.Invoke(gunSO);
    }

    private void BuyGunEvent(ClickEvent evt)
    {
        BuyItemClicked?.Invoke(gunSO);

    }
}
