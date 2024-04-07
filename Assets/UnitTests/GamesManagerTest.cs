using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamesManagerTests
{
    private GamesManager gameManager;
    private GameObject gameManagerObj;

    [SetUp]
    public void Setup()
    {
        // �� ���� ������Ʈ ���� �� GamesManager ������Ʈ �߰�
        gameManagerObj = new GameObject();
        gameManager = gameManagerObj.AddComponent<GamesManager>();

        // �ʿ��� Mock ������ ����
        gameManager.spawnPoint = new GameObject().transform;
        gameManager.zombie = new GameObject().transform;
        gameManager.hit_effect = new GameObject().transform;
        gameManager.UI_fail = new GameObject();
        gameManager.UI_Clear = new GameObject();
        gameManager.txt_StageNum = new GameObject().AddComponent<Text>();
        gameManager.txt_Coins = new GameObject().AddComponent<Text>();
        gameManager.Base_energy = new GameObject().AddComponent<Slider>();
        gameManager.music_vols = new GameObject().AddComponent<Slider>();
        gameManager.sfx_vols = new GameObject().AddComponent<Slider>();

        // MainData �ʱ�ȭ (���� Ŭ������ ���� �ٸ�)
        MainData.cur_Stage = 1;
        MainData.m_coin = 100;
        MainData.m_baselife = 100;
        MainData.m_maxlife = 100;
        MainData.max_enemy = 5;
        MainData.music_vol = 0.5f;
        MainData.sfx_vol = 0.5f;

        // �ʿ��� ��� MainData�� Mock Ŭ������ ��ü�� �� ����
    }

    [TearDown]
    public void Teardown()
    {
        // ������ ���� ������Ʈ ����
        Object.DestroyImmediate(gameManagerObj);
    }

    [UnityTest]
    public IEnumerator Game_Rule_ChangesStateToSpawnInitially()
    {
        yield return null; // �� ������ ���
        gameManager.Game_Rule();
        Assert.AreEqual(GameState.Spawn, gameManager.g_state);
    }

    // �ٸ� �׽�Ʈ ���̽��� �ۼ�
    // ��: Make_Enemy, On_Pause, On_Resume ���� �޼��� �׽�Ʈ
}
