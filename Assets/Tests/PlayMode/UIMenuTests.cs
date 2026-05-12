using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class UIMenuTests
{
    private TitleMenu _titleMenu;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        yield return SceneManager.LoadSceneAsync("TitleScreen");
        yield return null;
        _titleMenu = Object.FindObjectOfType<TitleMenu>();
    }

    // ── UI ──────────────────────────────────────

    [UnityTest]
    public IEnumerator FT_UI_001_StartGameTextExists()
    {
        // StartGameText UI 요소가 존재하는지 확인
        Assert.IsNotNull(_titleMenu.StartGameText,
            "StartGameText UI 요소가 없습니다.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator FT_UI_002_StartGameTextEnabledOnLoad()
    {
        // 씬 로드 시 StartGameText가 활성화되어 있는지 확인
        Assert.IsTrue(_titleMenu.StartGameText.enabled,
            "씬 로드 시 StartGameText가 활성화되어 있어야 합니다.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator FT_UI_003_StartGameTextDisabledAfterStart()
    {
        _titleMenu.StartCoroutine("StartGame");
        // 씬 전환 전 딱 한 프레임만 대기
        yield return new WaitForEndOfFrame();
        Assert.IsFalse(_titleMenu.StartGameText.enabled,
            "게임 시작 후 StartGameText가 비활성화되어야 합니다.");
    }

    [UnityTest]
    public IEnumerator FT_UI_004_NoDuplicateStartGame()
    {
        _titleMenu.StartCoroutine("StartGame");
        yield return new WaitForEndOfFrame();

        // 첫 실행 직후 PendingStartGame이 true인지만 확인
        Assert.IsTrue(_titleMenu.PendingStartGame,
            "StartGame 실행 후 PendingStartGame이 true여야 합니다.");
    }

    [UnityTest]
    public IEnumerator FT_UI_005_BackgroundMusicAssigned()
    {
        // BackgroundMusic AudioClip이 Inspector에 할당되어 있는지 확인
        Assert.IsNotNull(_titleMenu.BackgroundMusic,
            "BackgroundMusic이 Inspector에 할당되어 있어야 합니다.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator FT_UI_006_AmbientSoundFXAssigned()
    {
        // AmbientSoundFX AudioClip이 Inspector에 할당되어 있는지 확인
        Assert.IsNotNull(_titleMenu.AmbientSoundFX,
            "AmbientSoundFX가 Inspector에 할당되어 있어야 합니다.");
        yield return null;
    }
}
