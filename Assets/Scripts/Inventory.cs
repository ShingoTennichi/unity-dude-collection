using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{

    [SerializeField] private GameObject ItemCell;
    [SerializeField] private GameObject ItemDetailView;
    private GameObject inventoryContainer;
    private List<Item> items;
    private Dictionary<string, TextMeshProUGUI> itemTextMap = new Dictionary<string, TextMeshProUGUI>();

    private void Awake()
    {

        InventoryManager inventoryManager = FindAnyObjectByType<InventoryManager>();
        inventoryContainer = GameObject.Find("Inventory Container");

        if (inventoryManager != null)
        {
            items = inventoryManager.ItemList;    
        }
        populateItems(items);
    }

    private void Update()
    {
        updateItems();
    }

    private void populateItems(List<Item> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            Item item = items[i];
            if (item.Count > 0)
            {
                createItemCell(item);
            }
        }
    }

    private void createItemCell(Item item)
    {
        GameObject newItem = Instantiate(ItemCell, inventoryContainer.transform);
        Button button = newItem.GetComponentInChildren<Button>();
        if (button != null)
        {
            button.onClick.AddListener(showDetail);
        }


        Transform[] children = newItem.GetComponentsInChildren<Transform>();


        TextMeshProUGUI textLabel = children[1].gameObject.GetComponentInChildren<TextMeshProUGUI>();
        textLabel.text = item.Name;

        TextMeshProUGUI numberOfItem = children[2].gameObject.GetComponentInChildren<TextMeshProUGUI>();
        numberOfItem.text = item.Count.ToString();

        Image itemImage = children[3].gameObject.GetComponentInChildren<Image>();
        itemImage.sprite = item.Image;

        itemTextMap[item.Name] = numberOfItem;
    }

    private void updateItems()
    {
        Transform currentItems = inventoryContainer.transform;
        foreach (Item item in items)
        {
            if (item.Count > 0 && itemTextMap.ContainsKey(item.Name))
            {
                TextMeshProUGUI numberOfItem = itemTextMap[item.Name];
                numberOfItem.text = item.Count.ToString();
            }
            else if(item.Count > 0)
            {
                createItemCell(item);
            }
        }
    }

    public void showDetail()
    {
        //GameObject clickedObject = EventSystem.current.currentSelectedGameObject;
        //Image img = clickedObject.GetComponentInChildren<Image>();
        //TextMeshProUGUI txt = clickedObject.GetComponentInChildren<TextMeshProUGUI>();
        //GameObject itemDetailView = GameObject.Find("ItemDetailView");
        //if (itemDetailView == null)
        //{
        //    GameObject itemViewBackground = GameObject.Find("ItemViewBackground");
        //    Instantiate(ItemDetailView, itemViewBackground.transform);
        //    itemDetailView = GameObject.Find("ItemDetailView");
        //}

        //Image image = itemDetailView.GetComponentInChildren<Image>();
        //Debug.Log(image);
        //image.sprite = img.sprite;
        //TextMeshProUGUI text = itemDetailView.GetComponentInChildren<TextMeshProUGUI>();
        //Debug.Log(text);
        //text.text = txt.text;

        //Debug.Log();
    }
}
