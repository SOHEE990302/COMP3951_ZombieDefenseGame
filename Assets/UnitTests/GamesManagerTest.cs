using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using System;

public class GamesManagerTests
{
    private GamesManager gameManager;
    private GameObject gameManagerObj;

    [SetUp]
    public void Setup()
    {
        // Create a new GameObject and add GamesManager component
        gameManagerObj = new GameObject();
        gameManager = gameManagerObj.AddComponent<GamesManager>();

        // Set up necessary Mock data
        gameManager.spawnPoint = new GameObject().transform;
        gameManager.zombie = new GameObject().transform;
        gameManager.hit_effect = new GameObject().transform;
        gameManager.UI_fail = new GameObject();
        gameManager.UI_Clear = new GameObject();
        gameManager.txt_StageNum = new GameObject().AddComponent<UnityEngine.UI.Text>();
        gameManager.txt_Coins = new GameObject().AddComponent<UnityEngine.UI.Text>();
        gameManager.Base_energy = new GameObject().AddComponent<Slider>();
        gameManager.music_vols = new GameObject().AddComponent<Slider>();
        gameManager.sfx_vols = new GameObject().AddComponent<Slider>();

        // Initialize MainData (varies according to the actual class)
        MainData.cur_Stage = 1;
        MainData.m_coin = 100;
        MainData.m_baselife = 100;
        MainData.m_maxlife = 100;
        MainData.max_enemy = 5;
        MainData.music_vol = 0.5f;
        MainData.sfx_vol = 0.5f;

        // If necessary, MainData can be replaced with a Mock class
    }

    [TearDown]
    public void Teardown()
    {
        // Destroy the created GameObject
        UnityEngine.Object.DestroyImmediate(gameManagerObj);
    }

    [UnityTest]
    public IEnumerator Game_Rule_ChangesStateToSpawnInitially()
    {
        yield return null; // Wait for one frame
        gameManager.Game_Rule();
        Assert.AreEqual(GameState.Spawn, gameManager.g_state);
    }
}
