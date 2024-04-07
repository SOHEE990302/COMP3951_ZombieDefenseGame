using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class BaseControlTests
{
    private GameObject gameObject;
    private Base_Control baseControl;

    [SetUp]
    public void SetUp()
    {
        gameObject = new GameObject();
        baseControl = gameObject.AddComponent<Base_Control>();
        baseControl.base_life = new GameObject().AddComponent<Text>();
        baseControl.blood_canvas = new GameObject();
        baseControl.blood_canvas.SetActive(false); // 초기 상태를 비활성화로 설정

        // MainData 및 Base_Control 초기화
        MainData.m_baselife = 100f;
        baseControl.mylife = MainData.m_baselife;
    }

    [TearDown]
    public void Teardown()
    {
        // 테스트 후 정리
        Object.DestroyImmediate(gameObject);
    }

    [Test]
    public void Damaged_ReduceLifeAndActivateBloodCanvas()
    {
        // 공격력 설정
        float attackPower = 10f;

        // Damaged 메소드 실행
        baseControl.Damaged(attackPower);

        // mylife 감소 검증
        Assert.AreEqual(90f, baseControl.mylife);
        // MainData.m_baselife 감소 검증
        Assert.AreEqual(90f, MainData.m_baselife);
        // blood_canvas 활성화 검증
        Assert.IsTrue(baseControl.blood_canvas.activeSelf);

        // resume_blood의 호출 효과를 직접 테스트할 수 없으므로 여기서 검증을 마칩니다.
        // 해당 로직은 실제 게임 동작 중에 시각적으로 확인해야 할 수 있습니다.
    }
}
