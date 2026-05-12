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
        Assert.AreEqual("TitleScreen", loadedScene.name,
            "Scene name is incorrect.");
        Assert.IsTrue(loadedScene.isLoaded,
            "Scene is not loaded.");
    }

    [UnityTest]
    public IEnumerator BAT002_TitleScreenRequiredObjects_Exist()
    {
        yield return SceneManager.LoadSceneAsync("TitleScreen");
        yield return null;
        Assert.IsNotNull(GameObject.FindWithTag("MainCamera"),
            "MainCamera tag object is missing in TitleScreen scene.");
        Assert.IsNotNull(GameObject.FindWithTag("TitleMenu"),
            "TitleMenu tag object is missing in TitleScreen scene.");
        Assert.IsNotNull(GameObject.FindWithTag("GameManager"),
            "GameManager tag object is missing in TitleScreen scene.");
    }

    [UnityTest]
    public IEnumerator BAT003_SampleLevelScene_LoadsSuccessfully()
    {
        yield return SceneManager.LoadSceneAsync("SampleLevel");
        var loadedScene = SceneManager.GetActiveScene();
        Assert.AreEqual("SampleLevel", loadedScene.name,
            "Scene name is incorrect.");
        Assert.IsTrue(loadedScene.isLoaded,
            "Scene is not loaded.");
    }
}