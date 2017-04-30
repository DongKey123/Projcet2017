using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    ScrollRect m_scrollRect;
    List<Item> m_Items;


    int _havingItemNum = 0;
    public Sprite[] m_ItemSpritePrefab;
    public GameObject m_ItemPrefab;
    public Transform m_Content;

    public Item m_nowSelectedItem;

    public Image m_MaskEquipMent;
    public Image m_ClothEquipMent;
    public Image m_LeftWeaponEquipMent;
    public Image m_RightWeaponEquipMent;
    public Image m_ShoesEquipMent;
    bool m_IsOnEquipMask;
    bool m_IsOnEquipCloth;
    bool m_IsOnEquipLeftWeapon;
    bool m_IsOnEquipRightWeapon;
    bool m_IsOnEquipShoesEquip;

    public GameObject m_AvatarMask;
    public GameObject m_AvatarCloth;
    public GameObject m_AvatarLeftWeapon;
    public GameObject m_AvatarRightWeapon;
    public GameObject m_AvatarShoes;

    // Use this for initialization
    void Start () {
        m_Items = new List<Item>();

        //Codo : 나중에 서버로 데이터 불러와서 가져옴
        m_IsOnEquipMask = false;
        m_IsOnEquipCloth = false;
        m_IsOnEquipLeftWeapon = false;
        m_IsOnEquipRightWeapon = false;
        m_IsOnEquipShoesEquip = false;

        AddItem(0);
        AddItem(1);
        AddItem(2);
        AddItem(2);
        AddItem(3);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I))
        {
            AddItem(1);
        }
    }

    void AddItem(int ItemNum)
    {
        GameObject gObj = Instantiate(m_ItemPrefab);
        Item item = gObj.GetComponent<Item>();
        item.ItemNum = ItemNum;
        item.GetComponent<Image>().sprite = m_ItemSpritePrefab[ItemNum];
        switch(ItemNum)
        {
            case 0:
                {
                    item.m_ItemType = ItemType.MASK;
                }
                break;
            case 1:
                {
                    item.m_ItemType = ItemType.CLOTH;
                }
                break;
            case 2:
                {
                    item.m_ItemType = ItemType.WEAPON;
                }
                break;
            case 3:
                {
                    item.m_ItemType = ItemType.SHOES;
                }
                break;
        }

        item.transform.parent = m_Content;

        int x = _havingItemNum % 5;
        int y = _havingItemNum / 5;

        item.GetComponent<RectTransform>().localPosition = new Vector3(110 + 200*x, -100 - 180 * y);
        m_Content.GetComponent<RectTransform>().sizeDelta = new Vector2(0,200 + y * 200);
        
        m_Items.Add(gObj.GetComponent<Item>());
        _havingItemNum++;
    }

    public void RemoveItem(Item item)
    {
        m_Items.Remove(item);
        _havingItemNum--;

        

        for (int i=0;i<m_Items.Count;i++)
        {
            int x = i % 5;
            int y = i / 5;
            m_Items[i].GetComponent<RectTransform>().localPosition = new Vector3(110 + 200 * x, -100 - 180 * y);
        }
    }

    public void SelectItem(Item item)
    {
        m_nowSelectedItem = item;
    }

    public void EquipItem()
    {
        if (m_nowSelectedItem == null)
            return;

        ItemType itemType = m_nowSelectedItem.m_ItemType;
        int ItemNum = m_nowSelectedItem.ItemNum;

        switch(itemType)
        {
            case ItemType.MASK:
                {
                    if(m_IsOnEquipMask == false)
                    {
                        m_IsOnEquipMask = true;
                        m_MaskEquipMent.sprite = m_nowSelectedItem.GetComponent<Image>().sprite;
                        RemoveItem(m_nowSelectedItem);
                        Destroy(m_nowSelectedItem.gameObject);
                        m_AvatarMask.SetActive(true);

                        PlayerPrefs.SetInt("head", 1);
                    }
                    else
                    {

                    }
                }
                break;
            case ItemType.CLOTH:
                {
                    if (m_IsOnEquipCloth == false)
                    {
                        m_IsOnEquipCloth = true;
                        m_ClothEquipMent.sprite = m_nowSelectedItem.GetComponent<Image>().sprite;
                        RemoveItem(m_nowSelectedItem);
                        Destroy(m_nowSelectedItem.gameObject);
                        m_AvatarCloth.SetActive(true);


                        PlayerPrefs.SetInt("cloth", 1);
                    }
                    else
                    {

                    }
                }
                break;
            case ItemType.WEAPON:
                {
                    if (m_IsOnEquipLeftWeapon == false)
                    {
                        m_IsOnEquipLeftWeapon = true;
                        m_LeftWeaponEquipMent.sprite = m_nowSelectedItem.GetComponent<Image>().sprite;
                        RemoveItem(m_nowSelectedItem);
                        Destroy(m_nowSelectedItem.gameObject);
                        m_AvatarLeftWeapon.SetActive(true);


                        PlayerPrefs.SetInt("left", 1);
                    }
                    else
                    {
                        if (m_IsOnEquipRightWeapon == false)
                        {
                            m_IsOnEquipRightWeapon = true;
                            m_RightWeaponEquipMent.sprite = m_nowSelectedItem.GetComponent<Image>().sprite;
                            RemoveItem(m_nowSelectedItem);
                            Destroy(m_nowSelectedItem.gameObject);
                            m_AvatarRightWeapon.SetActive(true);


                            PlayerPrefs.SetInt("right", 1);
                        }
                        else
                        {

                        }
                    }
                }
                break;
            case ItemType.SHOES:
                {
                    if (!m_IsOnEquipShoesEquip)
                    {
                        m_IsOnEquipShoesEquip = true;
                        m_ShoesEquipMent.sprite = m_nowSelectedItem.GetComponent<Image>().sprite;
                        RemoveItem(m_nowSelectedItem);
                        Destroy(m_nowSelectedItem.gameObject);
                        m_AvatarShoes.SetActive(true);


                        PlayerPrefs.SetInt("shoes", 1);
                    }
                    else
                    {

                    }
                }
                break;
        }
    }
}
