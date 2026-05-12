using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SceneTransitionTests
{
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        yield return SceneManager.LoadSceneAsync("TitleScreen");
        yield return null;
    }

    [UnityTest]
    public IEnumerator FT_SCN_001_TransitionToSampleLevel()
    {
        TitleMenu titleMenu = Object.FindObjectOfType<TitleMenu>();
        titleMenu.StartCoroutine("StartGame");
        yield return new WaitUntil(() =>
            SceneManager.GetActiveScene().name == "SampleLevel");
        Assert.AreEqual("SampleLevel", SceneManager.GetActiveScene().name,
            "Scene should transition to SampleLevel after StartGame.");
    }

    [UnityTest]
    public IEnumerator FT_SCN_002_SampleLevelBuildIndexIsOne()
    {
        TitleMenu titleMenu = Object.FindObjectOfType<TitleMenu>();
        titleMenu.StartCoroutine("StartGame");
        yield return new WaitUntil(() =>
            SceneManager.GetActiveScene().buildIndex == 1);
        Assert.AreEqual(1, SceneManager.GetActiveScene().buildIndex,
            "SampleLevel buildIndex should be 1.");
    }

    [UnityTest]
    public IEnumerator FT_SCN_003_PlayerExistsAfterTransition()
    {
        TitleMenu titleMenu = Object.FindObjectOfType<TitleMenu>();
        titleMenu.StartCoroutine("StartGame");
        yield return new WaitUntil(() =>
            SceneManager.GetActiveScene().name == "SampleLevel");
        yield return null;
        Assert.IsNotNull(GameObject.FindWithTag("Player"),
            "Player object should exist after scene transition.");
    }
}
