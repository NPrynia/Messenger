   M S B A M L   `   `   `  ????D  @Messenger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MessagerMessager  5   	       Messager.AuthWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Messager     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   
??????   ? Title$
  Auth??5
   	   $	??640??6   $	??480??6#    ? WindowStartupLocation$ CenterScreen=?5   	    ? 
ResizeMode$ NoResize=?5   	    ? AllowsTransparency$
 True??5   	    ? WindowStyle$
 None=?5   	   .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??350* ?6   ?? 5      $
??239* ?6   .+?5   
   ?? $??2??6   ???#e6e6e6 ?? CornerRadius$ 10??67   ?? 5   
   $??1??6   $??10??6   $	??Top=?6*   
???????6B   ?? 5   
   $??1??6   
???????$ 10??61   ?? 5   
   -   5        $??
tabControl??5       ?? TabStripPlacement$ Bottom=?5        "  MaterialDesignFilledTabControl#??[  5!      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ Custom=?5"      	   
Foreground
	 ?????
   
Background
 ?#8aa5a2.@?5'      ?? $??Login??5(      $??Corbel Light)?6!   .??5)      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Login=?6*   $	??200??67   $	??200??6C   $??Center=?6P   $??Center=?6k   5+      ?? 5,      $??Registration??5-      $??Corbel Light)?6$   .??5.      ? $??Center=?6   $??Center=?65   .+?51      ?? $	 200??6   $??0q?60   $	??220??6D   $	??220??6P   ??52      ?? 53      -   5        
photoImage?? j? Stretch$
 Fill=?53   =    ?? ImageSource$ /Res/white.png??6M   ._?55        -   5        $??	photoIcon??56   ;   $	??264??6   $	??264??6   ???#333333$ AccountCircle=?57      $??Center=?6"   $??Center=?6@   59      ?? 5;      -   5         ??Name$ 	pickImage??5<       0 ,MaterialDesignFloatingActionMiniAccentButton#??[ 5=      ???#8aa5a2$??Right=?5@      $??Bottom=?5A      $??	0 0 10 10q?5B      ???#8aa5a2 ? Cursor$
 Hand??6@   .??5C        $ 	FileImage=?5D      5E      5K      5L      5M      ?? 5U   
   $??1??6   $??Center=?6$   $??Center=?6?   .+?5V      ?? -   5         ??Name$ tbName??5V      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Name??5W      $??16(?5X      $??Corbel Light)?5Y      $	??250??5Z      $??45??6    % !MaterialDesignFloatingHintTextBox#??[ 5[      G? 5]      -   5         G?Name$ 
pbPassword??5^       ? ToolTip$? ?•Длинна от 7 до 15
•Наличие цифр 20
•Наличие прописных и строничных букв??5_      $??	0 40 0 0 q?5`      $??16(?5a      $??45??6    G? Password$  ??5b      $ Password??5c       / +MaterialDesignFloatingHintRevealPasswordBox#??[ 5e      $??Corbel Light)?5f      0  *MaterialDesignThemes.Wpf.PasswordBoxAssist   Password 5d      ?? *	Password2+ ?? Mode$ TwoWay=?5f      ?? 5h      -   5        $ btnLogin??5i      $??40??5j      ???#8aa5a2$??	0 40 0 0 q?5m      ???#8aa5a2
???????$??Login??5p      $??20(?5q      $??Corbel Light)?6   $
 Hand??69   5t      ?? 5v   
   -   5        $??	topBorder??5x   =   $??40??5w      
?????? $	??Top=?5x   %   ._?5y      ?? -	   5        $??exitBtn??5z      $??Right=?5{      $??25??5|      $??45??6   
?????? $??0q?6A   $
 Hand??6U   .??5}        $ WindowClose=?5      ???	#FF494949$??Center=?5?      5?      5?      5?      5?      