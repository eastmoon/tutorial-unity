◎ Unity 5 

◎ 官方教學文件
http://unity3d.com/cn/learn/tutorials

● Interface & Essentials
http://unity3d.com/cn/learn/tutorials/topics/interface-essentials

○ User Interface
http://unity3d.com/cn/learn/tutorials/topics/user-interface-ui

● 2D Game creation
http://unity3d.com/cn/learn/tutorials/topics/2d-game-creation

○ Graphics
http://unity3d.com/cn/learn/tutorials/topics/graphics

● Script
http://unity3d.com/cn/learn/tutorials/topics/scripting

◎ Unity IDE problem

---------------------------
Android sdk build error "sdk tools version 0 < 21"
http://answers.unity3d.com/questions/652886/android-sdk-build-error-1.html

Unity 5.3 >>
Edit -> Preferences > External Tools > Android SDK Location
Setting location the same with Android Studio download location.

---------------------------
Unity stops processing input after the second time I press play - Unity 5.1.2f1
http://forum.unity3d.com/threads/unity-stops-processing-input-after-the-second-time-i-press-play-unity-5-1-2f1.347814/

The issue is that EventSystem does not seem to get an input module activated. It works for the first time, but after you change scene or exit playmode and run again, it does not work anymore. Select your EventSystem object in inspector and you can see there is no module activated. Workaround is to check "Force Module Active" and the EventSystem immediately picks it up. Yet it fails again when changing scene or running second time. :/

---------------------------

※ 相關文章參考：
---------------------------
Unity Github 開放源碼資源
http://www.metatale.com/livinglab/?cat=42


---------------------------


