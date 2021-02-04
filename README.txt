==============================================================================
作品名　：よけとる2020
著作者　：たなかゆう
開発環境：Windows10 + Unity2019.3.15 + Visual Studio 2019
動作環境：WebGL
開発期間：2020/9/9-2020/12/9(3ヶ月)
開発人数：一人
担　　当：プログラム
==============================================================================


◆概要
10秒以内にトゲに当たらないようにコインを全て取るゲームです。


◆操作とルール
- マウスで操作
- 10秒以内にコインを全て取ってください
- トゲの甲羅にぶつかるか10秒経過でゲームオーバー


◆公開先
以下のURLにWebGL版を公開しています。

https://datgm20.github.io/OpenYoketoru2020/WebGL/index.html

※ネットランキングはAPIキー未設定のため動作しません。


◆プロジェクトをUnityで開くときの手順
- Assets/Scenes/Title シーンを開く
- 標準解像度は960x540ピクセル

本リポジトリーはアセットを含みません。クローンしたら以下を実施してください。

〇TextMesh Pro
初回起動時にダイアログが表示されるので、TextMesh Proの
Essensial Resources と Examples and Extras を両方ともインポートします。

〇Asset Storeからインポート
以下のアセットをAsset Storeからインポートします。

・DL Fantasy RPG Effects
https://assetstore.unity.com/packages/vfx/particles/dl-fantasy-rpg-effects-68246
・Gold Coins
https://assetstore.unity.com/packages/3d/props/gold-coins-1810#content
・LowPoly Rocks
https://assetstore.unity.com/packages/3d/environments/lowpoly-rocks-137970
・SciFi Enemies and Vehicles
https://assetstore.unity.com/packages/3d/characters/robots/scifi-enemies-and-vehicles-15159
・RPG Monster Duo PBR Polyart
https://assetstore.unity.com/packages/3d/characters/creatures/rpg-monster-duo-pbr-polyart-157762


◆スクリプト概要
本プロジェクト用に開発したスクリプトは以下の通りです。

- Assets/Scripts/
  - AnimCall.cs
    - Animationに設定したイベントで実行したい処理をUnitEventで設定するためのスクリプト
  - BoundChecker.cs
    - 画面内で跳ね返らせるコンポーネント。敵とアイテムにアタッチ
  - ClickToNextScene.cs
    - クリックした時に設定したシーンを呼び出す
  - GameManager.cs
    - スコアやタイムなどのゲーム情報を扱う
  - Item.cs
    - アイテムの数や取得時の処理
  - JinglePlayer.cs
    - シーン開始時にBGMを停止させて指定の効果音を鳴らす。ゲームオーバーとクリア用
  - Mover.cs
    - 敵やアイテムの速度を制御
  - ObjectSpawner.cs
    - 指定のオブジェクトを設定した数だけ出現させる
  - Player.cs
    - プレイヤーの操作と衝突時の処理
  - RandomSpawner.cs
    - 画面内のランダムな位置に出現させる
  - ScreenLimitter.cs
    - 画面の外に出ないように移動を制限する。プレイヤーにアタッチ
  - TinyAudio.cs
    - 効果音を再生
  - Version.cs
    - Applicatoin.versionをテキストに表示


◆組み込みアセットのライセンス
以下のアセットをプロジェクトに組み込んでいます。

- BGM [SketchyLogic](https://opengameart.org/users/sketchylogic)
  - https://opengameart.org/content/nes-shooter-music-5-tracks-3-jingles
  - [PUBLIC DOMAIN / CC0](https://creativecommons.org/publicdomain/zero/1.0/)
- 効果音 [Digital SFX set by Kenney Vleugels (www.kenney.nl)](https://opengameart.org/users/kenney)
  - https://opengameart.org/content/63-digital-sound-effects-lasers-phasers-space-etc
  - [PUBLIC DOMAIN / CC0](https://creativecommons.org/publicdomain/zero/1.0/)
- [NCMB SDK](https://github.com/NIFCLOUD-mbaas/ncmb_unity)
  - [Apache License](https://github.com/NIFCLOUD-mbaas/ncmb_unity/blob/master/LICENSE)
- [fontopo. FontopoNIHONGO](https://fontopo.com/)
  - [IPAフォントライセンスv1.0](https://fontopo.com/?page_id=47)
- SimpleJSON
  - The MIT License (MIT)
  - Copyright (c) 2012-2017 Markus Göbel (Bunny83)
- naichilab. [unity-Simple-ranking](https://github.com/naichilab/unity-simple-ranking)
  - [naichilab/unity-simple-ranking is licensed under the MIT License](https://github.com/naichilab/unity-simple-ranking/blob/master/LICENSE)


◆本プロジェクトのライセンス
MIT License
Copyright (c) 2021 たなかゆう


◆ 更新履歴
- Ver0.9.2 最初の公開


◆連絡先
Name : たなかゆう
Email: YRK00337@gmail.com
Web  : https://am1tanaka.hatenablog.com/


[EOF]
