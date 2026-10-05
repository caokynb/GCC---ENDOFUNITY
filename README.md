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
- Bối cảnh được lấy tại một thế giới tồn tại ma thuật. Nhân vật chính tên là <TÊN TỰ ĐẶT> trên hành trình đi một vòng quanh thế giới của mình. Nhưng thế giới này đầy rẫy quái vật và ma quỷ nên cậu đã học phép triệu hồi các tinh linh nguyên tố để giúp đỡ bản thân trong cuộc hành trình gian nan của mình. Vì ma lực có giới hạn nên bản thân chỉ được phép có số lượng tinh linh active nhất định, nếu vượt quá mức thì sẽ bị overdose.
## 2. Thành phần trong game
### 1. UI
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
### 2. Không phải UI
- Các tinh linh nguyên tố khác nhau (không nhiều)
- Các quái vật ma quỷ khác nhau (không nhiều luôn)
- Các cấp sao của các tinh linh (1 sao -> 3 sao)
- Các cấp sao của các quái vật ma quỷ (1 -> 4 sao)
- Đá phép. (Tiền tệ chính).
- Mana.
- HP.
## 3. Cơ chế trong game
- Level của tinh linh: Tinh linh tham gia các trận chiến và hoàn thành sẽ được tăng exp và sẽ tăng level.
- Cấp sao của tinh linh: 2 tinh linh max level ghép với nhau sẽ tăng 1 cấp sao.
- Gacha ra tinh linh: Tốn một số lượng đá phép. Mỗi lần gacha sẽ ra một số lượng tinh linh và sẽ được bỏ vào túi đồ.
- Combat:
	- Sẽ có các hệ nguyên tố (Thủy, Thổ, Hỏa, Phong). Việc combat sẽ liên quan nhiều đến việc khắc hệ với nhau.
- Qua Màn: Được thưởng đá phép và kinh nghiệm người chơi lẫn tinh linh.
- Nâng cấp nhân vật:
	- Lượng mana.
	- Tốc độ hồi mana.
	- HP.
	- Power (TẠM THỜI KHÔNG THÊM VÀO).
## 4. Progression
- Qua màn -> nâng cấp tinh linh & nhân vật -> phá đảo

