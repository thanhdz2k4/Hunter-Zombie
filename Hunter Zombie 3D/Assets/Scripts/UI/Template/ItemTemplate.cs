using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class ItemTemplate 
{
    #region id elements in ui 
    string id_Item__Button = "Icons_Inventory--Button";
    string id_Quantity__Label = "Quantity_Inventory--Label";
    #endregion

    #region id Theme Null Item USS
    string id_Theme_Null_Item__USS = "Null_Icons_Inventory";
    string id_Them_Has_Item__USS = "Unselect_Icons_Inventory--Button";
    #endregion



    Button m_Item__Button;
    Label m_Quantity__Label;

    ItemSO itemSO;

    public event Action<ItemSO> Item_Click_Event;

    public ItemTemplate(ItemSO itemSO)
    {
        this.itemSO = itemSO;
    }

    public void SetVisualElement(TemplateContainer itemComponent)
    {
        m_Item__Button = itemComponent.Q<Button>(id_Item__Button);
        m_Quantity__Label = itemComponent.Q<Label>(id_Quantity__Label);
        CheckNullElement(m_Quantity__Label, id_Quantity__Label);
        CheckNullElement(m_Item__Button, id_Item__Button);
    }
    private void CheckNullElement(VisualElement visualElement, string id)
    {
        if (visualElement == null)
            Debug.LogError($"VisualElement '{id}' not found.");
    }

    public void SetGameData(TemplateContainer itemComponent)
    {
        if (itemComponent == null) return;

        if(itemSO.isNull)
        {
            m_Item__Button.RemoveFromClassList(id_Them_Has_Item__USS);
            m_Item__Button.AddToClassList(id_Theme_Null_Item__USS);
            m_Item__Button.text = "+";
            m_Quantity__Label.text = "";
            m_Item__Button.style.backgroundImage = null;

        } else
        {
            m_Item__Button.AddToClassList(id_Them_Has_Item__USS);
            m_Item__Button.RemoveFromClassList(id_Theme_Null_Item__USS);
            m_Quantity__Label.text = itemSO.quantity;
            m_Item__Button.style.backgroundImage = itemSO.image;
        }
    }

    public void RegisterCallbacks()
    {
        m_Item__Button.RegisterCallback<ClickEvent>(HandleClickEvent);
    }

    private void HandleClickEvent(ClickEvent evt)
    {
        Item_Click_Event.Invoke(itemSO);
    }
}
