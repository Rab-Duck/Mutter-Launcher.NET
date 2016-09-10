# Mutter Launcher .NET

Mutter Launcher by C#.NET  
Yet, yet another application lancher for Windows by C#.NET

## これは何？

Mutter Launcher <http://hp.vector.co.jp/authors/VA022068/soft/bin/mlnch/>  
を C#.NET に移植しようとしているものです。  
一人プロジェクト＆学習を兼ねているので説明などは不十分ですが、
もし興味あれば覗いてみて下さい。

## とりあえずアプリを動かしてみるには？

- dist 配下にその時点でのリリース版を置いてあります。  
.NET Framework 4.5 以上の環境なら動作可能（と思います。出来たら 4.5.2 以上推奨）。

- 起動後に <kbd>Shift</kbd>+<kbd>Space</kbd> でメイン画面が開きます。  
メイン画面のボタンやタスクトレイのアイコンから右クリックで、設定画面を開くことができます。

- 機能はほぼ Mutter Launcher に準じて＆＋α しています（ただ、まだ実装途中のものもありますが…）。  
詳しくはそちらを参照してみて下さい。

- 設定は %userprofile%\AppData\Local\Rab-Duck に保存されますので、
アンインストール時にはこちらも削除して下さい。

## プロジェクトをビルドしてみるには？

Visual Studio 2015 で作っています。  
MutterLauncher-net 配下のソリューションファイルを開いて下さい。


## ブランチについて
develop ブランチで開発をして、適宜 master 側にマージをしています。  
とりあえず動かしてみるには master 側をお勧めします。
