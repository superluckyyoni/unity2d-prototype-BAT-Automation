# Unity2D BAT & 기능 테스트 자동화
 
![Unity PlayMode BAT Test](https://github.com/superluckyyoni/unity2d-prototype-BAT-Automation/actions/workflows/unity-playmode-test.yml/badge.svg)
 
공개 Unity 2D 플랫포머 프로젝트를 fork하여 BAT(Build Acceptance Test) 및 기능 테스트 자동화를 구현한 포트폴리오입니다.
 
---
 
## 포트폴리오 작업 내용
 
게임 QA로 일하면서 신규 빌드가 나올 때마다 BAT를 수작업으로 반복하는 것이 비효율적이라고 느꼈습니다.  
이를 해결하기 위해 공개 Unity 2D 프로젝트를 대상으로 BAT 및 기능 테스트를 설계하고 자동화 구조를 직접 구현했습니다.
 
- Unity Test Framework 기반 PlayMode BAT 테스트 3개 구현
- 기능 테스트(이동, 전투, UI, 씬 전환) 23개 추가 구현 — 총 26개 TC
- BAT 통과 후 기능 테스트를 실행하는 단계적 테스트 구조 설계
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
 
## 테스트 구성 및 결과
 
### 테스트 실행 흐름
 
```
코드 수정 후 GitHub push
        ↓
GitHub Actions 자동 감지
        ↓
BAT 테스트 실행 → 통과 시 기능 테스트 실행
        ↓
Discord 자동 알림
```
 
### BAT 테스트 (BATSceneLoadTests.cs)
 
신규 빌드가 나왔을 때 가장 먼저 실행하는 기본 동작 확인 테스트입니다.
 
| TC ID | 테스트 항목 | 결과 |
|---|---|---|
| BAT001 | TitleScreen 씬 로드 확인 | ✅ Pass |
| BAT002 | TitleScreen 필수 오브젝트 확인 | ✅ Pass |
| BAT003 | SampleLevel 씬 로드 확인 | ✅ Pass |
 
### 기능 테스트
 
BAT 통과 후 세부 기능이 올바르게 동작하는지 확인하는 테스트입니다.
 
#### 플레이어 이동 (PlayerMovementTests.cs)
 
| TC ID | 테스트 항목 | 결과 |
|---|---|---|
| FTMOV001 | 플레이어 오브젝트 존재 확인 | ✅ Pass |
| FTMOV002 | 오른쪽 이동 시 X 포지션 증가 확인 | ✅ Pass |
| FTMOV003 | 왼쪽 이동 시 X 포지션 감소 확인 | ✅ Pass |
| FTMOV004 | 이동 중 IsMoving 상태 확인 | ✅ Pass |
| FTMOV005 | 점프 시 Y 속도 양수 확인 | ✅ Pass |
| FTMOV006 | 점프 중 IsJumping 상태 확인 | ✅ Pass |
| FTMOV007 | 공중에서 이중 점프 방지 확인 | ✅ Pass |
 
#### 전투/공격 (PlayerCombatTests.cs)
 
| TC ID | 테스트 항목 | 결과 |
|---|---|---|
| FTCMB001 | Actor 컴포넌트 존재 확인 | ✅ Pass |
| FTCMB002 | Thrower 컴포넌트 존재 확인 | ✅ Pass |
| FTCMB003 | 플레이어 초기 HP 확인 | ✅ Pass |
| FTCMB004 | 공격 시 투사체 생성 확인 | ✅ Pass |
| FTCMB005 | 피격 시 HP 감소 확인 | ✅ Pass |
| FTCMB006 | HP 0 시 사망 처리 확인 | ✅ Pass |
| FTCMB007 | 피격 후 무적시간 적용 확인 | ✅ Pass |
 
#### UI/메뉴 (UIMenuTests.cs)
 
| TC ID | 테스트 항목 | 결과 |
|---|---|---|
| FTUI001 | StartGameText UI 존재 확인 | ✅ Pass |
| FTUI002 | 씬 로드 시 StartGameText 활성화 확인 | ✅ Pass |
| FTUI003 | 게임 시작 시 StartGameText 비활성화 확인 | ✅ Pass |
| FTUI004 | 게임 시작 중복 실행 방지 확인 | ✅ Pass |
| FTUI005 | BackgroundMusic 할당 확인 | ✅ Pass |
| FTUI006 | AmbientSoundFX 할당 확인 | ✅ Pass |
 
#### 씬 전환 (SceneTransitionTests.cs)
 
| TC ID | 테스트 항목 | 결과 |
|---|---|---|
| FTSCN001 | TitleScreen → SampleLevel 씬 전환 확인 | ✅ Pass |
| FTSCN002 | SampleLevel buildIndex 확인 | ✅ Pass |
| FTSCN003 | 씬 전환 후 Player 오브젝트 존재 확인 | ✅ Pass |
 
### 최종 결과
 
| 구분 | TC 수 | 결과 |
|---|---|---|
| BAT 테스트 | 3개 | ✅ 전체 통과 |
| 기능 테스트 | 23개 | ✅ 전체 통과 |
| **합계** | **26개** | **✅ 26/26 통과** |
 
- Local Result: 26/26 Passed
- CI Result: 26/26 Passed
### GitHub Actions 실행 결과
 
![GitHub Actions Test Result](QA_Docs/Images/github-actions-test-result.png)
 
### 디스코드 자동 알림
 
**성공 시**
 
![Discord Success](QA_Docs/Images/discord-success-notification.png)
 
**실패 시 (테스트명/사유/코드 위치 포함)**
 
![Discord Failure](QA_Docs/Images/discord-failure-notification.png)
 
---
 
## 테스트 설계 시 주요 고려사항
 
### BAT와 기능 테스트 역할 분리
 
BAT는 "빌드가 기본적으로 실행되는가"를 확인하고,  
기능 테스트는 "세부 기능이 올바르게 동작하는가"를 확인합니다.  
두 테스트 간 중복 항목이 없도록 설계했습니다.
 
### 오브젝트 탐색 방식
 
`GameObject.Find(이름)` 대신 `GameObject.FindWithTag(태그)`를 사용했습니다.  
오브젝트 이름은 개발 중 변경될 수 있지만, 태그는 의도적으로 변경하지 않는 한 유지되기 때문입니다.
 
### 씬 로드 방식
 
`SceneManager.LoadScene()` 대신 `SceneManager.LoadSceneAsync()`를 사용했습니다.  
동기 로드는 완료 보장이 없어 타이밍 문제가 발생할 수 있기 때문입니다.
 
### CI 환경 타이밍 대응
 
로컬과 GitHub Actions 환경은 실행 속도가 달라 타이밍 문제가 발생할 수 있습니다.  
시간 기반 대기(`WaitForSeconds`) 대신 조건 기반 대기(`WaitUntil`)를 사용해  
환경에 관계없이 안정적으로 동작하도록 설계했습니다.
 
---
 
## 발견 및 수정한 이슈
 
PlayMode 테스트 실행 중 Editor 전용 API 참조로 인해 컴파일 에러가 발생했습니다.
 
수정 대상: `ShadowCaster2DGenerator.cs`, `Singleton.cs`, `Platformer2DAutomator.cs`
 
`UnityEditor`, `CustomEditor`, `Handles`, `EditorApplication` 등 Editor 전용 API를  
`#if UNITY_EDITOR` 조건부 컴파일로 분리하여 해결했습니다.
 
---
 
## QA 문서
 
- [Test Plan](QA_Docs/TestPlan.md)
- [Test Cases](QA_Docs/TestCases.md)
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
