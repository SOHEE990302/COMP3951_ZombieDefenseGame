using NUnit.Framework;
using UnityEngine;

public class ZombieControlTests
{
    private GameObject zombieGameObject;
    private ZombieControl zombieControl;
    private GameObject dieEffectGameObject;

    [SetUp]
    public void SetUp()
    {
        // 테스트 환경 설정: ZombieControl 컴포넌트를 가진 게임 오브젝트 생성
        zombieGameObject = new GameObject();
        zombieControl = zombieGameObject.AddComponent<ZombieControl>();

        // die_effect에 대한 모의 게임 오브젝트 생성 및 할당
        dieEffectGameObject = new GameObject("DieEffect");
        zombieControl.die_effect = dieEffectGameObject;

        // 필요한 초기화 진행
        zombieControl.m_life = 100f; // 예시: 생명력을 100으로 설정
    }

    [TearDown]
    public void Teardown()
    {
        // 테스트 후 정리: 생성된 게임 오브젝트 제거
        Object.DestroyImmediate(zombieGameObject);
        Object.DestroyImmediate(dieEffectGameObject);
    }

    [Test]
    public void Damaged_LifeIsReducedByAttackPower()
    {
        // Act: 공격력을 적용하여 Damaged 메소드 실행
        zombieControl.Damaged(10f); // 공격력 10 적용

        // Assert: 생명력이 공격력만큼 감소했는지 검증
        Assert.AreEqual(90f, zombieControl.m_life);
    }
}
