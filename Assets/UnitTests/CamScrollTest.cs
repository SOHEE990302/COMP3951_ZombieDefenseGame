using NUnit.Framework;
using UnityEngine;

public class CamScrollTests
{
    private GameObject cameraGameObject;
    private Camera camera;
    private CamScroll camScroll;

    // 테스트 시작 전 실행
    [SetUp]
    public void SetUp()
    {
        // 새 카메라 게임 오브젝트와 CamScroll 컴포넌트 생성
        cameraGameObject = new GameObject("Camera");
        camera = cameraGameObject.AddComponent<Camera>();
        camScroll = cameraGameObject.AddComponent<CamScroll>();
        camScroll.mycam = camera;
    }

    // 테스트 종료 후 실행
    [TearDown]
    public void TearDown()
    {
        // 생성된 게임 오브젝트 제거
        Object.DestroyImmediate(cameraGameObject);
    }

    // 스크롤 방향 테스트 - 왼쪽
    [Test]
    public void ScrollDirectionLeft()
    {
        // Act
        camScroll.Btn_Scroll_L();

        // Assert
        Assert.AreEqual(-1, camScroll.dir_x);
    }

    // 스크롤 방향 테스트 - 오른쪽
    [Test]
    public void ScrollDirectionRight()
    {
        // Act
        camScroll.Btn_Scroll_R();

        // Assert
        Assert.AreEqual(1, camScroll.dir_x);
    }

    // 스크롤 방향 테스트 - 위쪽(정지)
    [Test]
    public void ScrollDirectionUp()
    {
        // Act
        camScroll.Btn_Scroll_Up();

        // Assert
        Assert.AreEqual(0, camScroll.dir_x);
    }

    // 카메라 스크롤 테스트 - 이동 제한
    [Test]
    public void CameraScrollsWithinLimits()
    {
        // Arrange
        camScroll.speed = 100f; // 테스트를 위해 속도를 높임
        camScroll.dir_x = 1; // 오른쪽으로 이동 설정

        // Act
        camScroll.Scroll_Cam(); // 여러 번 호출해도
        camScroll.Scroll_Cam();
        camScroll.Scroll_Cam();

        // Assert
        Assert.IsTrue(camScroll.mycam.transform.position.x <= 30f);
        // 최대한으로 이동해도 x 위치는 30을 넘지 않아야 함
    }
}
