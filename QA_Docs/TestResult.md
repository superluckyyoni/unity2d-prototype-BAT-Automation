# Test Result
 
## 실행 환경
 
- Unity Version: 2022.1.10f1
- Test Type: PlayMode
- Test Framework: Unity Test Framework
---
 
## BAT 테스트 결과
 
| TC ID | 테스트 항목 | 결과 |
|---|---|---|
| BAT001 | TitleScreen 씬 로드 확인 | ✅ Pass |
| BAT002 | TitleScreen 필수 오브젝트 확인 | ✅ Pass |
| BAT003 | SampleLevel 씬 로드 확인 | ✅ Pass |
 
---
 
## 기능 테스트 결과
 
### 플레이어 이동 (PlayerMovementTests.cs)
 
| TC ID | 테스트 항목 | 결과 |
|---|---|---|
| FTMOV001 | 플레이어 오브젝트 존재 확인 | ✅ Pass |
| FTMOV002 | 오른쪽 이동 시 X 포지션 증가 확인 | ✅ Pass |
| FTMOV003 | 왼쪽 이동 시 X 포지션 감소 확인 | ✅ Pass |
| FTMOV004 | 이동 중 IsMoving 상태 확인 | ✅ Pass |
| FTMOV005 | 점프 시 Y 속도 양수 확인 | ✅ Pass |
| FTMOV006 | 점프 중 IsJumping 상태 확인 | ✅ Pass |
| FTMOV007 | 공중에서 이중 점프 방지 확인 | ✅ Pass |
 
### 전투/공격 (PlayerCombatTests.cs)
 
| TC ID | 테스트 항목 | 결과 |
|---|---|---|
| FTCMB001 | Actor 컴포넌트 존재 확인 | ✅ Pass |
| FTCMB002 | Thrower 컴포넌트 존재 확인 | ✅ Pass |
| FTCMB003 | 플레이어 초기 HP 확인 | ✅ Pass |
| FTCMB004 | 공격 시 투사체 생성 확인 | ✅ Pass |
| FTCMB005 | 피격 시 HP 감소 확인 | ✅ Pass |
| FTCMB006 | HP 0 시 사망 처리 확인 | ✅ Pass |
| FTCMB007 | 피격 후 무적시간 적용 확인 | ✅ Pass |
 
### UI/메뉴 (UIMenuTests.cs)
 
| TC ID | 테스트 항목 | 결과 |
|---|---|---|
| FTUI001 | StartGameText UI 존재 확인 | ✅ Pass |
| FTUI002 | 씬 로드 시 StartGameText 활성화 확인 | ✅ Pass |
| FTUI003 | 게임 시작 시 StartGameText 비활성화 확인 | ✅ Pass |
| FTUI004 | 게임 시작 중복 실행 방지 확인 | ✅ Pass |
| FTUI005 | BackgroundMusic 할당 확인 | ✅ Pass |
| FTUI006 | AmbientSoundFX 할당 확인 | ✅ Pass |
 
### 씬 전환 (SceneTransitionTests.cs)
 
| TC ID | 테스트 항목 | 결과 |
|---|---|---|
| FTSCN001 | TitleScreen → SampleLevel 씬 전환 확인 | ✅ Pass |
| FTSCN002 | SampleLevel buildIndex 확인 | ✅ Pass |
| FTSCN003 | 씬 전환 후 Player 오브젝트 존재 확인 | ✅ Pass |
 
---
 
## 최종 결과
 
| 구분 | TC 수 | 결과 |
|---|---|---|
| BAT 테스트 | 3개 | ✅ 전체 통과 |
| 기능 테스트 | 23개 | ✅ 전체 통과 |
| **합계** | **26개** | **✅ 26/26 통과** |
 
- Local Result: 26/26 Passed
- CI Result: 26/26 Passed
- Workflow: Unity PlayMode BAT Test
---
 
## 발견 및 수정한 이슈
 
### 이슈 1 — Editor 전용 API 컴파일 에러
 
PlayMode 테스트 실행 중 Editor 전용 API 참조로 인해 컴파일 에러가 발생했습니다.
 
수정 대상: `ShadowCaster2DGenerator.cs`, `Singleton.cs`, `Platformer2DAutomator.cs`
 
`UnityEditor`, `CustomEditor`, `Handles`, `EditorApplication` 등 Editor 전용 API를  
`#if UNITY_EDITOR` 조건부 컴파일로 분리하여 해결했습니다.
 
### 이슈 2 — 씬 로드 타이밍 문제
 
`SceneManager.LoadScene()` 사용 시 완료 보장이 없어 이후 Assert가 실패하는 문제가 발생했습니다.  
`SceneManager.LoadSceneAsync()`로 변경하여 해결했습니다.
 
### 이슈 3 — CI 환경 타이밍 문제
 
로컬에서 통과한 테스트가 GitHub Actions CI 환경에서 실패하는 문제가 발생했습니다.  
CI 배치모드 환경이 로컬보다 빠르게 동작하여 씬 전환이 일찍 발생하는 것이 원인이었습니다.  
`WaitForSeconds` 대신 `WaitUntil` 및 `WaitForEndOfFrame`으로 변경하여 해결했습니다.
 
### 이슈 4 — asmdef 참조 문제
 
기능 테스트에서 게임 스크립트 타입(`Platformer2D`, `Actor` 등)을 참조하지 못하는 문제가 발생했습니다.  
`Assets/Scripts` 폴더에 `GameScripts.asmdef`를 생성하고  
`Tests.asmdef`에서 `GameScripts`와 `Unity.TextMeshPro`를 참조하도록 설정하여 해결했습니다.
 
---
 
## 실행 결과 스크린샷
 
### Unity Test Runner
 
![Unity Test Runner Pass](Images/unity-test-runner-pass.png)
 
### GitHub Actions 실행 결과
 
![GitHub Actions Test Result](Images/github-actions-test-result.png)
 
### Discord 자동 알림
 
**성공 시**
 
![Discord Success Notification](Images/discord-success-notification.png)
 
**실패 시 (테스트명/사유/코드 위치 포함)**
 
![Discord Failure Notification](Images/discord-failure-notification.png)
