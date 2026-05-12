# BAT & 기능 테스트 케이스
 
## TC ID 규칙
 
- BAT 테스트: `BAT001`, `BAT002` 형식
- 기능 테스트: `FTMOV001`(이동), `FTCMB001`(전투), `FTUI001`(UI), `FTSCN001`(씬전환) 형식
---
 
## BAT 테스트 케이스 (BATSceneLoadTests.cs)
 
| TC ID | 테스트 항목 | 테스트 절차 | 기대 결과 | 자동화 유형 | 우선순위 |
|---|---|---|---|---|---|
| `BAT001` | TitleScreen 씬 로드 확인 | TitleScreen 씬을 로드한다 | 씬이 오류 없이 로드된다 | Play Mode | High |
| `BAT002` | TitleScreen 필수 오브젝트 확인 | Camera, TitleMenu, GameManager 태그 오브젝트를 검색한다 | 필수 오브젝트가 씬에 존재한다 | Play Mode | High |
| `BAT003` | SampleLevel 씬 로드 확인 | SampleLevel 씬을 로드한다 | 씬이 오류 없이 로드된다 | Play Mode | High |
 
---
 
## 기능 테스트 케이스
 
### 플레이어 이동 (PlayerMovementTests.cs)
 
| TC ID | 테스트 항목 | 테스트 절차 | 기대 결과 | 자동화 유형 | 우선순위 |
|---|---|---|---|---|---|
| `FTMOV001` | 플레이어 오브젝트 존재 확인 | Player 태그 오브젝트와 Platformer2D 컴포넌트를 검색한다 | 오브젝트와 컴포넌트가 존재한다 | Play Mode | High |
| `FTMOV002` | 오른쪽 이동 확인 | Move(1f)를 10프레임 호출한다 | X 포지션이 증가한다 | Play Mode | High |
| `FTMOV003` | 왼쪽 이동 확인 | Move(-1f)를 10프레임 호출한다 | X 포지션이 감소한다 | Play Mode | High |
| `FTMOV004` | 이동 중 IsMoving 상태 확인 | Move(1f) 호출 후 IsMoving을 확인한다 | IsMoving이 true다 | Play Mode | Medium |
| `FTMOV005` | 점프 확인 | 착지 후 Jump()를 호출한다 | Y 속도가 0보다 크다 | Play Mode | High |
| `FTMOV006` | 점프 중 IsJumping 상태 확인 | Jump() 호출 후 IsJumping을 확인한다 | IsJumping이 true다 | Play Mode | Medium |
| `FTMOV007` | 이중 점프 방지 확인 | 공중에서 Jump()를 재호출한다 | 추가 점프가 발생하지 않는다 | Play Mode | High |
 
### 전투/공격 (PlayerCombatTests.cs)
 
| TC ID | 테스트 항목 | 테스트 절차 | 기대 결과 | 자동화 유형 | 우선순위 |
|---|---|---|---|---|---|
| `FTCMB001` | Actor 컴포넌트 존재 확인 | Player에서 Actor 컴포넌트를 검색한다 | Actor 컴포넌트가 존재한다 | Play Mode | High |
| `FTCMB002` | Thrower 컴포넌트 존재 확인 | Player에서 Thrower 컴포넌트를 검색한다 | Thrower 컴포넌트가 존재한다 | Play Mode | High |
| `FTCMB003` | 초기 HP 확인 | Actor.Health 값을 확인한다 | Health가 0보다 크다 | Play Mode | High |
| `FTCMB004` | 투사체 생성 확인 | ThrowProjectile()을 호출한다 | 씬의 오브젝트 수가 증가한다 | Play Mode | High |
| `FTCMB005` | 피격 시 HP 감소 확인 | Damage 태그 콜라이더를 플레이어 위치에 생성한다 | Health가 감소한다 | Play Mode | High |
| `FTCMB006` | HP 0 시 사망 처리 확인 | Health를 1로 설정 후 피격시킨다 | 플레이어가 제거되거나 비활성화된다 | Play Mode | High |
| `FTCMB007` | 무적시간 적용 확인 | 피격 직후 추가 피격을 시도한다 | 무적시간 동안 HP가 추가 감소하지 않는다 | Play Mode | Medium |
 
### UI/메뉴 (UIMenuTests.cs)
 
| TC ID | 테스트 항목 | 테스트 절차 | 기대 결과 | 자동화 유형 | 우선순위 |
|---|---|---|---|---|---|
| `FTUI001` | StartGameText 존재 확인 | TitleMenu의 StartGameText를 확인한다 | StartGameText가 존재한다 | Play Mode | High |
| `FTUI002` | 씬 로드 시 StartGameText 활성화 확인 | 씬 로드 후 StartGameText.enabled를 확인한다 | enabled가 true다 | Play Mode | Medium |
| `FTUI003` | 게임 시작 시 StartGameText 비활성화 확인 | StartGame() 코루틴 실행 후 확인한다 | enabled가 false다 | Play Mode | High |
| `FTUI004` | 게임 시작 중복 실행 방지 확인 | SimulateStartGame() 호출 후 PendingStartGame을 확인한다 | PendingStartGame이 true다 | Play Mode | Medium |
| `FTUI005` | BackgroundMusic 할당 확인 | TitleMenu.BackgroundMusic을 확인한다 | BackgroundMusic이 null이 아니다 | Play Mode | Medium |
| `FTUI006` | AmbientSoundFX 할당 확인 | TitleMenu.AmbientSoundFX를 확인한다 | AmbientSoundFX가 null이 아니다 | Play Mode | Medium |
 
### 씬 전환 (SceneTransitionTests.cs)
 
| TC ID | 테스트 항목 | 테스트 절차 | 기대 결과 | 자동화 유형 | 우선순위 |
|---|---|---|---|---|---|
| `FTSCN001` | TitleScreen → SampleLevel 전환 확인 | StartGame() 실행 후 씬 이름을 확인한다 | 씬 이름이 SampleLevel이다 | Play Mode | High |
| `FTSCN002` | SampleLevel buildIndex 확인 | 씬 전환 후 buildIndex를 확인한다 | buildIndex가 1이다 | Play Mode | Medium |
| `FTSCN003` | 씬 전환 후 Player 존재 확인 | 씬 전환 후 Player 태그 오브젝트를 검색한다 | Player 오브젝트가 존재한다 | Play Mode | High |
 
---
 
## 자동화 파이프라인 확인 항목
 
| TC ID | 확인 항목 | 기대 결과 |
|---|---|---|
| `PIPE001` | GitHub Actions 실행 확인 | push 시 자동화 테스트 workflow가 실행된다 |
| `PIPE002` | 테스트 결과 리포트 생성 확인 | 테스트 실행 결과를 확인할 수 있는 artifact가 생성된다 |
| `PIPE003` | Discord 알림 확인 | 테스트 성공/실패 결과가 Discord 채널로 전송된다 |
 
---
 
## 비고
 
BAT 테스트는 빌드가 기본적으로 실행 가능한 상태인지 확인하는 항목으로 구성했습니다.  
기능 테스트는 BAT 통과 후 세부 기능이 올바르게 동작하는지 확인하는 항목으로 구성했습니다.  
두 테스트 간 중복 항목이 없도록 설계했습니다.
