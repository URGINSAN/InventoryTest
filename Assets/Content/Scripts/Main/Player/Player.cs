using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

public class Player : MonoBehaviour
{
    [SerializeField] private string Filename = "PlayerInfo.xml";
    [SerializeField] private PlayerInfo playerInfo;
    public static Player instance;

    public delegate void LoadDateHandler();
    public event LoadDateHandler OnLoadData;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        GetDataFromXML();
    }

    void GetDataFromXML()
    {
        string filePath = $"{Application.streamingAssetsPath}/{Filename}";

        XDocument xmlDoc = XDocument.Load(filePath);
        XElement root = xmlDoc.Root;

        foreach (XElement itemElement in root.Elements("info"))
        {
            int _money = 0;

            playerInfo = new PlayerInfo();

            XElement moneyElement = itemElement.Element("money");
            if (moneyElement != null) _money = int.Parse(moneyElement.Value);

            playerInfo.SetInfo(_money);
        }

        OnLoadData?.Invoke();
    }

    public int GetPlayerMoney()
    {
        return playerInfo.money;
    }
}

[System.Serializable]
public struct PlayerInfo
{
    public int money;

    public void SetInfo(int _money)
    {
        money = _money;
    }
}
