#                                      说明文档

### 玩家视角

* 玩家可通过WASD来控制角色移动，鼠标移动来控制玩家朝向
* 玩家可以使用七种不同的武器
* 玩家可以使用鼠标移动控制开火方向，左键实现开火，右键实现人物的双持技能
* 玩家可以在游戏内与多种不同的敌人战斗，包括精英怪在内
* 玩家可以通过按下Q，E来切换手中的主副武器
* 玩家靠近地上的枪械时，按下空格即可拾取枪械
* 玩家进入传送门区域后，按下空格即可传送至下一关
* 玩家通过按下ESC键可暂停游戏，并在暂停界面返回主界面
* 玩家可以通过奖励房间或精英怪房间中的武器箱获得可切换的武器
* 玩家在靠近敌人时，攻击方式将切换为手刀
* 为保证玩家良好的游戏体验，开发者对血量进行了特殊设置

### 功能介绍

* 实现WASD键控制人物移动，鼠标控制人物朝向

  监视键盘WASD键的按下来控制人物移动，使用一个Bool变量控制人物站立与行进间的动画切换，同时获取鼠标位置，修改人物的朝向使其朝向鼠标

* 实现1-1到1-5的五个小关

  使用tilemap进行地图绘制，相同的房间储存为预制体，同时向地图中添加场景布置

* 实现了第一大关的所有怪物

  使用布尔变量控制人物静止，行走，死亡的动画切换，当玩家与近战怪物距离较大时，怪物前往一个随机坐标，即闲逛，当玩家进入怪物一定范围内，近战怪物会索敌，进入攻击距离后攻击玩家；远程巫师同样会进行闲逛，并对玩家发射子弹，但玩家进入巫师一定范围内，巫师会向反方向躲避玩家；精英怪进行了数值上的调整，生命值更高，攻击伤害更高。

* 实现关卡内可破坏木箱

  给木箱设置生命值，添加碰撞器，通过检测碰撞物的tag检测是否撞到了子弹，是则减少生命值，生命值为零则销毁

* 击败怪物后掉落能量和金币，玩家靠近吸引

  设置能量和金币的预制体，给各自添加脚本，击败怪物后随机在怪物周围生成随机数量的能量和金币，给能量和金币添加脚本，当玩家靠近到一定距离内，金币和能量即飞向玩家，同时设置触发器，触碰到玩家后修改金币或能量值，之后能量和金币销毁

* 击败一个房间的敌人后生成奖励箱子

  所有生成敌人的房间都为同一个预制体，对该预制体添加脚本，每个房间随机生成一到四波敌人，当敌人全部被消灭后，在房间内随机坐标生成一个奖励箱子，奖励箱子同样为预制体，添加脚本和触发器，当玩家进入箱子的触发器范围，箱子即打开，同时随机在箱子周围生成能量和金币。

* 多个波次敌人的生成

  在房间的脚本中随机一个1-4间的数字作为生成敌人的波数，同时在房间脚本内添加一个数组储存所有的怪物，每一波生成敌人时，随机生成4-6个怪物，每个怪物为在数组中随机选择，通过检测场上tag为enemy的物体的数量检测上一波敌人是否完全消灭。

* 实现若干种武器

  将所有武器设为玩家的子物体，为每把武器添加脚本，控制武器始终朝向鼠标，当前正在使用的武器setactive true，剩下武器全部为false，在远程武器脚本中进行子弹的生成，攻击间隔的控制，子弹的偏移，同时每种子弹设为预制体，对子弹同样添加脚本，控制子弹飞行的速度

* 实现拾取武器与切换武器

  地上的武器为贴图，给贴图添加触发器，同时将贴图的名字设为与对应枪械名字相同，当玩家进入触发器范围内，通过名字相同，获取到玩家子物体中对应枪械。若此时没有副武器，则将地上的武器设为副武器，同时销毁地上的贴图；若此时有主副武器，则将手上的武器变为地上的武器，同时生成手上武器的贴图预制体在原位置。

  玩家的主副武器保存在数组中，按下QE改变当前所持武器的编号weaponnum，实现切换武器的功能

* 手刀

  将手刀效果的第一张图设为玩家的子物体，与武器相同，为手刀添加动画效果和预制体，tag设为bullet。当玩家手持远程武器，且与怪物距离很近时，将当前武器false，同时手刀true，打开手刀触发器，点击左键播放手刀动画。当距离拉开后再将手刀false，同时武器true。

* 每一关设置奖励房间与特殊房间

  每一个选定一个房间作为奖励房间，每个奖励房间里设一个武器箱，武器箱添加脚本与触发器，脚本中添加数组储存所有武器，打开箱子后随机生成一把武器。每关选定一个特殊房间，1-5设置两个，每个特殊房间中有蓝水晶或者黄水晶，1-5的多出来的特殊房间为精英怪房间。

* 实现完整的UI界面
* 实现对象池优化子弹生成与销毁

### 代码架构

总体分为武器，人物，UI，物品，房间，怪物几个部分，其中武器中包含有子弹的脚本，远程武器在生成子弹时会调用子弹脚本中的方法；怪物在攻击玩家，对玩家造成伤害时会调用玩家脚本中的方法，远程巫师在攻击时会调用敌人子弹脚本中的方法，玩家脚本中会调用UI血量，蓝量，盾牌等的脚本中的方法，来修改UI。
