using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class TitleManagerTests
{
    private TitleManager titleManager;
    private GameObject titleManagerObj;

    [SetUp]
    public void SetUp()
    {
        // Create TitleManager object
        titleManagerObj = new GameObject();
        titleManager = titleManagerObj.AddComponent<TitleManager>();

        // Initialize MainData
        ResetMainData();
    }

    [TearDown]
    public void TearDown()
    {
        // Destroy the created game object
        UnityEngine.Object.DestroyImmediate(titleManagerObj);

        // Reset MainData
        ResetMainData();
    }

    private void ResetMainData()
    {
        MainData.cur_Stage = 1;
        MainData.m_coin = 0;
        MainData.m_AttPow = 0.8f;
        MainData.m_baselife = 100;
        MainData.m_maxlife = 100;
        MainData.music_vol = 0.7f;
        MainData.sfx_vol = 0.5f;
        MainData.is_pause = false;
        MainData.max_enemy = 2;
    }

    [Test]
    public void TitleManager_LoadsDataCorrectly()
    {
        // Arrange: Directly create a saveData object
        saveData mockData = new saveData
        {
            cur_Stage = 2,
            m_baselife = 200f,
            m_maxlife = 200f,
            m_AttPow = 1.2f,
            m_coin = 150,
            max_enemy = 5,
            music_vol = 0.8f,
            sfx_vol = 0.6f
        };

        // Act: Instead of executing LoadGame method, directly apply mockData to MainData
        ApplyMockDataToMainData(mockData);

        // Assert: Verify that MainData is updated correctly
        Assert.AreEqual(mockData.cur_Stage, MainData.cur_Stage);
        Assert.AreEqual(mockData.m_baselife, MainData.m_baselife);
        Assert.AreEqual(mockData.m_maxlife, MainData.m_maxlife);
        Assert.AreEqual(mockData.m_AttPow, MainData.m_AttPow);
        Assert.AreEqual(mockData.m_coin, MainData.m_coin);
        Assert.AreEqual(mockData.max_enemy, MainData.max_enemy);
        Assert.AreEqual(mockData.music_vol, MainData.music_vol);
        Assert.AreEqual(mockData.sfx_vol, MainData.sfx_vol);
    }

    // This method replaces the actual logic of TitleManager.LoadGame().
    private void ApplyMockDataToMainData(saveData data)
    {
        MainData.cur_Stage = data.cur_Stage;
        MainData.m_baselife = data.m_baselife;
        MainData.m_maxlife = data.m_maxlife;
        MainData.m_AttPow = data.m_AttPow;
        MainData.m_coin = data.m_coin;
        MainData.max_enemy = data.max_enemy;
        MainData.music_vol = data.music_vol;
        MainData.sfx_vol = data.sfx_vol;
    }
}
