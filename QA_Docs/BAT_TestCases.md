# BAT Test Cases

## TC ID 규칙

본 문서의 테스트 케이스 ID는 `BAT001`, `BAT002` 형식으로 관리합니다.

## 테스트 케이스 목록

| TC ID | 테스트 항목 | 사전 조건 | 테스트 절차 | 기대 결과 | 자동화 유형 | 우선순위 |
|---|---|---|---|---|---|---|
| `BAT001` | 프로젝트 기본 설정 확인 | 프로젝트 파일이 정상적으로 존재함 | Unity 버전 및 주요 설정 파일을 확인한다 | Unity 2022.1.10f1 기준 프로젝트임을 확인한다 | Manual / Static Check | High |
| `BAT002` | TitleScreen 씬 로드 확인 | Unity 프로젝트가 열린 상태 | Play Mode 테스트에서 TitleScreen 씬을 로드한다 | TitleScreen 씬이 오류 없이 로드된다 | Play Mode | High |
| `BAT003` | Play Mode 진입 확인 | TitleScreen 씬이 로드 가능한 상태 | Play Mode에 진입한다 | 예외 없이 Play Mode에 진입한다 | Play Mode | High |
| `BAT004` | TitleScreen 필수 오브젝트 확인 | TitleScreen 씬이 로드된 상태 | Camera, TitleMenu, GameManager 오브젝트를 검색한다 | 필수 오브젝트가 씬에 존재한다 | Play Mode | High |
| `BAT005` | SampleLevel 씬 로드 확인 | Unity 프로젝트가 열린 상태 | Play Mode 테스트에서 SampleLevel 씬을 로드한다 | SampleLevel 씬이 오류 없이 로드된다 | Play Mode | High |
| `BAT006` | 주요 Staging 씬 로드 확인 | Staging 씬 파일이 존재하는 상태 | 주요 Staging 씬을 순차적으로 로드한다 | 각 Staging 씬이 오류 없이 로드된다 | Play Mode | Medium |
| `BAT007` | 치명적 에러 로그 확인 | Play Mode 테스트가 실행된 상태 | 테스트 실행 중 Error 또는 Exception 로그 발생 여부를 확인한다 | 치명적 에러 로그가 발생하지 않는다 | Play Mode | High |
| `BAT008` | 주요 씬 연속 로드 확인 | 주요 씬 파일이 존재하는 상태 | TitleScreen, SampleLevel, 주요 Staging 씬을 순차적으로 로드한다 | 각 씬이 중단 없이 정상 로드된다 | Play Mode | Medium |

## 자동화 우선순위

1. TitleScreen 씬 로드 확인
2. Play Mode 진입 확인
3. TitleScreen 필수 오브젝트 확인
4. SampleLevel 씬 로드 확인
5. 치명적 에러 로그 확인
6. 주요 Staging 씬 로드 확인

## 자동화 파이프라인 확인 항목

| TC ID | 확인 항목 | 기대 결과 |
|---|---|---|
| `PIPE001` | GitHub Actions 실행 확인 | push 시 자동화 테스트 workflow가 실행된다 |
| `PIPE002` | 테스트 결과 리포트 생성 확인 | 테스트 실행 결과를 확인할 수 있는 리포트가 생성된다 |
| `PIPE003` | Discord 알림 확인 | 테스트 성공/실패 결과가 Discord 채널로 전송된다 |

## 비고

본 테스트 케이스는 BAT 관점에서 빌드가 기본적으로 실행 가능한 상태인지 확인하기 위한 항목으로 구성했습니다.

이동, 점프, 적 충돌, 문/스위치 동작 등 상세 게임 플레이 기능은 BAT 범위를 초과하므로,  
기능 테스트 또는 회귀 테스트 단계에서 별도 검증 대상으로 분류합니다.

현재 테스트 케이스는 프로젝트 README, 파일 구조, Unity 씬 구성을 기반으로 작성한 초안입니다.  
unity에서 실제 씬 이름과 오브젝트 구조를 확인한 뒤,  
테스트 코드 작성 단계에서 세부 절차를 프로젝트 구조에 맞게 수정할 예정입니다.
