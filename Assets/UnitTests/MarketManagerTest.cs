using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using System.Collections;

public class MarketManagerTests
{
    private MarketManager marketManager;
    private GameObject marketManagerObj;

    [SetUp]
    public void SetUp()
    {
        // MarketManager 오브젝트 생성
        marketManagerObj = new GameObject();
        marketManager = marketManagerObj.AddComponent<MarketManager>();

        // 의존하는 UI 컴포넌트들의 모의 구현
        marketManager.val_coin = new GameObject().AddComponent<Text>();
        marketManager.val_repair = new GameObject().AddComponent<Text>();
        marketManager.val_upgrade = new GameObject().AddComponent<Text>();
        marketManager.btn_Repair = new GameObject().AddComponent<Button>();
        marketManager.btn_Upgrade = new GameObject().AddComponent<Button>();

        // MainData 초기화
        MainData.m_coin = 1000;  // 사용자가 충분한 동전을 가지고 있다고 가정
        MainData.m_baselife = 50;  // 기본 생명력 설정
        MainData.m_AttPow = 1.0f;  // 기본 공격력 설정
    }

    [TearDown]
    public void Teardown()
    {
        // 생성된 게임 오브젝트 제거
        Object.DestroyImmediate(marketManagerObj);
    }

    [Test]
    public void MarketManager_CanRepair()
    {
        // 메서드 호출 전에 조건 설정
        marketManager.repair = 500; // 수리 비용 설정

        // 수리 메서드 실행
        marketManager.go_Repair();

        // Assert
        Assert.AreEqual(100, MainData.m_baselife); // 수리 후 기본 생명력이 최대치로 복구되었는지 확인
        Assert.AreEqual(500, MainData.m_coin); // 수리 비용만큼 동전이 차감되었는지 확인
    }

    [Test]
    public void MarketManager_CanUpgrade()
    {
        // 메서드 호출 전에 조건 설정
        marketManager.upgrade = 800; // 업그레이드 비용 설정

        // 업그레이드 메서드 실행
        marketManager.go_Upgrade();

        // Assert
        Assert.AreEqual(1.3f, MainData.m_AttPow); // 업그레이드 후 공격력이 증가했는지 확인
        Assert.AreEqual(200, MainData.m_coin); // 업그레이드 비용만큼 동전이 차감되었는지 확인
    }

    [Test]
    public void MarketManager_DisplaysCorrectValues()
    {
        // 가격 계산 및 UI 업데이트
        marketManager.Calculate_Cost();
        marketManager.Show_Market();

        // Assert
        Assert.AreEqual("1000", marketManager.val_coin.text); // 코인 값이 올바르게 표시되는지 확인
        Assert.AreEqual("700", marketManager.val_repair.text); // 수리 비용이 올바르게 표시되는지 확인
        Assert.AreEqual("1000", marketManager.val_upgrade.text); // 업그레이드 비용이 올바르게 표시되는지 확인
    }
}

