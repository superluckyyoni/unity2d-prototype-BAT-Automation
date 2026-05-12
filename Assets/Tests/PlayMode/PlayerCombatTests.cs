using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerCombatTests
{
    private GameObject _player;
    private Actor _actor;
    private Thrower _thrower;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        yield return SceneManager.LoadSceneAsync("SampleLevel");
        yield return null;
        _player = GameObject.FindWithTag("Player");
        _actor = _player.GetComponent<Actor>();
        _thrower = _player.GetComponent<Thrower>();
    }

    // ── 공격 ──────────────────────────────────────

    [UnityTest]
    public IEnumerator FT_CMB_001_PlayerHasActorComponent()
    {
        // Actor 컴포넌트가 플레이어에 존재하는지 확인
        Assert.IsNotNull(_actor, "Actor 컴포넌트가 Player에 없습니다.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator FT_CMB_002_PlayerHasThrowerComponent()
    {
        // Thrower 컴포넌트가 플레이어에 존재하는지 확인
        Assert.IsNotNull(_thrower, "Thrower 컴포넌트가 Player에 없습니다.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator FT_CMB_003_PlayerInitialHealth()
    {
        // 플레이어 초기 HP가 0보다 큰지 확인
        Assert.Greater(_actor.Health, 0,
            "플레이어 초기 HP가 0보다 커야 합니다.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator FT_CMB_004_ThrowProjectile()
    {
        // ThrowProjectile() 호출 시 투사체가 씬에 생성되는지 확인
        int before = GameObject.FindObjectsOfType<GameObject>().Length;
        _thrower.ThrowProjectile();
        yield return new WaitForFixedUpdate();
        int after = GameObject.FindObjectsOfType<GameObject>().Length;
        Assert.Greater(after, before,
            "투사체가 씬에 생성되어야 합니다.");
    }

    [UnityTest]
    public IEnumerator FT_CMB_005_PlayerTakesDamage()
    {
        // 피격 시 HP가 감소하는지 확인
        int beforeHealth = _actor.Health;

        // Damage 태그를 가진 오브젝트로 충돌 시뮬레이션
        GameObject damageObj = new GameObject("DamageObject");
        damageObj.tag = "Damage";
        BoxCollider2D col = damageObj.AddComponent<BoxCollider2D>();
        col.isTrigger = true;
        damageObj.transform.position = _player.transform.position;

        // 무적시간(0.5f) + 여유 대기
        yield return new WaitForSeconds(_actor.DamageInvincibilitySeconds + 0.2f);

        Assert.Less(_actor.Health, beforeHealth,
            "피격 후 HP가 감소해야 합니다.");

        Object.Destroy(damageObj);
    }

    [UnityTest]
    public IEnumerator FT_CMB_006_PlayerDiesAtZeroHealth()
    {
        // HP가 0 이하가 되면 오브젝트가 비활성화 또는 제거되는지 확인
        // Actor.Damage()는 Health--후 Health<=0이면 Explode() 호출
        _actor.Health = 1;

        GameObject damageObj = new GameObject("DamageObject");
        damageObj.tag = "Damage";
        BoxCollider2D col = damageObj.AddComponent<BoxCollider2D>();
        col.isTrigger = true;
        damageObj.transform.position = _player.transform.position;

        yield return new WaitForSeconds(1f);

        // 사망 후 플레이어가 씬에서 제거되거나 비활성화됨
        Assert.IsTrue(
            _player == null || !_player.activeSelf,
            "HP 0 이하 시 플레이어가 제거되거나 비활성화되어야 합니다.");

        if (damageObj != null) Object.Destroy(damageObj);
    }

    [UnityTest]
    public IEnumerator FT_CMB_007_InvincibilityAfterDamage()
    {
        // 피격 후 무적시간 동안 HP가 추가 감소하지 않는지 확인
        int beforeHealth = _actor.Health;

        GameObject damageObj = new GameObject("DamageObject");
        damageObj.tag = "Damage";
        BoxCollider2D col = damageObj.AddComponent<BoxCollider2D>();
        col.isTrigger = true;
        damageObj.transform.position = _player.transform.position;

        // 첫 피격 발생 대기
        yield return new WaitForSeconds(0.1f);
        int afterFirstHit = _actor.Health;

        // 무적시간 중간에 HP 추가 감소 없는지 확인
        yield return new WaitForSeconds(0.2f);
        Assert.AreEqual(afterFirstHit, _actor.Health,
            "무적시간 동안 HP가 추가 감소하면 안 됩니다.");

        Object.Destroy(damageObj);
    }
}
