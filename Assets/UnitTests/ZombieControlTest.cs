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
        // �׽�Ʈ ȯ�� ����: ZombieControl ������Ʈ�� ���� ���� ������Ʈ ����
        zombieGameObject = new GameObject();
        zombieControl = zombieGameObject.AddComponent<ZombieControl>();

        // die_effect�� ���� ���� ���� ������Ʈ ���� �� �Ҵ�
        dieEffectGameObject = new GameObject("DieEffect");
        zombieControl.die_effect = dieEffectGameObject;

        // �ʿ��� �ʱ�ȭ ����
        zombieControl.m_life = 100f; // ����: ������� 100���� ����
    }

    [TearDown]
    public void Teardown()
    {
        // �׽�Ʈ �� ����: ������ ���� ������Ʈ ����
        Object.DestroyImmediate(zombieGameObject);
        Object.DestroyImmediate(dieEffectGameObject);
    }

    [Test]
    public void Damaged_LifeIsReducedByAttackPower()
    {
        // Act: ���ݷ��� �����Ͽ� Damaged �޼ҵ� ����
        zombieControl.Damaged(10f); // ���ݷ� 10 ����

        // Assert: ������� ���ݷ¸�ŭ �����ߴ��� ����
        Assert.AreEqual(90f, zombieControl.m_life);
    }
}
