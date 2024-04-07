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
        // 새 게임 오브젝트 생성 및 GamesManager 컴포넌트 추가
        gameManagerObj = new GameObject();
        gameManager = gameManagerObj.AddComponent<GamesManager>();

        // 필요한 Mock 데이터 설정
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

        // MainData 초기화 (실제 클래스에 따라 다름)
        MainData.cur_Stage = 1;
        MainData.m_coin = 100;
        MainData.m_baselife = 100;
        MainData.m_maxlife = 100;
        MainData.max_enemy = 5;
        MainData.music_vol = 0.5f;
        MainData.sfx_vol = 0.5f;

        // 필요한 경우 MainData를 Mock 클래스로 대체할 수 있음
    }

    [TearDown]
    public void Teardown()
    {
        // 생성된 게임 오브젝트 제거
        Object.DestroyImmediate(gameManagerObj);
    }

    [UnityTest]
    public IEnumerator Game_Rule_ChangesStateToSpawnInitially()
    {
        yield return null; // 한 프레임 대기
        gameManager.Game_Rule();
        Assert.AreEqual(GameState.Spawn, gameManager.g_state);
    }

    // 다른 테스트 케이스를 작성
    // 예: Make_Enemy, On_Pause, On_Resume 등의 메서드 테스트
}
