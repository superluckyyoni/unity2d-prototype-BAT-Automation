# Test Result

## 실행 환경

- Unity Version: 2022.1.10f1
- Test Type: PlayMode
- Test Framework: Unity Test Framework

## 테스트 결과

| TC ID | 테스트 항목 | 결과 |
|---|---|---|
| `BAT001` | TitleScreen 씬 로드 확인 | Pass |
| `BAT002` | TitleScreen 필수 오브젝트 확인 | Pass |
| `BAT003` | SampleLevel 씬 로드 확인 | Pass |

## 발견 및 수정한 이슈

PlayMode 테스트 실행 중 Player 빌드 단계에서 Editor 전용 API 참조로 인해 컴파일 에러가 발생했습니다.

수정 대상:
- ShadowCaster2DGenerator.cs
- Singleton.cs
- Platformer2DAutomator.cs

조치:
- UnityEditor, CustomEditor, Handles, EditorApplication 등 Editor 전용 API를 `#if UNITY_EDITOR` 조건부 컴파일로 분리했습니다.

## 결과

수정 후 PlayMode BAT 테스트 3개가 정상 통과했습니다.
