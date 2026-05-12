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

    [UnityTest]
    public IEnumerator FT_CMB_001_PlayerHasActorComponent()
    {
        Assert.IsNotNull(_actor, "Actor component is missing on Player.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator FT_CMB_002_PlayerHasThrowerComponent()
    {
        Assert.IsNotNull(_thrower, "Thrower component is missing on Player.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator FT_CMB_003_PlayerInitialHealth()
    {
        Assert.Greater(_actor.Health, 0,
            "Player initial health should be greater than 0.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator FT_CMB_004_ThrowProjectile()
    {
        int before = Object.FindObjectsOfType<GameObject>().Length;
        _thrower.ThrowProjectile();
        yield return new WaitForFixedUpdate();
        int after = Object.FindObjectsOfType<GameObject>().Length;
        Assert.Greater(after, before,
            "Projectile should be instantiated in scene.");
    }

    [UnityTest]
    public IEnumerator FT_CMB_005_PlayerTakesDamage()
    {
        int beforeHealth = _actor.Health;
        GameObject damageObj = new GameObject("DamageObject");
        damageObj.tag = "Damage";
        BoxCollider2D col = damageObj.AddComponent<BoxCollider2D>();
        col.isTrigger = true;
        damageObj.transform.position = _player.transform.position;
        yield return new WaitForSeconds(_actor.DamageInvincibilitySeconds + 0.2f);
        Assert.Less(_actor.Health, beforeHealth,
            "Player health should decrease after taking damage.");
        Object.Destroy(damageObj);
    }

    [UnityTest]
    public IEnumerator FT_CMB_006_PlayerDiesAtZeroHealth()
    {
        _actor.Health = 1;
        GameObject damageObj = new GameObject("DamageObject");
        damageObj.tag = "Damage";
        BoxCollider2D col = damageObj.AddComponent<BoxCollider2D>();
        col.isTrigger = true;
        damageObj.transform.position = _player.transform.position;
        yield return new WaitForSeconds(1f);
        Assert.IsTrue(
            _player == null || !_player.activeSelf,
            "Player should be destroyed or deactivated when health reaches 0.");
        if (damageObj != null) Object.Destroy(damageObj);
    }

    [UnityTest]
    public IEnumerator FT_CMB_007_InvincibilityAfterDamage()
    {
        int beforeHealth = _actor.Health;
        GameObject damageObj = new GameObject("DamageObject");
        damageObj.tag = "Damage";
        BoxCollider2D col = damageObj.AddComponent<BoxCollider2D>();
        col.isTrigger = true;
        damageObj.transform.position = _player.transform.position;
        yield return new WaitForSeconds(0.1f);
        int afterFirstHit = _actor.Health;
        yield return new WaitForSeconds(0.2f);
        Assert.AreEqual(afterFirstHit, _actor.Health,
            "Health should not decrease during invincibility period.");
        Object.Destroy(damageObj);
    }
}
