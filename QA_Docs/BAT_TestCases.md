# BAT Test Cases

## TC ID 규칙

본 문서의 테스트 케이스 ID는 `BAT001`, `BAT002` 형식으로 관리합니다.

## 테스트 케이스 목록

| TC ID | 테스트 항목 | 사전 조건 | 테스트 절차 | 기대 결과 | 자동화 유형 | 우선순위 |
|---|---|---|---|---|---|---|
| `BAT001` | 프로젝트 기본 설정 확인 | 프로젝트 파일이 정상적으로 존재함 | Unity 버전 및 주요 설정 파일을 확인한다 | Unity 2022.1.10f1 기준 프로젝트임을 확인한다 | Manual / Static Check | High |
| `BAT002` | 메인 씬 로드 확인 | Unity 프로젝트가 열린 상태 | Play Mode 테스트에서 메인 씬을 로드한다 | 씬이 오류 없이 로드된다 | Play Mode | High |
| `BAT003` | Play Mode 진입 확인 | 메인 씬이 로드 가능한 상태 | Play Mode에 진입한다 | 예외 없이 Play Mode에 진입한다 | Play Mode | High |
| `BAT004` | Player 오브젝트 존재 확인 | 메인 씬이 로드된 상태 | Player 태그 또는 Player 오브젝트를 검색한다 | Player 오브젝트가 씬에 존재한다 | Play Mode | High |
| `BAT005` | 주요 카메라 존재 확인 | 메인 씬이 로드된 상태 | Main Camera 오브젝트를 검색한다 | Main Camera가 존재한다 | Play Mode | Medium |
| `BAT006` | 기본 이동 기능 확인 | Player 오브젝트가 존재하는 상태 | 이동 입력 또는 이동 관련 메서드를 호출한다 | Player 위치 또는 상태 값이 변경된다 | Play Mode | Medium |
| `BAT007` | 점프 기능 확인 | Player가 지면에 있는 상태 | 점프 입력 또는 점프 관련 메서드를 호출한다 | Player의 Y축 위치 또는 속도 값이 변경된다 | Play Mode | Medium |
| `BAT008` | 주요 상호작용 오브젝트 확인 | 메인 씬이 로드된 상태 | 문, 트리거, 장애물 등 주요 오브젝트를 검색한다 | 게임 진행에 필요한 오브젝트가 누락되지 않는다 | Play Mode | Medium |

## 자동화 우선순위

1. 메인 씬 로드 확인
2. Play Mode 진입 확인
3. Player 오브젝트 존재 확인
4. Main Camera 존재 확인
5. 기본 이동/점프 기능 확인

## 비고

현재 테스트 케이스는 프로젝트 README 및 파일 구조를 기반으로 작성한 초안입니다.  
Unity에서 실제 씬과 오브젝트 구조를 확인한 뒤,
오브젝트 이름, 태그, 테스트 절차를 프로젝트 구조에 맞게 수정할 예정입니다.
