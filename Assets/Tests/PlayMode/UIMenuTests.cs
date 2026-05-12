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

    [UnityTest]
    public IEnumerator FT_UI_001_StartGameTextExists()
    {
        Assert.IsNotNull(_titleMenu.StartGameText,
            "StartGameText UI element is missing.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator FT_UI_002_StartGameTextEnabledOnLoad()
    {
        Assert.IsTrue(_titleMenu.StartGameText.enabled,
            "StartGameText should be enabled on scene load.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator FT_UI_003_StartGameTextDisabledAfterStart()
    {
        _titleMenu.StartCoroutine("StartGame");
        yield return null;
        Assert.IsFalse(_titleMenu.StartGameText.enabled,
            "StartGameText should be disabled after game start.");
    }

    [UnityTest]
    public IEnumerator FT_UI_004_NoDuplicateStartGame()
    {
        _titleMenu.SimulateStartGame();
        yield return null;
        Assert.IsTrue(_titleMenu.PendingStartGame,
            "PendingStartGame should be true after StartGame is called.");
    }

    [UnityTest]
    public IEnumerator FT_UI_005_BackgroundMusicAssigned()
    {
        Assert.IsNotNull(_titleMenu.BackgroundMusic,
            "BackgroundMusic should be assigned in Inspector.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator FT_UI_006_AmbientSoundFXAssigned()
    {
        Assert.IsNotNull(_titleMenu.AmbientSoundFX,
            "AmbientSoundFX should be assigned in Inspector.");
        yield return null;
    }
}
