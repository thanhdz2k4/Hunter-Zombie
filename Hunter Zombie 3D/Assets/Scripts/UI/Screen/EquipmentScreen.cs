using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EquipmentScreen : MenuScreen
{
    [Header("ID ELEMENTS IN SCREEN")]
    [SerializeField] string id_ScrollView;
    [SerializeField] string id_Description_Icon_Inventory_Infor__Label;
    [SerializeField] string id_Title_Icon_Inventory_Infor__Label;
    [SerializeField] string id_Image_Icon_Inventory_Infor__Label;

    [Header("Inventory variables")]
    [SerializeField] VisualTreeAsset m_Item__Component;
    [SerializeField] int quantity_Intentory;
    [SerializeField] List<ItemSO> listOfItems;
   

    List<VisualElement> m_RowParents;
    VisualElement m_ScollView;
    Label m_Description_Icon_Inventory_Infor__Label;
    Label m_Title_Icon_Inventory_Infor__Label;
    Label m_Image_Icon_Inventory_Infor__Label;

    void Start()
    {
        InitializeSlotInventory(listOfItems);
    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_ScollView = m_Root.Q<ScrollView>(id_ScrollView);
        m_Description_Icon_Inventory_Infor__Label = m_Root.Q<Label>(id_Description_Icon_Inventory_Infor__Label);
        m_Title_Icon_Inventory_Infor__Label = m_Root.Q<Label>(id_Title_Icon_Inventory_Infor__Label);
        m_Image_Icon_Inventory_Infor__Label = m_Root.Q<Label>(id_Image_Icon_Inventory_Infor__Label);

        m_RowParents = m_ScollView.Children() as List<VisualElement>;
    }

    private void InitializeSlotInventory(List<ItemSO> listOfItems)
    {
        int maxCount = Mathf.Clamp(listOfItems.Count, 0, quantity_Intentory * m_RowParents.Count);
        Debug.Log("Max count:" + maxCount);
        for (int i = 0; i < quantity_Intentory * m_RowParents.Count; i++)
        {
            int parentRowIndex = i / quantity_Intentory;
            CreateSlot(listOfItems[i], m_RowParents[parentRowIndex]);
        }
    }

    private void CreateSlot(ItemSO itemSO, VisualElement parentElement)
    {
        TemplateContainer itemTemplate = m_Item__Component.Instantiate();

        ItemTemplate itemUI = new ItemTemplate(itemSO);
        itemUI.SetVisualElement(itemTemplate);
        itemUI.SetGameData(itemTemplate);
        itemUI.RegisterCallbacks();
        itemUI.Item_Click_Event += Handle_Show_Infor_Event;
        parentElement.Add(itemTemplate);
    }

    private void Handle_Show_Infor_Event(ItemSO itemSO)
    {
        if(itemSO.isNull)
        {
            m_Image_Icon_Inventory_Infor__Label.style.backgroundImage = null;
            m_Image_Icon_Inventory_Infor__Label.text = "";
            m_Title_Icon_Inventory_Infor__Label.text = "";
            m_Description_Icon_Inventory_Infor__Label.text = "";
        } else
        {
            m_Image_Icon_Inventory_Infor__Label.style.backgroundImage = itemSO.image;
            m_Image_Icon_Inventory_Infor__Label.text = "";
            m_Title_Icon_Inventory_Infor__Label.text = itemSO.name;
            m_Description_Icon_Inventory_Infor__Label.text = itemSO.description;
        }
    }
}
