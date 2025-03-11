# Unity 3D Running platformGame
 
## SchoolRun
> Unity 3D로 개발한 플랫폼 게임 개발 실습 개인 프로젝트.  
> 소비 아이템 5종 캐릭터가 소비아이템을 획득하여 지긋지긋한 자신의 학교를 탈출하기 위한 모험의 여정이 구현되어 있습니다.  
> 내일배움캠프 유니티 입문 주차 팀 프로젝트 2025.03.04 ~ 2025.03.11

## 게임영상
[![동영상 설명](https://velog.velcdn.com/images/ehddud9608/post/631d9da0-432e-4887-89d8-161940ee94ec/image.png)](https://youtu.be/MPO6eOuvjVw)
## 조작
| 키 입력      | 동작    |
|-----------|-------|
| `W,S,A,D`       | 상,하, 좌, 우   |
| `SPACE`       | 점프  |
| `TAB` | 인벤토리 창 |
| `ESC` | 게임 패널 나가기 |
| `마우스 우클릭` | 아이템 상호작용 |

 ## 주요 기능
### 🎨시작화면
<img src="https://velog.velcdn.com/images/ehddud9608/post/7adbfae9-9af3-4cf4-8723-2e15842421a8/image.png" width="500">  

게임 시작시 아이템에 대한 기본적인 설명과 게임에 대한 기본적인 방향 키, 장애물, 플레이어 스텟에 대한 설명으로 게임을 시작합니다.

### 🚀게임화면
<img src="https://velog.velcdn.com/images/ehddud9608/post/96b8f2cf-b358-433b-8222-c3ff774726aa/image.png" width="500">  

게임 설명 패널을 나가고 기본적인 캐릭터와 함께 맵이 시작됩니다.

### ❤️플레이어의 상태
<img src="https://velog.velcdn.com/images/ehddud9608/post/d4d1623a-3770-49b4-a4fa-d2ac579d0d8e/image.png" width="500">

시간이 지날수록 배부름름이 사라지고, 배고픔이 0이 되는 순간부터 체력이 감소하기 시작합니다. 
<br>점프시에는 스태미나가 감소하고, 스태미나가 0이 되면 점프가 불가능하며, 시간이 지날수록 천천히 회복합니다.

### 🍔아이템과 상호작용
<img src="https://velog.velcdn.com/images/ehddud9608/post/83bfe7f6-635e-4253-8b7c-68a5ce19ad6c/image.png" width="500"> 

플레이어가 상호작용이 가능한 아이템에 가까이 있고, 마우스를 오브젝트에 드래그하게되면 Text가 출력됩니다.<br>마우스 우클릭을 통한 아이템과의 상호작용을 통해 아이템의 애니메이션 또는 소비아이템을 획득할 수 있습니다.

### 💫인벤토리 창
<img src="https://velog.velcdn.com/images/ehddud9608/post/e0135a91-3e69-4110-9c6d-319d15020b13/image.png" width="500">

획득한 아이템은 `Tab`키를 통해 아이템의 정보와 아이템 사용을 할 수 있습니다. <br>
플레이어에게 독이 되는 아이템의 경우 인벤토리에 획득할 수 없으며, 일정 시간동안 지속적인 체력감소효과가 생깁니다.

### 🏃점프패드
<img src="https://velog.velcdn.com/images/ehddud9608/post/a951fbdd-ca77-4747-bd2c-b7e87d0c873a/image.png" width="500">

표시된 패드로 점프시 `ForceMode.Impulse`를 통해서 플레이어가 가진 점프력보다 높은 점프로 다른 Ground에 도달할 수 있습니다. 
<br>플레이어에게 발판의 선택의 기회를 통해서 잘못된 발판 선택시에는 발판을 밟을때마다 체력이 감소하는 컨텐츠를 구성했습니다.


## 기술 스택
- Unity 2022.3.17f1
- C#

## 라이선스
| 에셋 이름     |출처| 라이선스        |
|-----------|---|-------------|
|School assets|https://assetstore.unity.com/packages/3d/environments/school-assets-146253| CC0|
|Character Pack: Free Sample|https://assetstore.unity.com/packages/3d/characters/humanoids/character-pack-free-sample-79870| CC0|
|UI Pack|https://www.kenney.nl/assets/ui-pack|CC0|
|Pixel Cursors|https://assetstore.unity.com/packages/2d/gui/icons/pixel-cursors-109256|CC0|




