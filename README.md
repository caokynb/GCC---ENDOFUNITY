# GCC - ENDOFUNITY
A 3 week solo jam for the finale of the Unity course in GCC

# I. IDEA
![[Pasted image 20261005223531.png|150]]![[Pasted image 20261005223648.png|113]]![[Pasted image 20261005223712.png|160]]
- Game lấy cảm hứng từ cơ chế của The Battle Cats, El Dorado và Line Rangers.
- Đây là game tower defense 2D: hai tháp ở hai đầu chiến trường triệu hồi unit bằng mana; unit tự di chuyển và chiến đấu. Người chơi thắng khi phá hủy tháp đối phương.
- Hướng phát triển hiện tại kết hợp vòng chiến đấu theo round với lựa chọn nâng cấp sau mỗi round thắng, lấy cảm hứng từ Vampire Survivors.
- Mục tiêu là giữ vòng chơi dễ hiểu, tập trung vào chiến đấu, triệu hồi và lựa chọn nâng cấp có tác động rõ ràng.

# II. CONCEPT
## 1. Tổng quan game
- **Title:** CTID (Center of Tower innovation and Defenses)
- **Genre:** Tower Defense kết hợp run-based upgrade progression
- **Art style:** Pixel
- **One rule:** Do not overdose
- **Bối cảnh:** Trong một thế giới có ma thuật, nhân vật chính triệu hồi các tinh linh nguyên tố để chiến đấu với quỷ và các thế lực đối địch trong hành trình của mình.

## 2. Thành phần trong game
### Người chơi và Player Tower
Player Tower là căn cứ của người chơi. Các chỉ số chính:
- HP tối đa và HP hiện tại
- Mana tối đa, mana hiện tại và tốc độ hồi mana

### Demon Tower
Demon Tower là căn cứ đối phương. Các chỉ số chính:
- HP tối đa và HP hiện tại
- Mana tối đa, mana hiện tại và tốc độ hồi mana

### Spirit và Demon
Spirit là unit do người chơi triệu hồi; Demon là unit do Demon Tower triệu hồi. Cả hai dùng chung nhóm chỉ số chiến đấu:
- Element
- HP
- Attack
- Defense
- Speed
- Attack Range
- Attack Speed
- Mana Cost

### Hướng tổ chức unit
- Spirit và Demon dùng chung UnitBase, StateMachine và các state chung như di chuyển, tấn công, chết.
- Mỗi unit có instance FSM riêng tại runtime để lưu state hiện tại, target và dữ liệu của chính unit đó.
- Animator và animation clip được cấu hình theo prefab; FSM chỉ gửi các tín hiệu animation chung.

## 3. Round Upgrade
Sau mỗi round thắng, người chơi chọn một trong sáu nâng cấp cố định. Các lựa chọn không được rút ngẫu nhiên từ pool:
- **Unit Damage:** tăng Attack của tất cả Spirit người chơi thêm 2% chỉ số gốc.
- **Unit Movement Speed:** tăng Speed của tất cả Spirit người chơi thêm 2% chỉ số gốc.
- **Unit HP:** tăng HP của tất cả Spirit người chơi thêm 2% chỉ số gốc.
- **Unit Defense:** tăng Defense của tất cả Spirit người chơi thêm 2% chỉ số gốc.
- **Player Tower Max Mana:** tăng Mana tối đa của Player Tower thêm 2% chỉ số gốc.
- **Player Tower Mana Regen:** tăng tốc độ hồi Mana của Player Tower thêm 2% chỉ số gốc.

Mỗi lần chọn cùng một nâng cấp sẽ cộng thêm 2% chỉ số gốc tương ứng. Nâng cấp đã chọn được giữ và cộng dồn trong các round tiếp theo của cùng một run. Nâng cấp chỉ số unit áp dụng cho Spirit đang hoạt động và Spirit được triệu hồi sau đó. Các nâng cấp unit không áp dụng cho Demon; Demon và Demon Tower tăng chỉ số theo Enemy Scaling.

## 4. Element System
Các hệ nguyên tố hiện có:
- Thủy
- Hỏa
- Mộc

Quan hệ khắc hệ:
```text
Thủy > Hỏa
Hỏa > Mộc
Mộc > Thủy
```

- Tấn công khắc chế mục tiêu: sát thương nhân `1.10`.
- Tấn công bị khắc chế: sát thương nhân `0.8`.
- Không có quan hệ khắc chế: sát thương nhân `1.0`.

| Hệ tấn công | Khắc chế | Bị khắc chế |
|:-----------:|:--------:|:-----------:|
| Thủy | Hỏa | Mộc |
| Hỏa | Mộc | Thủy |
| Mộc | Thủy | Hỏa |

## 5. Overdose System
Overdose là cơ chế đánh đổi đặc trưng của game. Người chơi có giới hạn số Spirit hoạt động, nhưng vẫn có thể triệu hồi vượt giới hạn.

Khi số Spirit đang hoạt động lớn hơn giới hạn:
- Player Tower mất HP theo thời gian.
- Sát thương của Spirit bị giảm theo số unit vượt giới hạn.

```text
Số Spirit vượt giới hạn = Current Spirits - Spirit Limit
```

Công thức và mức phạt cụ thể được cân bằng trong game. Quy tắc thiết kế: Overdose đem lại thêm sức mạnh chiến đấu nhưng tạo nguy cơ khiến Player Tower bị phá hủy.

## 6. Combat
Spirit và Demon tự động di chuyển, tìm mục tiêu trong tầm đánh và tấn công.

Sát thương cơ bản:
```text
Damage = max(1, (Attack × Element Modifier) - Target Defense)
```

| Chỉ số | Tác dụng |
|:------|:---------|
| HP | Lượng sát thương unit chịu được trước khi bị hạ |
| Attack | Sát thương cơ bản gây ra |
| Defense | Giảm sát thương nhận vào |
| Speed | Tốc độ di chuyển |
| Attack Range | Khoảng cách có thể tấn công |
| Attack Speed | Nhịp tấn công |
| Element | Điều chỉnh sát thương theo quan hệ khắc hệ |

## 7. Mana và Summoning
Mana được tự động hồi theo thời gian và dùng để triệu hồi unit.

Điều kiện triệu hồi:
```text
Current Mana >= Unit Mana Cost
```

Khi triệu hồi thành công, mana bị trừ theo Mana Cost của unit. Nếu mana không đủ, unit không được triệu hồi. Vượt giới hạn Spirit hoạt động vẫn có thể triệu hồi và kích hoạt Overdose.

## 8. Demon Spawn
Demon Tower tự triệu hồi các Demon thuộc danh sách của round. Chỉ Demon đang đủ điều kiện và không trong cooldown mới được chọn. Ưu tiên Demon có Mana Cost thấp nhất trong số các lựa chọn hợp lệ.

```text
Lấy danh sách Demon của round
→ Lọc Demon đủ điều kiện và hết cooldown
→ Chọn Demon có Mana Cost thấp nhất
→ Trừ mana và triệu hồi
```

# III. ROUND STRUCTURE AND DIFFICULTY
## 1. Round Structure
Mỗi round là một trận chiến hoàn chỉnh, gồm:
```text
Round {
    Player Tower,
    Demon Tower,
    Tower Distance,
    Demon Set,
    Enemy Scaling
}
```

- **Player Tower:** Căn cứ của người chơi.
- **Demon Tower:** Căn cứ đối phương.
- **Tower Distance:** Khoảng cách giữa hai tháp.
- **Demon Set:** Danh sách Demon có thể được triệu hồi trong round.
- **Enemy Scaling:** Hệ số điều chỉnh độ khó theo round.

## 2. Round Progression
Các round được chơi nối tiếp trong cùng một run:
```text
Round 1 → Round 2 → Round 3 → ...
```

Số round và điều kiện kết thúc run: `[To Be Determined]`.

## 3. Enemy Scaling
Độ khó của Demon và Demon Tower tăng theo round. Các chỉ số có thể scale gồm HP, Attack, Defense, Mana hoặc tần suất triệu hồi.

Scaling được áp dụng lên chỉ số runtime khi bắt đầu round; dữ liệu gốc của unit không bị thay đổi. Mức tăng cụ thể cần được cân bằng để độ khó tăng đều và người chơi có thể ứng phó bằng các lựa chọn nâng cấp.

# IV. GAME FLOW
```text
START
  ↓
Main Menu
  ↓
Start Run
  ↓
Initialize Round
  ├─ Initialize Player Tower and current run upgrades
  ├─ Initialize Demon Tower and round scaling
  └─ Load Demon Set
  ↓
Battle
  ├─ Generate Mana
  ├─ Player Summons Spirit
  ├─ Demon Tower Spawns Demon
  ├─ Units Move and Fight
  ├─ Check Overdose
  └─ Check Tower HP
       ├─ Player Tower HP <= 0 → Defeat / End Run
       └─ Demon Tower HP <= 0 → Round Victory
                                  ↓
                        Show 6 Fixed Upgrade Choices
                                  ↓
                          Choose 1 Upgrade
                                  ↓
                           Start Next Round
```

# V. RUN DATA
Run data cần được giữ giữa các round để các nâng cấp đã chọn tiếp tục có hiệu lực.

Dữ liệu tối thiểu trong một run:
```text
RunData {
    CurrentRound,
    SelectedUpgrades,
    PlayerTowerStats
}
```

Cách lưu run khi thoát game và hệ thống Continue: `[To Be Determined]`.

# VI. DEVELOPMENT SCOPE
## 1. Core Gameplay
- Player Tower và Demon Tower
- Spirit và Demon
- Mana và hồi mana
- Triệu hồi Spirit và tự động spawn Demon
- Di chuyển, tìm mục tiêu và chiến đấu
- Damage, Defense và Element
- Overdose
- Điều kiện thắng/thua round

## 2. Round Progression
- Khởi tạo round và danh sách Demon tương ứng
- Tăng độ khó enemy theo round
- Hiển thị sáu lựa chọn nâng cấp cố định sau khi thắng
- Chọn một nâng cấp và giữ hiệu lực qua các round trong run
- Áp dụng nâng cấp đã chọn cho Spirit đang hoạt động và Spirit được triệu hồi về sau
- Kết thúc run khi người chơi thua hoặc hoàn thành round cuối

## 3. UI
- Main Menu
- Battle UI: HP, mana, nút triệu hồi và thông tin cần thiết trong trận
- Upgrade Selection sau round thắng
- Kết quả thắng/thua
- Pause Menu

# VII. CORE SYSTEM SUMMARY
Game tập trung vào bốn hệ thống:
### 1. Summoning
Người chơi dùng mana để triệu hồi Spirit; Demon Tower tự triệu hồi Demon.
### 2. Combat
Unit tự di chuyển và chiến đấu. Element tạo lợi thế hoặc bất lợi về sát thương.
### 3. Overdose
Người chơi có thể vượt giới hạn Spirit để tăng quân số, đổi lại Player Tower mất HP và Spirit bị giảm sát thương.
### 4. Round Upgrades
Sau mỗi round thắng, người chơi chọn một trong sáu nâng cấp cố định: Spirit Damage, Movement Speed, HP, Defense, Player Tower Max Mana hoặc Player Tower Mana Regen. Mỗi lần chọn tăng thêm 2% chỉ số gốc tương ứng; nâng cấp cộng dồn trong run.

**One rule: DO NOT OVERDOSE.**
