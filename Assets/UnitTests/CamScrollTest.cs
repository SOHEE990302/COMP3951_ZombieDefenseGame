using NUnit.Framework;
using UnityEngine;

public class CamScrollTests
{
    private GameObject cameraGameObject;
    private Camera camera;
    private CamScroll camScroll;

    // �׽�Ʈ ���� �� ����
    [SetUp]
    public void SetUp()
    {
        // �� ī�޶� ���� ������Ʈ�� CamScroll ������Ʈ ����
        cameraGameObject = new GameObject("Camera");
        camera = cameraGameObject.AddComponent<Camera>();
        camScroll = cameraGameObject.AddComponent<CamScroll>();
        camScroll.mycam = camera;
    }

    // �׽�Ʈ ���� �� ����
    [TearDown]
    public void TearDown()
    {
        // ������ ���� ������Ʈ ����
        Object.DestroyImmediate(cameraGameObject);
    }

    // ��ũ�� ���� �׽�Ʈ - ����
    [Test]
    public void ScrollDirectionLeft()
    {
        // Act
        camScroll.Btn_Scroll_L();

        // Assert
        Assert.AreEqual(-1, camScroll.dir_x);
    }

    // ��ũ�� ���� �׽�Ʈ - ������
    [Test]
    public void ScrollDirectionRight()
    {
        // Act
        camScroll.Btn_Scroll_R();

        // Assert
        Assert.AreEqual(1, camScroll.dir_x);
    }

    // ��ũ�� ���� �׽�Ʈ - ����(����)
    [Test]
    public void ScrollDirectionUp()
    {
        // Act
        camScroll.Btn_Scroll_Up();

        // Assert
        Assert.AreEqual(0, camScroll.dir_x);
    }

    // ī�޶� ��ũ�� �׽�Ʈ - �̵� ����
    [Test]
    public void CameraScrollsWithinLimits()
    {
        // Arrange
        camScroll.speed = 100f; // �׽�Ʈ�� ���� �ӵ��� ����
        camScroll.dir_x = 1; // ���������� �̵� ����

        // Act
        camScroll.Scroll_Cam(); // ���� �� ȣ���ص�
        camScroll.Scroll_Cam();
        camScroll.Scroll_Cam();

        // Assert
        Assert.IsTrue(camScroll.mycam.transform.position.x <= 30f);
        // �ִ������� �̵��ص� x ��ġ�� 30�� ���� �ʾƾ� ��
    }
}
