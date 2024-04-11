using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;
using System;

public class MarketManagerTests
{
    private MarketManager marketManager;
    private GameObject marketManagerObj;

    [SetUp]
    public void SetUp()
    {
        // Create MarketManager object
        marketManagerObj = new GameObject();
        marketManager = marketManagerObj.AddComponent<MarketManager>();

        // Mock implementations of the dependent UI components
        marketManager.val_coin = new GameObject().AddComponent<UnityEngine.UI.Text>();
        marketManager.val_repair = new GameObject().AddComponent<UnityEngine.UI.Text>();
        marketManager.val_upgrade = new GameObject().AddComponent<UnityEngine.UI.Text>();
        marketManager.btn_Repair = new GameObject().AddComponent<Button>();
        marketManager.btn_Upgrade = new GameObject().AddComponent<Button>();

        // Initialize MainData
        MainData.m_coin = 1000;  // Assume the user has enough coins
        MainData.m_baselife = 50;  // Set base life
        MainData.m_AttPow = 1.0f;  // Set base attack power
    }

    [TearDown]
    public void Teardown()
    {
        // Destroy the created game object
        UnityEngine.Object.DestroyImmediate(marketManagerObj);
    }

    [Test]
    public void MarketManager_CanRepair()
    {
        // Set conditions before calling the method
        marketManager.repair = 500; // Set repair cost

        // Execute the repair method
        marketManager.go_Repair();

        // Assert
        Assert.AreEqual(100, MainData.m_baselife); // Check if the base life has been fully restored after repair
        Assert.AreEqual(500, MainData.m_coin); // Check if the coins were deducted by the repair cost
    }

    [Test]
    public void MarketManager_CanUpgrade()
    {
        // Set conditions before calling the method
        marketManager.upgrade = 800; // Set upgrade cost

        // Execute the upgrade method
        marketManager.go_Upgrade();

        // Assert
        Assert.AreEqual(1.3f, MainData.m_AttPow); // Check if the attack power has increased after upgrade
        Assert.AreEqual(200, MainData.m_coin); // Check if the coins were deducted by the upgrade cost
    }

    [Test]
    public void MarketManager_DisplaysCorrectValues()
    {
        // Calculate prices and update UI
        marketManager.Calculate_Cost();
        marketManager.Show_Market();

        // Assert
        Assert.AreEqual("1000", marketManager.val_coin.text); // Verify that the coin value is displayed correctly
        Assert.AreEqual("700", marketManager.val_repair.text); // Verify that the repair cost is displayed correctly
        Assert.AreEqual("1000", marketManager.val_upgrade.text); // Verify that the upgrade cost is displayed correctly
    }
}
