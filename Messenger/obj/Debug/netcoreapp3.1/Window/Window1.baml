   M S B A M L   `   `   `  ????D  @Messenger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Messager.WindowMessager.Window  5   	       Messager.Window.Window1   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   )localclr-namespace:Messager.Window  5   	     ? Title$  Window1??5
   	   $
??1000??6   $
??1580??6'   .??5      ? .+?5   
   ?? $
??auto??6   $
??auto??6   $??5q?6,   $|?False??67   ._?5      ? .+?5      ??  ?? Orientation$ 
Horizontal=?6   $??Center=?5      
 ? Tag 68   ?? *
IDUserSent+.+?5      ??  ?? CornerRadius$	 200??6   $??0q?60   $??70??6D   $??70??6O   $??0 0 10 0q?5      ??5      ?? 5       j? Stretch$
 Fill=?6)    ?? ImageSource$ /Res/White.png??68   5      ._?5      '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ iconMessage??5   2   $y?Visible=?6G   $??84??6]   $??84??6h   ???#333333   Kind$ AccountCircle=?5   .   $??Center=?6C   $??Center=?6a   5      ?? 5      ???#e6e6e6$ 30??62   $??0 0 10 0q?6D   ._?5      ?? $??Center=?6%   $??10q?6@   .+?5      ?? $ 20??6%   $??0q?67   ??5   "   ?? 5   &   $
 Fill=?61   $ 
/Res/1.jpg??6@   5    '   5"      ?? 5#      $??22(?6C   $	??130??6Q   $	??400??6`   $
??Wrap=?6o    ?? TextAlignment$
 Left=?6?   ??6(   ?? *
Message1+6?   ?? 5$      $??15(?6i   	 J? Opacity$		 0.5Q?6w   $??	10 10 0 0q?6?   $??Right=?6?   $??Bottom=?6?   $ Center=?6?   ??6(   ?? *
TimeSent+
 ?? StringFormat$
 {0:dd.MM.yyyy HH:mm}??6?   5%      5&      5(      5)      5+      5.      5/      