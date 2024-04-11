using NUnit.Framework;
using System;
using UnityEngine;

public class CamScrollTests
{
    private GameObject cameraGameObject;
    private Camera camera;
    private CamScroll camScroll;

    // Execute before starting tests
    [SetUp]
    public void SetUp()
    {
        // Create a new camera game object and CamScroll component
        cameraGameObject = new GameObject("Camera");
        camera = cameraGameObject.AddComponent<Camera>();
        camScroll = cameraGameObject.AddComponent<CamScroll>();
        camScroll.mycam = camera;
    }

    // Execute after tests are complete
    [TearDown]
    public void TearDown()
    {
        // Destroy the created game object
        UnityEngine.Object.DestroyImmediate(cameraGameObject);
    }

    // Test scroll direction - Left
    [Test]
    public void ScrollDirectionLeft()
    {
        // Act
        camScroll.Btn_Scroll_L();

        // Assert
        Assert.AreEqual(-1, camScroll.dir_x);
    }

    // Test scroll direction - Right
    [Test]
    public void ScrollDirectionRight()
    {
        // Act
        camScroll.Btn_Scroll_R();

        // Assert
        Assert.AreEqual(1, camScroll.dir_x);
    }

    // Test scroll direction - Up (Stop)
    [Test]
    public void ScrollDirectionUp()
    {
        // Act
        camScroll.Btn_Scroll_Up();

        // Assert
        Assert.AreEqual(0, camScroll.dir_x);
    }

    // Camera scroll test - Movement limit
    [Test]
    public void CameraScrollsWithinLimits()
    {
        // Arrange
        camScroll.speed = 100f; // Increase speed for testing
        camScroll.dir_x = 1; // Set to move right

        // Act
        camScroll.Scroll_Cam(); // Even if called multiple times
        camScroll.Scroll_Cam();
        camScroll.Scroll_Cam();

        // Assert
        Assert.IsTrue(camScroll.mycam.transform.position.x <= 30f);
        // Even at maximum movement, the x position should not exceed 30
    }
}
