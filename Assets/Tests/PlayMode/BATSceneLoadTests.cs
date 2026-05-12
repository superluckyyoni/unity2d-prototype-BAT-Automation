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
        Assert.AreEqual("WrongSceneName", loadedScene.name, "씬 이름이 올바르지 않습니다.");
        Assert.IsTrue(loadedScene.isLoaded);
    }

    [UnityTest]
    public IEnumerator BAT002_TitleScreenRequiredObjects_Exist()
    {
        yield return SceneManager.LoadSceneAsync("TitleScreen");
        yield return null; // Awake/Start 실행 보장

        // v 태그로 오브젝트 탐색
        Assert.IsNotNull(GameObject.FindWithTag("MainCamera"),
            "MainCamera 태그 오브젝트가 TitleScreen 씬에 없습니다.");
        Assert.IsNotNull(GameObject.FindWithTag("TitleMenu"),
            "TitleMenu 태그 오브젝트가 TitleScreen 씬에 없습니다.");
        Assert.IsNotNull(GameObject.FindWithTag("GameManager"),
            "GameManager 태그 오브젝트가 TitleScreen 씬에 없습니다.");
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