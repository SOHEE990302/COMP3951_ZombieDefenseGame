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
        baseControl.blood_canvas.SetActive(false); // �ʱ� ���¸� ��Ȱ��ȭ�� ����

        // MainData �� Base_Control �ʱ�ȭ
        MainData.m_baselife = 100f;
        baseControl.mylife = MainData.m_baselife;
    }

    [TearDown]
    public void Teardown()
    {
        // �׽�Ʈ �� ����
        Object.DestroyImmediate(gameObject);
    }

    [Test]
    public void Damaged_ReduceLifeAndActivateBloodCanvas()
    {
        // ���ݷ� ����
        float attackPower = 10f;

        // Damaged �޼ҵ� ����
        baseControl.Damaged(attackPower);

        // mylife ���� ����
        Assert.AreEqual(90f, baseControl.mylife);
        // MainData.m_baselife ���� ����
        Assert.AreEqual(90f, MainData.m_baselife);
        // blood_canvas Ȱ��ȭ ����
        Assert.IsTrue(baseControl.blood_canvas.activeSelf);

        // resume_blood�� ȣ�� ȿ���� ���� �׽�Ʈ�� �� �����Ƿ� ���⼭ ������ ��Ĩ�ϴ�.
        // �ش� ������ ���� ���� ���� �߿� �ð������� Ȯ���ؾ� �� �� �ֽ��ϴ�.
    }
}
