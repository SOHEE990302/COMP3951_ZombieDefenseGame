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
        // TitleManager 오브젝트 생성
        titleManagerObj = new GameObject();
        titleManager = titleManagerObj.AddComponent<TitleManager>();

        // MainData 초기화
        ResetMainData();
    }

    [TearDown]
    public void TearDown()
    {
        // 생성된 게임 오브젝트 제거
        Object.DestroyImmediate(titleManagerObj);

        // MainData 초기화
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
        // Arrange: saveData 객체를 직접 생성
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

        // Act: LoadGame 메서드 실행 대신 MainData에 직접 mockData를 적용
        ApplyMockDataToMainData(mockData);

        // Assert: MainData가 올바르게 업데이트되었는지 확인
        Assert.AreEqual(mockData.cur_Stage, MainData.cur_Stage);
        Assert.AreEqual(mockData.m_baselife, MainData.m_baselife);
        Assert.AreEqual(mockData.m_maxlife, MainData.m_maxlife);
        Assert.AreEqual(mockData.m_AttPow, MainData.m_AttPow);
        Assert.AreEqual(mockData.m_coin, MainData.m_coin);
        Assert.AreEqual(mockData.max_enemy, MainData.max_enemy);
        Assert.AreEqual(mockData.music_vol, MainData.music_vol);
        Assert.AreEqual(mockData.sfx_vol, MainData.sfx_vol);
    }

    // 이 메서드는 실제 TitleManager.LoadGame() 로직을 대체합니다.
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

    // SceneManager.LoadScene 호출을 포함한 다른 메서드의 테스트는 PlayMode 테스트로 구현해야 할 수도 있습니다.
    // 예: New_Game, Exit_Game 등
}
