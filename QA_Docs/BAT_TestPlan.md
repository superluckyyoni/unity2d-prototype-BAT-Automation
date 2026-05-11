# BAT Test Plan

## 1. 목적

본 문서는 공개 Unity 2D 플랫포머 프로젝트를 대상으로,  
빌드 수락 테스트(BAT, Build Acceptance Test) 범위를 정의하고  
자동화 테스트 적용 계획을 정리하기 위해 작성되었습니다.

본 포트폴리오에서 BAT는 상세 게임 플레이 기능 검증이 아니라,  
신규 빌드 또는 프로젝트 변경 후 기본 실행 가능 여부를 빠르게 확인하는 테스트로 정의합니다.

따라서 본 포트폴리오는 전체 회귀 테스트가 아닌,  
씬 로드, Play Mode 진입, 필수 오브젝트 존재 여부, 치명적 오류 발생 여부 등  
빌드 기본 동작 검증 중심의 BAT 자동화를 목표로 합니다.

## 2. 테스트 대상

- Project: Prototype - 2D Platformer Game
- Original Repository: https://github.com/practical-works/unity2d-prototype
- Unity Version: 2022.1.10f1
- License: MIT License
- Test Framework: Unity Test Framework

## 3. BAT 범위

본 프로젝트에서는 다음과 같은 항목을 BAT 대상으로 선정합니다.

- Unity 프로젝트 기본 설정 및 버전 정보 확인
- TitleScreen 씬이 오류 없이 로드되는지 확인
- Play Mode 진입 시 예외가 발생하지 않는지 확인
- TitleScreen 씬의 필수 오브젝트가 누락되지 않았는지 확인
- SampleLevel 씬이 오류 없이 로드되는지 확인
- 주요 Staging 씬이 오류 없이 로드되는지 확인
- 씬 로드 및 Play Mode 실행 중 치명적 Error 또는 Exception 로그가 발생하지 않는지 확인

## 4. 자동화 전략

- Unity Test Framework를 사용하여 BAT 자동화 테스트를 작성합니다.
- 씬 로드, 필수 오브젝트 존재 여부, Play Mode 진입 확인은 Play Mode 테스트로 분류합니다.
- Unity 버전 및 프로젝트 설정 확인은 정적 확인 또는 문서 기반 검증 항목으로 분류합니다.
- 테스트 결과는 GitHub Actions 및 Discord 알림과 연동하는 것을 목표로 합니다.
- 이동, 점프, 적 충돌, 문/스위치 동작 등 상세 게임 플레이 기능은 기능 테스트 또는 회귀 테스트 범위로 분리합니다.

## 5. 제외 범위

다음 항목은 본 포트폴리오의 BAT 자동화 범위에서 제외합니다.

- 전체 회귀 테스트
- 이동/점프 세부 동작 검증
- 적 충돌 및 대미지 검증
- 문/스위치 동작 상세 검증
- 그래픽/아트 품질 검수
- 사운드 품질 검수
- 조작감, 타격감 등 주관적 품질 평가
- 난이도 및 레벨 디자인 검증
- 플랫폼별 호환성 테스트
- 실제 상용 빌드 배포 검증

## 6. 기대 효과

본 BAT 자동화를 통해 신규 변경 사항 반영 후  
프로젝트가 기본적으로 실행 가능한 상태인지 빠르게 확인할 수 있습니다.

또한 씬 로드 실패, 필수 오브젝트 누락, Play Mode 진입 실패, 치명적 오류 발생 여부를  
자동으로 확인하여 빌드 검증 과정의 반복 작업을 줄이는 것을 목표로 합니다.
