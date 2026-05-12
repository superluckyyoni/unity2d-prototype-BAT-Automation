using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerMovementTests
{
    private GameObject _player;
    private Platformer2D _platformer;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        yield return SceneManager.LoadSceneAsync("SampleLevel");
        yield return null;
        _player = GameObject.FindWithTag("Player");
        _platformer = _player.GetComponent<Platformer2D>();
    }

    [UnityTest]
    public IEnumerator FT_MOV_001_PlayerExists()
    {
        Assert.IsNotNull(_player, "Player object is missing in scene.");
        Assert.IsNotNull(_platformer, "Platformer2D component is missing.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator FT_MOV_002_MoveRight()
    {
        Vector3 before = _player.transform.position;
        for (int i = 0; i < 10; i++)
        {
            _platformer.Move(1f);
            yield return new WaitForFixedUpdate();
        }
        Assert.Greater(_player.transform.position.x, before.x,
            "Player X position should increase when moving right.");
    }

    [UnityTest]
    public IEnumerator FT_MOV_003_MoveLeft()
    {
        Vector3 before = _player.transform.position;
        for (int i = 0; i < 10; i++)
        {
            _platformer.Move(-1f);
            yield return new WaitForFixedUpdate();
        }
        Assert.Less(_player.transform.position.x, before.x,
            "Player X position should decrease when moving left.");
    }

    [UnityTest]
    public IEnumerator FT_MOV_004_IsMovingTrue()
    {
        _platformer.Move(1f);
        yield return new WaitForFixedUpdate();
        Assert.IsTrue(_platformer.IsMoving,
            "IsMoving should be true while moving.");
    }

    [UnityTest]
    public IEnumerator FT_MOV_005_Jump()
    {
        Rigidbody2D rb = _player.GetComponent<Rigidbody2D>();
        yield return new WaitUntil(() => !_platformer.IsJumping && !_platformer.IsFalling);
        _platformer.Jump();
        yield return new WaitForFixedUpdate();
        Assert.Greater(rb.velocity.y, 0f,
            "Y velocity should be greater than 0 after jumping.");
    }

    [UnityTest]
    public IEnumerator FT_MOV_006_IsJumpingTrue()
    {
        Rigidbody2D rb = _player.GetComponent<Rigidbody2D>();
        yield return new WaitUntil(() => !_platformer.IsJumping && !_platformer.IsFalling);
        _platformer.Jump();
        yield return new WaitForFixedUpdate();
        Assert.Greater(rb.velocity.y, 0f,
            "Y velocity should be greater than 0 after jumping.");
        Assert.IsTrue(_platformer.IsJumping,
            "IsJumping should be true while jumping.");
    }

    [UnityTest]
    public IEnumerator FT_MOV_007_NoDoubleJump()
    {
        Rigidbody2D rb = _player.GetComponent<Rigidbody2D>();
        _platformer.Jump();
        for (int i = 0; i < 5; i++)
            yield return new WaitForFixedUpdate();
        float velocityAfterFirstJump = rb.velocity.y;
        _platformer.Jump();
        yield return new WaitForFixedUpdate();
        Assert.LessOrEqual(rb.velocity.y, velocityAfterFirstJump,
            "Double jump should not be allowed.");
    }
}
