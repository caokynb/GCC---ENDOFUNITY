# GCC - ENDOFUNITY  
A 3 week solo jam for the finale of the unity course in GCC
# I. IDEA
![[Pasted image 20261005223531.png|150]]![[Pasted image 20261005223648.png|113]]![[Pasted image 20261005223712.png|160]]
-   Game được lấy ý tưởng cơ chế từ game The battle cats, El Dorado và Line Rangers.
-   Các game trên đều thuộc dạng Tower Defense. Cơ chế rất đơn giản, mỗi màn chơi có 2 tháp, tháp của mình và tháp kẻ địch, mỗi bên có 1 set nhân vật có thể triệu hồi ra bằng tài nguyên tự cộng dồn. Mục tiêu là phá được tháp kẻ địch.
-   Tại sao lại làm theo thể loại này? Tại vì em chỉ thấy khá là hứng thú với thể loại này nhưng mà các game luôn có 1 vài thứ mà khiến em không ưng ý nên em sẽ làm theo cách của em vậy!
# II. CONCEPT
## 1. Tổng quan game
-  **Title:** 
-  **Genre:** Tower Defense
-  **Art style:** 
-  **One rule:** Do not overdose
-  Bối cảnh được lấy tại một thế giới tồn tại ma thuật. Nhân vật chính tên là `<TÊN TỰ ĐẶT>` trên hành trình đi một vòng quanh thế giới của mình. Nhưng thế giới này đầy rẫy quái vật và ma quỷ nên cậu đã học phép triệu hồi các tinh linh nguyên tố để giúp đỡ bản thân trong cuộc hành trình gian nan của mình.
## 2. Thành phần trong game
### 2.1. Thành phần UI
#### Màn hình chính
-   **Chơi mới:** Đặt tên cho nhân vật.
-   **Tiếp tục:** Tiếp tục chơi (chỉ có 1 file save).
-   **Cài đặt:** Âm thanh Master, SFX, Music (nếu có).
-   **Thoát:** Thoát game.
#### Menu
-   **Bản đồ:** Có các nút chọn màn.
-   **Loadout:** Có các tinh linh khác nhau để mình chọn được loadout
    khi chiến đấu.
-   **Nút thoát:** Thoát ra ngoài màn hình chính.
#### Trong game
-   **Nút triệu hồi các tinh linh**
-   **Nút Power:** TẠM THỜI KHÔNG THÊM VÀO.
-   **Nút tạm dừng:**
    -   Tiếp tục.
    -   Thoát màn.
### 2.2. Thành phần chính trong game
#### Nhân vật chính (Tháp)
Chỉ số cơ bản:
-   HP
-   Mana
#### Quỷ (Tháp đối phương)
Chỉ số cơ bản:
-   HP
-   Mana
#### Các tinh linh nguyên tố khác nhau
- Số lượng tinh linh không nhiều.
- Chỉ số cơ bản:
	-   ELM (Element)
	-   HP
	-   ATK
	-   DEF (ATK - DEF = ATK thực tế)
	-   SPD
	-   AR (Attack Range) (Tính theo mét)
	-   AS (Attack Speed) (Attack/s)
	-   Mana cost
#### Các quái vật ma quỷ khác nhau
- Số lượng quái vật cũng không nhiều.
- Chỉ số cơ bản:
	-   ELM (Element)
	-   HP
	-   ATK
	-   DEF (ATK - DEF = ATK thực tế)
	-   SPD
	-   AR (Attack Range) (Tính theo mét)
	-   AS (Attack Speed) (Attack/s)
	-   Mana cost
#### Star Level
-   Cấp sao của các tinh linh: 1 sao -\> 3 sao.
-   Cấp sao của các quái vật ma quỷ: 1 -\> 4 sao.
#### Magic Stone
-   Đá phép.
-   Là tiền tệ chính.
## 3. Cơ chế trong game
### 3.1. Battle Field
Khi trong trận chiến:
-   Môi trường 2D gồm nhân vật chính đứng ở bên trái và 1 con quỷ đứng ở bên phải với khoảng cách tùy thuộc vào màn.
-   Con quỷ cũng có thể triệu hồi ra các con quái vật.
-   Nhiệm vụ của người chơi là tiêu diệt được quỷ (Tháp chính đối phương).
Cấu trúc cơ bản:
``` text
Player Tower                         Demon Tower
     │                                    │
     │                                    │
     ▼                                    ▼
  Spirit ────────────────────────────► Demon
```
### 3.2. Player Tower
Nhân vật chính được đại diện bởi Player Tower.
Chỉ số hiện tại:
``` text
PlayerTower {
    HP,
    Mana,
    ManaRegen
}
```
Người chơi có thể nâng cấp một số chỉ số của Player Tower.
### 3.3. Demon Tower
Demon Tower là tháp đối phương.
Chỉ số hiện tại:
``` text
DemonTower {
    HP,
    Mana,
	ManaRegen
}
```
Demon Tower có thể triệu hồi các quái vật ma quỷ trong trận chiến.
### 3.4. Spirit
Spirit là các tinh linh nguyên tố do người chơi triệu hồi.
Cấu trúc:
``` text
Spirit {
    Name,
    Element,
    HP,
    ATK,
    DEF,
    SPD,
    AttackRange,
    AttackSpeed,
    ManaCost,
    Level,
    Star
}
```
|  Thuộc tính  |          Mô tả          |
|:------------:|:-----------------------:|
|     Name     |      Tên tinh linh      |
|    Element   |       Hệ nguyên tố      |
|      HP      |           Máu           |
|      ATK     |        Sát thương       |
|      DEF     |        Phòng thủ        |
|      SPD     |          Tốc độ         |
| Attack Range | Tầm đánh, tính theo mét |
| Attack Speed |   Số lần tấn công/giây  |
|   Mana Cost  |  Mana cần để triệu hồi  |
|     Level    |   Cấp độ của tinh linh  |
|     Star     |  Cấp sao của tinh linh  |
### 3.5. Demon
Demon là các quái vật do Demon Tower triệu hồi.
Cấu trúc:
``` text
Demon {
    Name,
    Element,
    HP,
    ATK,
    DEF,
    SPD,
    AttackRange,
    AttackSpeed,
    ManaCost,
    Star
}
```
|  Thuộc tính  |         Mô tả        |
|:------------:|:--------------------:|
|     Name     |     Tên quái vật     |
|    Element   |     Hệ nguyên tố     |
|      HP      |          Máu         |
|      ATK     |      Sát thương      |
|      DEF     |       Phòng thủ      |
|      SPD     |        Tốc độ        |
| Attack Range |       Tầm đánh       |
| Attack Speed | Số lần tấn công/giây |
|   Mana Cost  |   Mana cần để spawn  |
|     Star     |        Cấp sao       |
### 3.6. Mana System
Mana là tài nguyên được sử dụng để triệu hồi Spirit.
Player có:
-   Mana hiện tại.
-   Lượng Mana tối đa.
-   Tốc độ hồi Mana.
Mana được tự động cộng dồn theo thời gian.
Cấu trúc:
``` text
Mana System {
    CurrentMana,
    MaxMana,
    ManaRegen
}
```
Khi người chơi triệu hồi Spirit:
``` text
Current Mana >= Spirit Mana Cost
        │
        ▼
    Summon Spirit
        │
        ▼
Current Mana -= Spirit Mana Cost
```
Nếu Mana không đủ thì Spirit không được triệu hồi.
### 3.7. Spirit Summoning
Người chơi sử dụng các nút triệu hồi trong Battle UI để đưa Spirit vào chiến trường.
Điều kiện cơ bản:
``` text
Current Mana >= Mana Cost
```
Nếu đủ Mana:
``` text
Mana = Mana - Mana Cost
Spawn Spirit
```
Nếu không đủ Mana:
``` text
Unspawnable
```
Đạt giới hạn số lượng Spirit active không làm nút triệu hồi bị khóa.
Người chơi vẫn có thể triệu hồi và kích hoạt Overdose.
### 3.8. Combat
Spirit và Demon chiến đấu với nhau trên chiến trường.
Các chỉ số ảnh hưởng tới combat:
-   HP
-   ATK
-   DEF
-   SPD
-   Attack Range
-   Attack Speed
-   Element
Theo thiết kế hiện tại:
``` text
Effective ATK = ATK - DEF
```
Sau đó áp dụng modifier của hệ nguyên tố.
Flow:
``` text
ATK
 │
 ▼
ATK - Target DEF
 │
 ▼
Element Modifier
 │
 ▼
Final Damage
```
### 3.9. Element System
Sẽ có các hệ nguyên tố:
-   Thủy
-   Hỏa
-   Mộc
Việc combat sẽ liên quan nhiều đến việc khắc hệ với nhau.
Quan hệ khắc hệ:
``` text
Thủy > Hỏa
Hỏa > Mộc
Mộc > Thủy
```
Nếu hệ tấn công khắc chế mục tiêu:
``` text
ATK × 1.10
```
Nếu hệ tấn công bị khắc chế:
``` text
ATK × 0.8
```
Nếu không có quan hệ khắc chế:
``` text
ATK × 1.0
```
Bảng hệ:

| Hệ tấn công | Khắc chế | Bị khắc chế |
|:-----------:|:--------:|:-----------:|
|     Thủy    |    Hỏa   |     Mộc     |
|     Hỏa     |    Mộc   |     Thủy    |
|     Mộc     |   Thủy   |     Hỏa     |

### 3.10. Overdose System
Overdose là cơ chế đặc trưng của game.
Player chỉ có được một số lượng Spirit active trên chiến trường nhất định.
Tuy nhiên, nút triệu hồi vẫn luôn có thể bấm được.
Nếu số lượng Spirit vượt quá giới hạn:
``` text
Current Active Spirit > Active Spirit Limit
```
thì người chơi bị Overdose.
#### Overdose Effect 1 - HP Drain
Player Tower bị drain HP liên tục:
``` text
HP Drain = 0.2% Max HP / second
```
#### Overdose Effect 2 - Spirit Stat Penalty
Tất cả các chỉ số của Spirit bị giảm theo từng Spirit vượt quá giới hạn:
``` text
Mỗi Spirit vượt giới hạn:
×0.975
```
Penalty được cộng dồn.
Ví dụ:
``` text
+1 Spirit → ×0.975
+2 Spirits → ×0.975²
+3 Spirits → ×0.975³
v.v
```
Flow:
``` text
Check Active Spirits
        │
        ▼
Current > Limit?
   │           │
  No          Yes
   │           │
   ▼           ▼
 Normal    Calculate Excess
               │
        ┌──────┴──────┐
        ▼             ▼
    HP Drain     Stat Penalty
   0.2% MaxHP/s   ×0.975 / extra Spirit
```
### 3.11. Demon Spawn
Mỗi màn thì Demon cũng có một set quái vật để spawn.
Demon spawn theo ưu tiên:
1.  Rẻ nhất.
2.  Đang không trong cooldown.
Flow:
``` text
Get Demon Set
      │
      ▼
Filter Demon
not in Cooldown
      │
      ▼
Sort by Mana Cost
      │
      ▼
Select Cheapest
      │
      ▼
Spawn Demon
```
### 3.12. Win / Lose
#### Win
Người chơi chiến thắng khi phá được "Tháp" đối phương.
``` text
Demon Tower HP <= 0
```
Sau khi qua màn:
-   Được thưởng đá phép.
-   Người chơi nhận kinh nghiệm.
-   Các tinh linh nhận kinh nghiệm.
#### Lose
Người chơi thua khi:
``` text
Player Tower HP <= 0
```
### 3.13. In Game Loop
``` text
Start Level
    │
    ▼
Initialize Player Tower
Initialize Demon Tower
    │
    ▼
Start Mana Generation
    │
    ▼
┌───────────────────────┐
│      Battle Loop      │
│                       │
│  Generate Mana        │
│       ↓               │
│  Player Summons       │
│       ↓               │
│  Demon Spawns         │
│       ↓               │
│  Units Move           │
│       ↓               │
│  Units Attack         │
│       ↓               │
│  Check Overdose       │
│       ↓               │
│  Check Tower HP       │
└───────────┬───────────┘
            │
       ┌────┴────┐
       ▼         ▼
 Player HP    Demon HP
   <= 0         <= 0
       │         │
       ▼         ▼
     Lose       Win
```
## 4. Progression
### 4.1. Spirit Level
Tinh linh tham gia các trận chiến và hoàn thành sẽ được tăng EXP và sẽ
tăng level.
Flow:
``` text
Battle Completed
       │
       ▼
Spirit EXP Reward
       │
       ▼
EXP >= Required EXP?
       │
       ├── No → Keep Current Level
       │
       └── Yes
             │
             ▼
        Spirit Level Up
```
### 4.2. Spirit Star
Tinh linh max level sẽ có thể được tăng cấp sao bằng lượng lớn đá phép.
Spirit có:
``` text
1 Star → 2 Star → 3 Star
```
Điều kiện:
``` text
Spirit Max Level
       +
Required Magic Stones
       │
       ▼
    Star Up
```
### 4.3. Player Upgrade
Các chỉ số có thể nâng cấp:
-   Lượng Mana.
-   Tốc độ hồi Mana.
-   HP.
-   Power - TẠM THỜI KHÔNG THÊM VÀO.
Cấu trúc:
``` text
PlayerUpgrade {
    MaxMana,
    ManaRegen,
    HP,
    // Power
}
```
### 4.4. Player Progression
Progression chính:
``` text
Qua màn
   ↓
Nhận EXP + Magic Stone
   ↓
Nâng cấp Spirit
   ↓
Nâng cấp nhân vật
   ↓
Đánh màn tiếp theo
   ↓
Phá đảo
```
# III. GAME ELEMENTS
## 1. Player Tower
Player Tower là tháp của người chơi.
``` text
PlayerTower {
    HP,
    Mana,
    MaxMana,
    ManaRegen,
    ActiveSpiritLimit,
    Upgrades[]
}
```

|       Property      |                     Description                     |
|:-------------------:|:---------------------------------------------------:|
|          HP         |              Lượng máu của Player Tower             |
|         Mana        |                    Mana hiện tại                    |
|       Max Mana      |                     Mana tối đa                     |
|      Mana Regen     |                   Tốc độ hồi Mana                   |
| Active Spirit Limit | Số lượng Spirit được phép active trước khi Overdose |
|       Upgrades      |               Các nâng cấp của Player               |
## 2. Demon Tower
``` text
DemonTower {
    HP,
    Mana,
    MaxMana,
    ManaRegen,
    DemonSet[]
}
```

|  Property  |           Description           |
|:----------:|:-------------------------------:|
|     HP     |    Lượng máu của Demon Tower    |
|    Mana    |       Mana của Demon Tower      |
|  Max Mana  |           Mana tối đa           |
| Mana Regen |         Tốc độ hồi Mana         |
|  Demon Set | Các Demon mà Tower có thể spawn |
## 3. Spirit
``` text
Spirit {
    Name,
    Element,
    HP,
    ATK,
    DEF,
    SPD,
    AttackRange,
    AttackSpeed,
    ManaCost,
    Level,
    Star
}
```
Spirit là đơn vị chiến đấu chính của người chơi.
## 4. Demon
``` text
Demon {
    Name,
    Element,
    HP,
    ATK,
    DEF,
    SPD,
    AttackRange,
    AttackSpeed,
    ManaCost,
    Star
}
```
Demon là đơn vị chiến đấu do Demon Tower spawn.
## 5. Element
``` text
Element {
    Water,
    Fire,
    Wood
}
```
Quan hệ:
``` text
Water > Fire
Fire > Wood
Wood > Water
```
Modifier:
``` text
Strong → ×1.25 ATK
Weak   → ×0.8 ATK
Neutral → ×1.0 ATK
```
## 6. Overdose
``` text
Overdose {
    ActiveSpiritLimit,
    HPDrain = 0.2% MaxHP/s,
    StatMultiplier = 0.975
}
```
Mỗi Spirit vượt quá giới hạn tạo thêm một lần `×0.975` lên các chỉ số của
Spirit.
## 7. Magic Stone
Magic Stone là tiền tệ chính của game.
Được dùng cho progression, đặc biệt là tăng Star của Spirit.
# IV. LEVELS
## 1. Level Structure
Mỗi level bao gồm:
``` text
Level {
    PlayerTower,
    DemonTower,
    TowerDistance,
    DemonSet[],
    Reward
}
```

|    Property    |         Description        |
|:--------------:|:--------------------------:|
|  Player Tower  |      Căn cứ người chơi     |
|   Demon Tower  |      Căn cứ đối phương     |
| Tower Distance | Khoảng cách giữa hai Tower |
|    Demon Set   |  Danh sách Demon của level |
|     Reward     |    Phần thưởng khi thắng   |
## 2. Demon Configuration
Mỗi màn có một set Demon riêng.
``` text
Level 01
 └── Demon Set
      ├── Demon A
      ├── Demon B
      └── Demon C
```
Demon được lựa chọn theo:
``` text
Not in Cooldown
        ↓
Cheapest Mana Cost
        ↓
Spawn
```
## 3. Level Progression
``` text
Level 1
  ↓
Level 2
  ↓
Level 3
  ↓
...
  ↓
Final Level
```
Số lượng level cụ thể: `[To Be Determined]`.
# V. ECONOMY
## 1. Magic Stone
Magic Stone là tiền tệ chính.
### Sources
``` text
Complete Level
      │
      ▼
Receive Magic Stone
```
### Uses
``` text
Magic Stone
    │
    ├──► Spirit Star Up
    │
    └──► Other Upgrades
```
## 2. Battle Reward
Sau khi thắng:
``` text
Victory
  │
  ├──► Magic Stone
  ├──► Player EXP
  └──► Spirit EXP
```
Số lượng cụ thể: `[TBD]`.
## 3. Upgrade Cost
Chi phí nâng cấp cụ thể chưa được xác định.
``` text
UpgradeCost {
    UpgradeType,
    CurrentLevel,
    RequiredMagicStone
}
```
# VI. UI / UX
## 1. Main Menu
``` text
Main Menu
├── Chơi mới
├── Tiếp tục
├── Cài đặt
└── Thoát
```
### Chơi mới
-   Đặt tên cho nhân vật.
-   Tạo save mới.
### Tiếp tục
-   Tiếp tục từ file save.
-   Chỉ có 1 file save.
### Cài đặt
-   Master
-   SFX
-   Music
### Thoát
-   Thoát game.
## 2. Game Menu
``` text
Game Menu
├── Bản đồ
├── Loadout
└── Thoát
```
## 3. Map
Có các nút để lựa chọn màn.
## 4. Loadout
Cho phép lựa chọn các Spirit trước khi chiến đấu.
``` text
Owned Spirits
      │
      ▼
Select Spirits
      │
      ▼
Create Loadout
      │
      ▼
Start Battle
```
Số lượng Spirit tối đa trong Loadout: `5`.
## 5. Battle UI
Thành phần:
-   Nút triệu hồi Spirit.
-   Mana.
-   Player HP.
-   Demon Tower HP.
-   Nút Pause.
-   Nút Power --- TẠM THỜI KHÔNG THÊM VÀO.
## 6. Pause Menu
``` text
Pause
├── Tiếp tục
└── Thoát màn
```
# VII. GAME FLOW
``` text
                    START
                      │
                      ▼
                 Main Menu
                      │
          ┌───────────┼───────────┐
          ▼           ▼           ▼
      New Game     Continue     Settings
          │           │
          ▼           ▼
      Character      Load Save
        Name           │
          └──────┬─────┘
                 ▼
             Game Menu
                 │
          ┌──────┴──────┐
          ▼             ▼
         Map         Loadout
          │             │
          └──────┬──────┘
                 ▼
             Select Level
                 │
                 ▼
            Start Battle
                 │
                 ▼
          Generate Mana
                 │
                 ▼
         Summon / Spawn
                 │
                 ▼
               Combat
                 │
          ┌──────┴───────┐
          ▼              ▼
   Enemy Tower HP    Player Tower HP
       <= 0              <= 0
          │                 │
          ▼                 ▼
        Victory            Defeat
          │
          ▼
     Receive Rewards
          │
     ┌────┴────┐
     ▼         ▼
 Player EXP  Spirit EXP
     │         │
     └────┬────┘
          ▼
    Upgrade / Progress
          │
          ▼
      Next Level
```
# VIII. SAVE DATA
Game hiện tại sử dụng **1 file save**.
Cấu trúc dự kiến:
``` text
PlayerData {
    PlayerName,
    CurrentLevel,
    MagicStone,
    PlayerUpgrades[],
    SpiritData[]
}
```
Trong đó:

|      Data      |        Description       |
|:--------------:|:------------------------:|
|   PlayerName   |       Tên nhân vật       |
|  CurrentLevel  |       Màn hiện tại       |
|   MagicStone   |     Số lượng đá phép     |
| PlayerUpgrades |    Các nâng cấp Player   |
|   SpiritData   | Level và Star của Spirit |

Các chi tiết Save System: `...`.
# IX. DEVELOPMENT SCOPE
## 1. MVP
### Core Gameplay
-   Player Tower
-   Demon Tower
-   Spirit
-   Demon
-   Mana
-   Summoning
-   Movement
-   Combat
-   Damage
-   Element
-   Overdose
-   Win / Lose
### Progression
-   Spirit EXP
-   Spirit Level
-   Spirit Star
-   Magic Stone
-   Player Upgrade
### UI
-   Main Menu
-   Map
-   Loadout
-   Battle UI
-   Pause Menu
# X. CORE SYSTEM SUMMARY
Project tập trung vào 4 hệ thống chính:
### 1. Summon
Dùng Mana để triệu hồi Spirit.
### 2. Combat
Spirit và Demon tự động chiến đấu, với Element tạo lợi thế hoặc bất lợi.
### 3. Overdose
Người chơi có thể vượt giới hạn Spirit để tạo áp lực chiến đấu lớn hơn,
nhưng phải đánh đổi bằng HP của Player Tower và hiệu suất của Spirit.
### 4. Progression
``` text
Win Level
    ↓
EXP + Magic Stone
    ↓
Upgrade Spirit / Player
    ↓
Next Level
    ↓
Win Again
    ↓
Complete Game
```
1 Rule: DO NOT OVERDOSE.**