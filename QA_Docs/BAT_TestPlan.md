# Test Plan
 
## 1. 목적
 
본 문서는 공개 Unity 2D 플랫포머 프로젝트를 대상으로,  
빌드 수락 테스트(BAT, Build Acceptance Test) 및 기능 테스트 범위를 정의하고  
자동화 테스트 적용 계획을 정리하기 위해 작성되었습니다.
 
본 포트폴리오에서 BAT는 상세 게임 플레이 기능 검증이 아니라,  
신규 빌드 또는 프로젝트 변경 후 기본 실행 가능 여부를 빠르게 확인하는 테스트로 정의합니다.
 
BAT 통과 후 세부 기능이 올바르게 동작하는지 확인하는 기능 테스트를 추가로 수행합니다.
 
## 2. 테스트 대상
 
- Project: Prototype - 2D Platformer Game
- Original Repository: https://github.com/practical-works/unity2d-prototype
- Unity Version: 2022.1.10f1
- License: MIT License
- Test Framework: Unity Test Framework

## 3. BAT 범위
 
본 프로젝트에서는 다음과 같은 항목을 BAT 대상으로 선정합니다.
 
- TitleScreen 씬이 오류 없이 로드되는지 확인
- TitleScreen 씬의 필수 오브젝트(Camera, TitleMenu, GameManager)가 누락되지 않았는지 확인
- SampleLevel 씬이 오류 없이 로드되는지 확인

## 4. 기능 테스트 범위
 
BAT 통과 후 세부 기능이 올바르게 동작하는지 확인하는 테스트입니다.
 
- 플레이어 이동: 좌우 이동, 점프, 이중 점프 방지, 이동 상태 확인
- 전투/공격: 투사체 생성, 피격 시 HP 감소, 사망 처리, 무적시간 적용
- UI/메뉴: StartGameText 표시/비표시, 게임 시작 중복 실행 방지, 오디오 할당 확인
- 씬 전환: TitleScreen → SampleLevel 전환, buildIndex 확인, 전환 후 Player 존재 확인
  
## 5. 자동화 전략
 
- Unity Test Framework를 사용하여 BAT 및 기능 테스트를 작성합니다.
- BAT는 씬 로드 및 필수 오브젝트 존재 여부를 Play Mode 테스트로 검증합니다.
- 기능 테스트는 실제 컴포넌트 및 게임 로직을 직접 호출하여 검증합니다.
- 오브젝트 탐색은 이름 대신 태그(`FindWithTag`)를 사용하여 이름 변경에 유연하게 대응합니다.
- 씬 로드는 `LoadSceneAsync`를 사용하여 타이밍 문제를 방지합니다.
- 테스트 결과는 GitHub Actions 및 Discord 알림과 연동합니다.

## 6. 제외 범위
 
다음 항목은 본 포트폴리오의 자동화 범위에서 제외합니다.
 
- 전체 회귀 테스트
- 그래픽/아트 품질 검수
- 사운드 품질 검수
- 조작감, 타격감 등 주관적 품질 평가
- 난이도 및 레벨 디자인 검증
- 플랫폼별 호환성 테스트
- 실제 상용 빌드 배포 검증

## 7. 기대 효과
 
BAT 자동화를 통해 신규 변경 사항 반영 후 프로젝트가 기본적으로 실행 가능한 상태인지  
빠르게 확인할 수 있습니다.
 
기능 테스트 자동화를 통해 주요 게임 기능이 의도대로 동작하는지 반복적으로 검증할 수 있으며,  
QA팀이 더 중요한 탐색적 테스트에 집중할 수 있는 환경을 만드는 것을 목표로 합니다.

또한 씬 로드 실패, 필수 오브젝트 누락, Play Mode 진입 실패, 치명적 오류 발생 여부를  
자동으로 확인하여 빌드 검증 과정의 반복 작업을 줄이는 것을 목표로 합니다.
