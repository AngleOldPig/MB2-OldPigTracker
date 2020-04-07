using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 引入骑砍2开发需要的库
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.Localization;
using TaleWorlds.InputSystem;

namespace OldPigTracker
{
    public class HelloWorld : MBSubModuleBase   // 继承自MBSubModuleBase基类
    {

        /* 
         * 加入自定义菜单按钮，点击菜单输出helloworld
         */
        protected override void OnSubModuleLoad()   // 重写OnSubModuleLoad()方法，这个方法在模组加载之后就会被调用
        {
            base.OnSubModuleLoad();     // 先执行基类中的OnSubModuleLoad()方法，这一行建议不要删掉
            Module.CurrentModule.AddInitialStateOption(     // Module类中，为当前模组加入菜单选项
                new InitialStateOption("老猪测试插件",      // 创建一个新的菜单选项对象（按钮），id为老猪测试插件 
                new TextObject("老猪测试插件", null),       // 创建一个TextObject（文本对象），名称为老猪测试插件
                9990,                                       // 顺序，这个顺序的大小决定了这个按钮跟其他按钮哪个在上哪个在下
                () => { InformationManager.DisplayMessage(new InformationMessage("第一次尝试当然是输出 Hello World! ")); },
                // 按下这个按钮时执行的方法，通过InformationManager显示一条信息
                false));    // 这个按钮是否被禁用（如果禁用就变灰不能按）
        }

       
        /*
         * 尝试检测帧率
         * 尝试按键交互
         */
        float totalTime = 0;    // 累计经过的时间
        float totalFrame = 0;   // 累计经过的帧数
        protected override void OnApplicationTick(float dt)
        {
            base.OnApplicationTick(dt);     // 同上不建议删掉
            totalTime += dt;    // 加上这一帧的时间
            totalFrame++;       // 加上上一帧
            if(totalTime >= 1)  // 判断累计时间是否超过一秒
            {
                // 超过一秒的情况下，输出当前累计的帧数，这个就是帧率了
                InformationManager.DisplayMessage(new InformationMessage("当前帧率：" + totalFrame));
                // 把累计的变量清零，以便下一次计算
                totalFrame = 0;
                totalTime = 0;
            }

            if (Input.IsKeyPressed(InputKey.V))     // 监听V键的按下
            {
                // 输出 Hello World！
                InformationManager.DisplayMessage(new InformationMessage("按V键输出 Hello World！"));
            }
        }
        
    }
}
