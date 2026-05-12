using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerMovementTests
{
    private GameObject _player;
    private Platformer2D _platformer;

    // 각 테스트 전에 씬 로드 및 플레이어 참조
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        yield return SceneManager.LoadSceneAsync("SampleLevel");
        yield return null;
        _player = GameObject.FindWithTag("Player");
        _platformer = _player.GetComponent<Platformer2D>();
    }

    // ── 이동 ──────────────────────────────────────

    [UnityTest]
    public IEnumerator FT_MOV_001_PlayerExists()
    {
        // 플레이어 오브젝트가 씬에 존재하는지 확인
        Assert.IsNotNull(_player, "Player 오브젝트가 씬에 없습니다.");
        Assert.IsNotNull(_platformer, "Platformer2D 컴포넌트가 없습니다.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator FT_MOV_002_MoveRight()
    {
        // 오른쪽으로 이동 시 X 포지션이 증가하는지 확인
        Vector3 before = _player.transform.position;
        for (int i = 0; i < 10; i++)
        {
            _platformer.Move(1f);
            yield return new WaitForFixedUpdate();
        }
        Assert.Greater(_player.transform.position.x, before.x,
            "오른쪽 이동 후 X 포지션이 증가해야 합니다.");
    }

    [UnityTest]
    public IEnumerator FT_MOV_003_MoveLeft()
    {
        // 왼쪽으로 이동 시 X 포지션이 감소하는지 확인
        Vector3 before = _player.transform.position;
        for (int i = 0; i < 10; i++)
        {
            _platformer.Move(-1f);
            yield return new WaitForFixedUpdate();
        }
        Assert.Less(_player.transform.position.x, before.x,
            "왼쪽 이동 후 X 포지션이 감소해야 합니다.");
    }

    [UnityTest]
    public IEnumerator FT_MOV_004_IsMovingTrue()
    {
        // 이동 중 IsMoving 프로퍼티가 true인지 확인
        _platformer.Move(1f);
        yield return new WaitForFixedUpdate();
        Assert.IsTrue(_platformer.IsMoving,
            "이동 중 IsMoving이 true여야 합니다.");
    }

    [UnityTest]
    public IEnumerator FT_MOV_005_Jump()
    {
        Rigidbody2D rb = _player.GetComponent<Rigidbody2D>();

        // 착지할 때까지 대기
        yield return new WaitUntil(() => !_platformer.IsJumping && !_platformer.IsFalling);

        _platformer.Jump();
        yield return new WaitForFixedUpdate();
        Assert.Greater(rb.velocity.y, 0f,
            "점프 후 Y 속도가 0보다 커야 합니다.");
    }

    [UnityTest]
    public IEnumerator FT_MOV_006_IsJumpingTrue()
    {
        Rigidbody2D rb = _player.GetComponent<Rigidbody2D>();

        // 착지할 때까지 대기
        yield return new WaitUntil(() => !_platformer.IsJumping && !_platformer.IsFalling);

        _platformer.Jump();
        yield return new WaitForFixedUpdate();
        Assert.Greater(rb.velocity.y, 0f,
            "점프 직후 Y 속도가 0보다 커야 합니다.");
        Assert.IsTrue(_platformer.IsJumping,
            "점프 중 IsJumping이 true여야 합니다.");
    }

    [UnityTest]
    public IEnumerator FT_MOV_007_NoDoubleJump()
    {
        Rigidbody2D rb = _player.GetComponent<Rigidbody2D>();
        _platformer.Jump();
        yield return new WaitForFixedUpdate();
        float velocityAfterFirstJump = rb.velocity.y;
        _platformer.Jump(); // 공중에서 재점프 시도
        yield return new WaitForFixedUpdate();
        Assert.LessOrEqual(rb.velocity.y, velocityAfterFirstJump,
            "공중에서 이중 점프가 되면 안 됩니다.");
    }
}
