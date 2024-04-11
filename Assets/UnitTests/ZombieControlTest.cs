using NUnit.Framework;
using System;
using UnityEngine;

public class ZombieControlTests
{
    private GameObject zombieGameObject;
    private ZombieControl zombieControl;
    private GameObject dieEffectGameObject;

    [SetUp]
    public void SetUp()
    {
        // Test setup: Create a GameObject with a ZombieControl component
        zombieGameObject = new GameObject();
        zombieControl = zombieGameObject.AddComponent<ZombieControl>();

        // Create and assign a mock GameObject for die_effect
        dieEffectGameObject = new GameObject("DieEffect");
        zombieControl.die_effect = dieEffectGameObject;

        // Proceed with necessary initialization
        zombieControl.m_life = 100f; // Example: Set life to 100
    }

    [TearDown]
    public void Teardown()
    {
        // Cleanup after test: Destroy the created GameObjects
        UnityEngine.Object.DestroyImmediate(zombieGameObject);
        UnityEngine.Object.DestroyImmediate(dieEffectGameObject);
    }

    [Test]
    public void Damaged_LifeIsReducedByAttackPower()
    {
        // Act: Execute the Damaged method applying attack power
        zombieControl.Damaged(10f); // Apply attack power of 10

        // Assert: Verify that life is reduced by the amount of attack power
        Assert.AreEqual(90f, zombieControl.m_life);
    }
}
