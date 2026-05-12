using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class BATSceneLoadTests
{
    [UnityTest]
    public IEnumerator BAT001_TitleScreenScene_LoadsSuccessfully()
    {
        yield return SceneManager.LoadSceneAsync("TitleScreen");

        var loadedScene = SceneManager.GetActiveScene();
        Assert.AreEqual("TitleScreen", loadedScene.name);
        Assert.IsTrue(loadedScene.isLoaded);
    }

    [UnityTest]
    public IEnumerator BAT002_TitleScreenRequiredObjects_Exist()
    {
        yield return SceneManager.LoadSceneAsync("TitleScreen");
        yield return null; // Awake/Start 실행 보장

        Assert.IsNotNull(Object.FindObjectOfType<Camera2DController>(),
            "Camera2DController 컴포넌트가 TitleScreen 씬에 없습니다.");
        Assert.IsNotNull(Object.FindObjectOfType<TitleMenu>(),
            "TitleMenu 컴포넌트가 TitleScreen 씬에 없습니다.");
        Assert.IsNotNull(Object.FindObjectOfType<GameManager>(),
            "GameManager 컴포넌트가 TitleScreen 씬에 없습니다.");
    }

    [UnityTest]
    public IEnumerator BAT003_SampleLevelScene_LoadsSuccessfully()
    {
        yield return SceneManager.LoadSceneAsync("SampleLevel");

        var loadedScene = SceneManager.GetActiveScene();
        Assert.AreEqual("SampleLevel", loadedScene.name);
        Assert.IsTrue(loadedScene.isLoaded);
    }
}