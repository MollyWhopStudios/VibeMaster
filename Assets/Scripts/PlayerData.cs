using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Text;


[DataContract]
public class PlayerData
{
    // Player Data
    [DataMember]
    public float click;
    [DataMember]
    public float clickTotal;
    [DataMember]
    public int clickMultiplier;
    [DataMember]
    public float critChance;
    [DataMember]
    public int critMultiplier;
    [DataMember]
    public int passiveDamage;

    // Player Data of enemy level
    // saves and loads to file
    [DataMember]
    public int enemyLevel;
    public int GetLevel() { return enemyLevel; }
    public void SetLevel(int level) { this.enemyLevel = level; }

    public PlayerData()
    {
        ResetData();
    }

    // Shop Values
    public enum Upgrades { click, crit, passive };

    private int shopUpgradeMaxLevel = 4; // size of value array
    public int scaleLevel           = 5; // num of cycles before scale to new level
    private int[] shopUpgradeLevel = { 0, 0, 0 };
    private int[] upgradeScaleCounter = { 0, 0, 0 };

    public void ResetData()
    {
        click = 0;
        clickTotal = 0;
        clickMultiplier = 1;
        critChance = 1f;
        critMultiplier = 3;
        passiveDamage = 0;
        enemyLevel = 1;
    }

    public int GetUpgradeTier(int upgrade) { return shopUpgradeLevel[upgrade]; }

    public int[] clickUpgradeCost    = { 10, 1000, 1000, 10000, 100000 };
    public int[] clickUpgradeValue   = { 1, 10, 100, 1000, 10000 };
    public int[] critUpgradeCost     = { 10, 1000, 1000, 10000, 100000 };
    public float[] critUpgradeValue  = { 0.5f, 1.0f, 5.0f, 7.5f, 10.0f };
    public int[] passiveUpgradeCost  = { 100, 1000, 10000, 100000, 10000000 };
    public int[] passiveUpgradeValue = { 3, 30, 100, 500, 10000 };

    public int GetUpgradeCost(int upgrade)
    {
        switch (upgrade)
        {
            case 0: return clickUpgradeCost[shopUpgradeLevel[(int)Upgrades.click]];
            case 1: return critUpgradeCost[shopUpgradeLevel[(int)Upgrades.crit]];
            case 2: return passiveUpgradeCost[shopUpgradeLevel[(int)Upgrades.passive]];
            default: return -1;
        }
    }

    private void UseUpgrade(int upgrade)
    {
        if (upgradeScaleCounter[upgrade] < scaleLevel)
        {
            upgradeScaleCounter[upgrade]++;
        }
        else
        {
            upgradeScaleCounter[upgrade] = 0;
            if (shopUpgradeLevel[upgrade] < shopUpgradeMaxLevel)
            {
                shopUpgradeLevel[upgrade]++;
            }
        }
    }

    public void ClickUpgrade()
    {
        int cost = clickUpgradeCost[shopUpgradeLevel[(int)Upgrades.click]];
        if (click >= cost)
        {
            click = click - cost;
            clickMultiplier = clickMultiplier + clickUpgradeValue[shopUpgradeLevel[(int)Upgrades.click]];
            UseUpgrade((int)Upgrades.click);
        }
    }

    public void CritUpgrade()
    {
        int cost = critUpgradeCost[shopUpgradeLevel[(int)Upgrades.crit]];
        if (click >= cost && critChance < 100)
        {
            click = click - cost;
            critChance = critChance + critUpgradeValue[shopUpgradeLevel[(int)Upgrades.crit]];
            UseUpgrade((int)Upgrades.crit);
        }
    }

    public void PassiveUpgrade()
    {
        int cost = passiveUpgradeCost[shopUpgradeLevel[(int)Upgrades.passive]];
        if (click >= cost)
        {
            click = click - cost;
            // TODO: add passive clicks
            passiveDamage = passiveDamage + passiveUpgradeValue[shopUpgradeLevel[(int)Upgrades.passive]];
            UseUpgrade((int)Upgrades.passive);
        }
    }

    public void Save()
    {

        // Stream the file with a File Stream. (Note that File.Create() 'Creates' or 'Overwrites' a file.)
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerData.dat");
        // Create a new Player_Data.
        PlayerData data = new PlayerData();
        //Save the data.
        data.click = click;
        data.clickTotal = clickTotal;
        data.clickMultiplier = clickMultiplier;
        data.critChance = critChance;
        data.critMultiplier = critMultiplier;
        data.passiveDamage = passiveDamage;

        data.enemyLevel = enemyLevel;


        //Serialize to xml
        DataContractSerializer bf = new DataContractSerializer(data.GetType());
        MemoryStream streamer = new MemoryStream();

        //Serialize the file
        bf.WriteObject(streamer, data);
        streamer.Seek(0, SeekOrigin.Begin);

        //Save to disk
        file.Write(streamer.GetBuffer(), 0, streamer.GetBuffer().Length);

        // Close the file to prevent any corruptions
        file.Close();

        string result = XElement.Parse(Encoding.ASCII.GetString(streamer.GetBuffer()).Replace("\0", "")).ToString();
        Debug.Log("Serialized Result: " + result);
    }

    public void Load()
    {
        string fileName = Application.persistentDataPath + "/playerData.dat";

        Debug.Log("Deserializing an instance of the object.");

        FileStream fs = new FileStream(fileName, FileMode.Open);
        XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
        DataContractSerializer ser = new DataContractSerializer(typeof(PlayerData));

        // Deserialize the data and read it from the instance.
        PlayerData newData = (PlayerData)ser.ReadObject(reader, true);

        reader.Close();
        fs.Close();

        // Load
        click = newData.click;
        clickTotal = newData.clickTotal;
        clickMultiplier = newData.clickMultiplier;
        critChance = newData.critChance;
        critMultiplier = newData.critMultiplier;
        passiveDamage = newData.passiveDamage;

        enemyLevel = newData.enemyLevel;
    }
}
