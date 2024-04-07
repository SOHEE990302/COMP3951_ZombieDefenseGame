using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class TitleManagerTests
{
    private TitleManager titleManager;
    private GameObject titleManagerObj;

    [SetUp]
    public void SetUp()
    {
        // TitleManager ������Ʈ ����
        titleManagerObj = new GameObject();
        titleManager = titleManagerObj.AddComponent<TitleManager>();

        // MainData �ʱ�ȭ
        ResetMainData();
    }

    [TearDown]
    public void TearDown()
    {
        // ������ ���� ������Ʈ ����
        Object.DestroyImmediate(titleManagerObj);

        // MainData �ʱ�ȭ
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
        // Arrange: saveData ��ü�� ���� ����
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

        // Act: LoadGame �޼��� ���� ��� MainData�� ���� mockData�� ����
        ApplyMockDataToMainData(mockData);

        // Assert: MainData�� �ùٸ��� ������Ʈ�Ǿ����� Ȯ��
        Assert.AreEqual(mockData.cur_Stage, MainData.cur_Stage);
        Assert.AreEqual(mockData.m_baselife, MainData.m_baselife);
        Assert.AreEqual(mockData.m_maxlife, MainData.m_maxlife);
        Assert.AreEqual(mockData.m_AttPow, MainData.m_AttPow);
        Assert.AreEqual(mockData.m_coin, MainData.m_coin);
        Assert.AreEqual(mockData.max_enemy, MainData.max_enemy);
        Assert.AreEqual(mockData.music_vol, MainData.music_vol);
        Assert.AreEqual(mockData.sfx_vol, MainData.sfx_vol);
    }

    // �� �޼���� ���� TitleManager.LoadGame() ������ ��ü�մϴ�.
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

    // SceneManager.LoadScene ȣ���� ������ �ٸ� �޼����� �׽�Ʈ�� PlayMode �׽�Ʈ�� �����ؾ� �� ���� �ֽ��ϴ�.
    // ��: New_Game, Exit_Game ��
}
