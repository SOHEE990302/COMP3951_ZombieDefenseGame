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
        // MarketManager ������Ʈ ����
        marketManagerObj = new GameObject();
        marketManager = marketManagerObj.AddComponent<MarketManager>();

        // �����ϴ� UI ������Ʈ���� ���� ����
        marketManager.val_coin = new GameObject().AddComponent<Text>();
        marketManager.val_repair = new GameObject().AddComponent<Text>();
        marketManager.val_upgrade = new GameObject().AddComponent<Text>();
        marketManager.btn_Repair = new GameObject().AddComponent<Button>();
        marketManager.btn_Upgrade = new GameObject().AddComponent<Button>();

        // MainData �ʱ�ȭ
        MainData.m_coin = 1000;  // ����ڰ� ����� ������ ������ �ִٰ� ����
        MainData.m_baselife = 50;  // �⺻ ����� ����
        MainData.m_AttPow = 1.0f;  // �⺻ ���ݷ� ����
    }

    [TearDown]
    public void Teardown()
    {
        // ������ ���� ������Ʈ ����
        Object.DestroyImmediate(marketManagerObj);
    }

    [Test]
    public void MarketManager_CanRepair()
    {
        // �޼��� ȣ�� ���� ���� ����
        marketManager.repair = 500; // ���� ��� ����

        // ���� �޼��� ����
        marketManager.go_Repair();

        // Assert
        Assert.AreEqual(100, MainData.m_baselife); // ���� �� �⺻ ������� �ִ�ġ�� �����Ǿ����� Ȯ��
        Assert.AreEqual(500, MainData.m_coin); // ���� ��븸ŭ ������ �����Ǿ����� Ȯ��
    }

    [Test]
    public void MarketManager_CanUpgrade()
    {
        // �޼��� ȣ�� ���� ���� ����
        marketManager.upgrade = 800; // ���׷��̵� ��� ����

        // ���׷��̵� �޼��� ����
        marketManager.go_Upgrade();

        // Assert
        Assert.AreEqual(1.3f, MainData.m_AttPow); // ���׷��̵� �� ���ݷ��� �����ߴ��� Ȯ��
        Assert.AreEqual(200, MainData.m_coin); // ���׷��̵� ��븸ŭ ������ �����Ǿ����� Ȯ��
    }

    [Test]
    public void MarketManager_DisplaysCorrectValues()
    {
        // ���� ��� �� UI ������Ʈ
        marketManager.Calculate_Cost();
        marketManager.Show_Market();

        // Assert
        Assert.AreEqual("1000", marketManager.val_coin.text); // ���� ���� �ùٸ��� ǥ�õǴ��� Ȯ��
        Assert.AreEqual("700", marketManager.val_repair.text); // ���� ����� �ùٸ��� ǥ�õǴ��� Ȯ��
        Assert.AreEqual("1000", marketManager.val_upgrade.text); // ���׷��̵� ����� �ùٸ��� ǥ�õǴ��� Ȯ��
    }
}

