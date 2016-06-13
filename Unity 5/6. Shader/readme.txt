◎ Shader

◎ 語言：
	‧ShaderLab
	‧CG
	‧GLSL

ShaderLab用於宣告Shader設定、結構的語言。
CG ( Nvidia )、GLSL ( Mobile Shader )、HLSL ( Direct3D ) 則是用於撰寫Shader程式；不同的語言在於文件內執行時的寫法差異，在此以CG為設計範本。

◎ 類型
	‧Surface
		- 簡易撰寫、數據多元 ( 如光源計算 )
		- 效能需求高
	‧Vertex and Fragment
		- 複雜撰寫
		- 效能需求低

◎ 主結構
http://docs.unity3d.com/Manual/SL-Shader.html

Shader [Shader classification folder / name]
{
	Properties { ... }
	SubShader { 
		Pass {
			Tag{ ... } 
			CGPROGRAM
			...
			ENDCG
		}
	SubShader { ... }
	Fallback "Shader name"
}

● Shader [Shader classification folder / name]
設定此Shader名稱。
classification folder / name，可以在Unity IDE內出現分類夾以供選擇；如"Custom/SelfShader"。

○ Properties 
http://docs.unity3d.com/Manual/SL-Properties.html

宣告變數，此變數可用於Shader程式，亦可用於指定圖檔等外部資源。

● SubShader

著色器本體，每個Shader內可以有複數個SubShader，用於對應不同硬體設備、環境。

○ Pass 

著色器對於物件個體的參數設定，並用定義Shader程式於此。

● Tag
http://docs.unity3d.com/Manual/SL-PassTags.html

用於標記本SubShader運作於那個Shader階段。

○ CGPROGRAM ... ENDCG
https://en.wikibooks.org/wiki/Cg_Programming/Unity

Shader程式撰寫區域，CG為Nvidia，以OpenGL、DirectX為底編制的著色器語言；GLSL則是簡化並用於手機版本，HLSL則為Microsoft DirectX版本。

● Fallback

若SubShader皆運行失敗，則依指定的Shader運行。
此行可不用撰寫，亦即表示失敗時將無替代方案。

◎ 
※ 相關文章參考：
---------------------------
猫都能学会的Unity3D Shader入门指南（一）
https://onevcat.com/2013/07/shader-tutorial-1/

猫都能学会的Unity3D Shader入门指南（二）
https://onevcat.com/2013/08/shader-tutorial-2/

Unity 入門教學：圓形小地圖製作原理
http://lolikitty.pixnet.net/blog/post/175747992

Cg Programming/Unity
https://en.wikibooks.org/wiki/Cg_Programming/Unity

Drawing a circle in a 2D game.
http://answers.unity3d.com/questions/1110655/drawing-a-circle-in-a-2d-game.html
http://answers.unity3d.com/questions/521984/how-do-you-draw-2d-circles-and-primitives.html

Unity 5 2D drawing sprites programmatically
http://gamedev.stackexchange.com/questions/96058/unity-5-2d-drawing-sprites-programmatically

Draw a Sprite Round
http://answers.unity3d.com/questions/975711/draw-a-sprite-round.html

Materials, Shaders & Textures
http://docs.unity3d.com/Manual/Shaders.html

Unity Shader Writing
https://www.youtube.com/watch?v=zJxxXjoZE30&list=PLV4HCa5XqFT02gZOZ_Jb_A66wqDhZMCkN
	
---------------------------

