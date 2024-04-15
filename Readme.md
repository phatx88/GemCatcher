Video Demo : https://youtu.be/oRuUetA6m_M
Expasion Features Checklist:
- Nhân vật bây giờ có thể Nhảy để thu thập viên ngọc nhanh hơn
- Thay đổi diện mạo trò chơi: đất, trời, nhân vật và cả viên ngọc
  - dropdown để thay đổi sprite của các GameObject đã tag:
  - Ground : ![tile_0005 1](https://github.com/phatx88/GemCatcher/assets/66936482/133d5287-60db-4a2d-a31f-517ca4fa2b95) , ![tile_0022](https://github.com/phatx88/GemCatcher/assets/66936482/d6b5433d-6a44-4197-a4ea-ff2d76ff5ce4).
  - Sky : ![tile_0018](https://github.com/phatx88/GemCatcher/assets/66936482/5c09faf0-13f9-47af-87ed-9cee49891f28) , ![tile_0015](https://github.com/phatx88/GemCatcher/assets/66936482/6ef5e327-71ee-469c-9149-97bd3de0f880).
  - Gem : ![tile_0067](https://github.com/phatx88/GemCatcher/assets/66936482/fc6213fc-440f-4d53-aa64-b0cf84f43139) , ![tile_0044](https://github.com/phatx88/GemCatcher/assets/66936482/c2408347-502c-4659-b65f-17476d4815fb).
  - Player : thay đổi cả sprites và animation ![tile_0004](https://github.com/phatx88/GemCatcher/assets/66936482/34911a0c-3665-40c9-90ba-da553e2eda68) , ![tile_0000](https://github.com/phatx88/GemCatcher/assets/66936482/db5e83dc-b373-4d31-9309-c4f3b12eadd4).

- Xuất hiện Vật phẩm xấu, là loại vật phẩm sẽ trừ điểm người chơi khi thu thập nhầm
  - ![tile_0008](https://github.com/phatx88/GemCatcher/assets/66936482/27dde2cc-d562-4065-b401-4f1752b52e0f) : khi player trạm phải vật phẩm thì sẽ bị trừ 1 điểm.

- Xuất hiện Vật phẩm điểm cao, là loại vật phẩm có x2 x3 x4 ... số điểm
  - ![tile_0162](https://github.com/phatx88/GemCatcher/assets/66936482/64efdefe-25a9-426a-82bd-f22639c84f06),![tile_0163](https://github.com/phatx88/GemCatcher/assets/66936482/816d9c52-d09f-413a-9ea9-b161b2481e7d), ![tile_0164](https://github.com/phatx88/GemCatcher/assets/66936482/6e709b70-2597-44b6-844c-aa2638ce9038): Vật phẩm sẽ thay đổi random tương ứng với số điểm được cộng lên là +2, +3, +4 điểm (số điểm cộng có thể điều chỉnh).

- Xuất hiện Vật phẩm power-ups dạng tăng tốc, là loại Vật phẩm giúp người chơi tăng tốc nhân vật
  - ![tile_0025](https://github.com/phatx88/GemCatcher/assets/66936482/7f905685-dd07-4f60-b508-343d26defd07) : Khi player trạm phải vật phẩm sẻ boost 2x speed cho player thời lượng là 3s sao đó sẽ reset (Speed boost và time có thể điều chỉnh)

- Một số loại Vật phẩm có thể xuất hiện từ tọa độ hoàn toàn khác (dưới lên, phải sang, trái sang)
  - Các loại vật phẩm ![tile_0025](https://github.com/phatx88/GemCatcher/assets/66936482/774e8526-6a23-4390-bfbf-03337151e260) , ![tile_0151](https://github.com/phatx88/GemCatcher/assets/66936482/4e82b862-e417-489c-819b-780b91a4566c) , ![tile_0092](https://github.com/phatx88/GemCatcher/assets/66936482/a701d3a5-3e39-46b2-81ed-c94c819bab5e) : sẽ chạy random từ phải sang hoặc trái sang

- Nhân vật có thể Double Jump
  - Khi nhân vật trạm đất thì sẽ có thể nhảy tối đa 2 lần, reset khi trạm đất.
    
- Nhân vật có thể bị mất/được thời gian khi thu thập vật phẩm mất/được thời gian
  - ![tile_0151](https://github.com/phatx88/GemCatcher/assets/66936482/83d001ca-3bed-425e-8e12-edb2ecc3d743) : Player va trạm sẽ được cộng thêm thời gian 3 giây (có thể tùy chỉnh)
  - ![tile_0092](https://github.com/phatx88/GemCatcher/assets/66936482/e003d5c7-84e5-4888-a535-c08632699558) : Player va trạm sẽ bị trừ thêm thời gian 3 giây (có thể tùy chỉnh)

- Nền nhà có thể xuất hiện một số các vật cản làm nhân vật bị cản lại khi va chạm. Nhân vật có thể nhảy qua
  - ![tile_0047](https://github.com/phatx88/GemCatcher/assets/66936482/31ba41ea-c9a1-4510-ad5f-6d58fd3b6042) : Vật phẩm sẽ cản Nhân vật khi va trạm, Nhân vật phải nhảy qua, có thể làm bàn đạp (ground) để reset double jump

- Thêm Clamping Position (tọa độ tùy chỉnh) để nhân vật chỉ di chuyển trong phạm vi của Main Camera
- Thêm Các Audio Source khi va trạm các loại vật phẩm khác nhau
- Thêm Scene Settings để người dùng có thể xem thay đổi của Vật Phẩm Ground, Gem, Sky, Player trước khi apply vào game chính
  
 


