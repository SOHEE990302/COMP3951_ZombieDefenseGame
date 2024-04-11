using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class BaseControlTests
{
    private GameObject gameObject;
    private Base_Control baseControl;

    [SetUp]
    public void SetUp()
    {
        gameObject = new GameObject();
        baseControl = gameObject.AddComponent<Base_Control>();
        baseControl.base_life = new GameObject().AddComponent<UnityEngine.UI.Text>();
        baseControl.blood_canvas = new GameObject();
        baseControl.blood_canvas.SetActive(false); // Set the initial state to inactive

        // Initialize MainData and Base_Control
        MainData.m_baselife = 100f;
        baseControl.mylife = MainData.m_baselife;
    }

    [TearDown]
    public void Teardown()
    {
        // Cleanup after tests
        UnityEngine.Object.DestroyImmediate(gameObject);
    }

    [Test]
    public void Damaged_ReduceLifeAndActivateBloodCanvas()
    {
        // Set attack power
        float attackPower = 10f;

        // Execute the Damaged method
        baseControl.Damaged(attackPower);

        // Verify mylife reduction
        Assert.AreEqual(90f, baseControl.mylife);
        // Verify MainData.m_baselife reduction
        Assert.AreEqual(90f, MainData.m_baselife);
        // Verify blood_canvas activation
        Assert.IsTrue(baseControl.blood_canvas.activeSelf);
    }
}
