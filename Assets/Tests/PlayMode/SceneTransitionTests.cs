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

    // ── 씬 전환 ──────────────────────────────────────

    [UnityTest]
    public IEnumerator FT_SCN_001_TransitionToSampleLevel()
    {
        // TitleScreen에서 StartGame() 실행 시 SampleLevel로 전환되는지 확인
        TitleMenu titleMenu = Object.FindObjectOfType<TitleMenu>();
        titleMenu.StartCoroutine("StartGame");

        // 씬 전환 완료까지 대기
        yield return new WaitUntil(() =>
            SceneManager.GetActiveScene().name == "SampleLevel");

        Assert.AreEqual("SampleLevel", SceneManager.GetActiveScene().name,
            "StartGame() 실행 후 SampleLevel로 전환되어야 합니다.");
    }

    [UnityTest]
    public IEnumerator FT_SCN_002_SampleLevelBuildIndexIsOne()
    {
        // SampleLevel이 buildIndex 1인지 확인 (buildIndex + 1 로직 검증)
        TitleMenu titleMenu = Object.FindObjectOfType<TitleMenu>();
        titleMenu.StartCoroutine("StartGame");

        yield return new WaitUntil(() =>
            SceneManager.GetActiveScene().buildIndex == 1);

        Assert.AreEqual(1, SceneManager.GetActiveScene().buildIndex,
            "SampleLevel의 buildIndex가 1이어야 합니다.");
    }

    [UnityTest]
    public IEnumerator FT_SCN_003_PlayerExistsAfterTransition()
    {
        // 씬 전환 후 Player 태그 오브젝트가 존재하는지 확인
        TitleMenu titleMenu = Object.FindObjectOfType<TitleMenu>();
        titleMenu.StartCoroutine("StartGame");

        yield return new WaitUntil(() =>
            SceneManager.GetActiveScene().name == "SampleLevel");
        yield return null; // 씬 초기화 대기

        Assert.IsNotNull(GameObject.FindWithTag("Player"),
            "씬 전환 후 Player 태그 오브젝트가 존재해야 합니다.");
    }
}
