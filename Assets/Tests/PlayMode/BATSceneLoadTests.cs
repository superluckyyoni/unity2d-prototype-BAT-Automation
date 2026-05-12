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
        SceneManager.LoadScene("TitleScreen");

        yield return null;

        var loadedScene = SceneManager.GetActiveScene();

        Assert.AreEqual("TitleScreen", loadedScene.name);
        Assert.IsTrue(loadedScene.isLoaded);
    }

    [UnityTest]
    public IEnumerator BAT002_TitleScreenRequiredObjects_Exist()
    {
        SceneManager.LoadScene("TitleScreen");

        yield return null;

        Assert.IsNotNull(GameObject.Find("Camera"), "Camera object is missing in TitleScreen scene.");
        Assert.IsNotNull(GameObject.Find("TitleMenu"), "TitleMenu object is missing in TitleScreen scene.");
        Assert.IsNotNull(GameObject.Find("GameManager"), "GameManager object is missing in TitleScreen scene.");
    }

    [UnityTest]
    public IEnumerator BAT003_SampleLevelScene_LoadsSuccessfully()
    {
        SceneManager.LoadScene("SampleLevel");

        yield return null;

        var loadedScene = SceneManager.GetActiveScene();

        Assert.AreEqual("SampleLevel", loadedScene.name);
        Assert.IsTrue(loadedScene.isLoaded);
    }

    [Test]
    public void BAT999_ForcedFailure_DiscordNotificationTest()
    {
        Assert.Fail("Discord notification failure test.");
    }
}
