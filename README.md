# VR을 이용한 블록코딩 프로젝트 (두근두근 블록코딩)
![img4](https://github.com/zigoom/PortfolioPage/assets/24885296/c9d6f73a-4228-4192-917c-acedf61bdb49)


### 1. 개발 목표  
&nbsp;&nbsp;&nbsp;   VR 환경에서 쉽게 코딩에 관심을 가질 수 있는 콘텐츠 제작     
<br/>
### 2. 개발환경 및 도구  
  - **소스 관리 -**  Github  
  - **일정 관리 -**  Trello  
  - **시용 디바이스 -**  Oculus Quest 1   
  - **Unity -** 2019.4.1f Ver 
  - **IDE -** visual studio community 2019  
  - **그래픽 툴 -** Aseprite, Magicavoxel  
<br/>

### 4. 콘텐츠 개발 시나리오  
  1. 컨트롤러를 이용하여 코드블록을 땅에서 들어올려서 대포에 삽입.
  2. 삽입한 코드블록은 UI에 리스트로 표시해 주며 잘못 넣으면 삭제를 해주어서 순서를 완성 후 장전을 해준다.
  3. 대포 앞에 토끼 캐릭터를 조준한 다음에 코드 블록을 맞혀서 알맞은 행동을 유도한다.
  4. 토끼의 행동에 따라서 성공/실패의 결과를 보여주고, '다음 스테이지' / '다시하기' 가 나타난다.  
<br/>
  
### 3. 팀프로젝트 역활   
  - 명령어를 가진 야채 블록을 땅에 유지시키는 상태 구현  <br/>  
![image](https://github.com/zigoom/BlockCoding/assets/24885296/c3abc138-9a8b-43dc-826e-167e0ac8077f)  
    - 당근의 하위에 빈 객체를 하나 추가하여 Collider를 추가하여, 2개의 Collider 를 사용하여 바닥과의 물리작용을 없애서 땅에 박히는 것처럼 보여주도록 처리33d5420b9)
![image](https://github.com/zigoom/BlockCoding/assets/24885296/c078cfc1-6601-44e5-b012-cedd3ad33556)  <br/><br/>  

  - 코드 블록을 리스트 방식으로 저장/삭제 기능 구현  <br/>  
    ![image](https://github.com/zigoom/BlockCoding/assets/24885296/a68feb20-4c72-46d8-8dff-c1416232b8a3)  

    - 코드불록 입력 순서  
      1. 밭에서 블록을 집어서 대포에 충돌시킨다.
      2. 대포에서 코드블록의 태그를 기준으로 어떤 명령어를 집어넣을지 정한다.
      3. 이때 입력하는 조건으로 탄창이 가득 차지 않으며 장전이 안된 상태여야 한다.
      4. 코드의 저장 방식은 List를 사용하여 중간에 삭제 시 순서가 당겨진다.
      5. 저장된 코드는 UI 형태로 표시하며, 해당 UI를 누를 경우 리스트 삭제와
     UI 재배열이 일어난다.  
<br/>  

  - 애체 블록을 발사하기 위한 곡선 및 UI 구현
      
    ![image](https://github.com/zigoom/BlockCoding/assets/24885296/1391d3d8-a1b9-48f8-9662-5ca7d971aaa5)  
    ![image](https://github.com/zigoom/BlockCoding/assets/24885296/8d75214c-4651-4818-b298-9d3772c2d225)  
<br/>
  

