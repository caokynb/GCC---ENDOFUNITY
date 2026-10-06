# GCC - ENDOFUNITY
A 3 week solo jam for the finale of the unity course in GCC

# I. IDEA
- Game được lấy ý tưởng cơ chế từ game The battle cats, El Dorado và Line Rangers.
![[Pasted image 20261005223531.png|176]]![[Pasted image 20261005223648.png|132]]![[Pasted image 20261005223712.png|187]]

- Các game trên đều thuộc dạng Tower Defense. Cơ chế rất đơn giản, mỗi màn chơi có 2 tháp, tháp của mình và tháp kẻ địch, mỗi bên có 1 set nhân vật có thể triệu hồi ra bằng tài nguyên tự cộng dồn. Mục tiêu là phá được tháp kẻ địch. Ngoài ra còn có các chế độ khác... Vấn đề khó nhất là power scaling.
- Tại sao lại làm theo thể loại này? Tại vì em chỉ thấy khá là hứng thú với thể loại này nhưng mà các game luôn có 1 vài thứ mà khiến em không ưng ý nên em sẽ làm theo cách của em vậy!
# II. Concept
## 1. Tổng quan game
- Title: 
- Genre: Tower Defense
- Đồ họa: 
- One rule: Do not overdose
- Bối cảnh được lấy tại một thế giới tồn tại ma thuật. Nhân vật chính tên là <TÊN TỰ ĐẶT> trên hành trình đi một vòng quanh thế giới của mình. Nhưng thế giới này đầy rẫy quái vật và ma quỷ nên cậu đã học phép triệu hồi các tinh linh nguyên tố để giúp đỡ bản thân trong cuộc hành trình gian nan của mình.
## 2. Thành phần trong game
### 1. Thành phần UI
- Màn hình chính:
	- Chơi mới: Đặt tên cho nhân vật.
	- Tiếp tục: Tiếp tục chơi (chỉ có 1 file save).
	- Cài đặt: Âm thanh Master, SFX, Music (nếu có).
	- Thoát: Thoát game.
- Menu:
	- Bản đồ: Có các nút chọn màn.
	- Loadout: Có các tinh linh khác nhau để mình chọn được loadout khi chiến đấu.
	- Nút thoát: Thoát ra ngoài màn hình chính.
- Trong game:
	- Nút triệu hồi các tinh linh: <-
	- Nút power: TẠM THỜI KHÔNG THÊM VÀO.
	- Nút tạm dừng:
		- Tiếp tục.
		- Thoát màn.
### 2. Thành phần tương tác trong game
- Nhân vật chính (Tháp)
	- Chỉ số cơ bản gồm:
		- HP
		- Mana 
- Quỷ (Tháp đối phương)
	- Chỉ số cơ bản gồm:
		- HP
		- Mana
- Các tinh linh nguyên tố khác nhau (không nhiều)
	- Chỉ số cơ bản gồm:
		- ELM (Element)
		- HP
		- ATK
		- DEF (ATK - DEF = ATK thực tế)
		- SPD
		- AR (Attack Range) (Tính theo mét)
		- AS (Attack Speed) (Attack/s)
		- Mana cost
- Các quái vật ma quỷ khác nhau (không nhiều luôn)
	- Chỉ số cơ bản  gồm:
		- ELM (Element)
		- HP
		- ATK
		- DEF (ATK - DEF = ATK thực tế)
		- SPD
		- AR (Attack Range) (Tính theo mét)
		- AS (Attack Speed) (Attack/s)
		- Mana cost
- Các cấp sao của các tinh linh (1 sao -> 3 sao)
- Các cấp sao của các quái vật ma quỷ (1 -> 4 sao)
- Đá phép. (Tiền tệ chính).
## 3. Cơ chế trong game
- Khi trong trận chiến:
	- Môi trường 2D gồm nhân vật chính đứng ở bên trái và 1 con quỷ đứng ở bên phải với khoảng cách tùy thuộc vào màn. Con quỷ cũng có thể triệu hồi ra các con quái vật.
	- Nhiệm vụ của người chơi là tiêu diệt được quỷ (Tháp chính đối phương).
	- Về nhân vật chính:
		- Chỉ có được số lượng tinh linh active trên chiến trường nhất định. Nếu không thì bị overdose (nút triệu hồi vẫn luôn bấm được).
		- Overdose: Khi vượt quá số lượng tinh linh cho phép thì sẽ bị drain hp liên tục (0.2% Max HP/s) và x0.95 (Cộng dồn với mỗi tinh linh ngoài phạm vi cho phép) với tất cả các chỉ số của tinh linh.
- Về tinh linh:
	- Level của tinh linh: Tinh linh tham gia các trận chiến và hoàn thành sẽ được tăng exp và sẽ tăng level.
	- Cấp sao của tinh linh: Tinh linh max level sẽ có thể được tăng cấp sao bằng lượng lớn đá phép.
- Combat:
	- Sẽ có các hệ nguyên tố (Thủy, Hỏa, Mộc). Việc combat sẽ liên quan nhiều đến việc khắc hệ với nhau. (Hệ bị khắc chế thì x0.8 ATK) (Hệ khắc chế thì x1.25 ATK)
		- Thủy > Hỏa
		- Hỏa > Mộc
		- Mộc > Thủy
	- Qua Màn: Phá được "Tháp" đối phương -> Được thưởng đá phép và kinh nghiệm người chơi lẫn tinh linh.
	- Thua: Nhân vật chính hết HP.
	- Cơ chế spawn quái vật của quỷ:
		- Mỗi màn thì quỷ cũng có 1 set quái vật để spawn.
		- Quỷ spawn theo ưu tiên: Rẻ nhất > Đang không trong cooldown.
- Nâng cấp nhân vật:
	- Các chỉ số có thể nâng cấp:
		- Lượng mana.
		- Tốc độ hồi mana.
		- HP.
		- Power (TẠM THỜI KHÔNG THÊM VÀO).
## 4. Progression
- Qua màn -> nâng cấp tinh linh & nhân vật -> phá đảo

