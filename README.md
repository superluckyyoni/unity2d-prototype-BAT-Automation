# Unity2D BAT Automation

![Unity PlayMode BAT Test](https://github.com/superluckyyoni/unity2d-prototype-BAT-Automation/actions/workflows/unity-playmode-test.yml/badge.svg)

공개 Unity 2D 플랫포머 프로젝트를 fork하여 BAT(Build Acceptance Test) 자동화를 구현한 포트폴리오입니다.

---

## 포트폴리오 작업 내용

게임 QA로 일하면서 신규 빌드가 나올 때마다 BAT를 수작업으로 반복하는 것이 비효율적이라고 느꼈습니다.

이를 해결하기 위해 공개 Unity 2D 프로젝트를 대상으로 BAT 테스트를 설계하고 자동화 구조를 직접 구현했습니다.

- Unity Test Framework 기반 PlayMode BAT 테스트 3개 구현
- GitHub Actions CI 연동 (push 시 자동 테스트 실행)
- 디스코드 자동 알림 연동 (성공 시 통과 결과, 실패 시 테스트명/사유/코드 위치 전송)
- 테스트 과정에서 발견한 컴파일 에러 직접 수정 (`#if UNITY_EDITOR` 조건부 컴파일 적용)

---

## 기술 스택

- Unity 2022.1.10f1
- Unity Test Framework (PlayMode)
- GitHub Actions CI
- Discord Webhook
- C#

---

## 테스트 결과

| TC ID | 테스트 항목 | 결과 |
|---|---|---|
| BAT001 | TitleScreen 씬 로드 확인 | ✅ Pass |
| BAT002 | TitleScreen 필수 오브젝트 확인 | ✅ Pass |
| BAT003 | SampleLevel 씬 로드 확인 | ✅ Pass |

- Local Result: 3/3 Passed
- CI Result: 3/3 Passed

### GitHub Actions 실행 결과

![GitHub Actions Test Result](QA_Docs/Images/github-actions-test-result.png)

### 디스코드 자동 알림

**성공 시**

![Discord Success](QA_Docs/Images/discord-success-notification.png)

**실패 시 (테스트명/사유/코드 위치 포함)**

![Discord Failure](QA_Docs/Images/discord-failure-notification.png)

---

## 발견 및 수정한 이슈

PlayMode 테스트 실행 중 Editor 전용 API 참조로 인해 컴파일 에러가 발생했습니다.

수정 대상: `ShadowCaster2DGenerator.cs`, `Singleton.cs`, `Platformer2DAutomator.cs`

`UnityEditor`, `CustomEditor`, `Handles`, `EditorApplication` 등 Editor 전용 API를
`#if UNITY_EDITOR` 조건부 컴파일로 분리하여 해결했습니다.

---

## QA 문서

- [BAT Test Plan](QA_Docs/BAT_TestPlan.md)
- [BAT Test Cases](QA_Docs/BAT_TestCases.md)
- [Automation Scope](QA_Docs/Automation_Scope.md)
- [Test Result](QA_Docs/TestResult.md)

---

## 원본 프로젝트 정보

- Original Repository: https://github.com/practical-works/unity2d-prototype
- Unity Version: 2022.1.10f1
- License: MIT License
- Original Project: Prototype - 2D Platformer Game

본 레포지토리는 원본 프로젝트를 fork하여 QA 자동화 포트폴리오 목적으로 작업한 것입니다.
게임 개발물이 아닌 테스트 설계 및 자동화 구현이 주요 작업 범위입니다.
