   M S B A M L   `   `   `  ????G  CNevGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:NevGeneratorNevGenerator  5   	       NevGenerator.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:NevGenerator     5   	     ? Title$  Névgenerátor??5   	   $	??500??6   $	??500??6+    ? 
ResizeMode$ CanMinimize=?67   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      ?? 5      ?? 5      $
??auto ?6    ? ColumnDefinitions 5   
   ?? 5      ?? 5      .+?5   
   ]? $??1??6   $??0??6!   $??5q?61   .+?5      ?? -   5        $??
Betöltés??5      6(   ?? 5      $??Családnevek??6   ?? 5      ??6   ??  ?? ElementName$ lbCsaladNevek?? ?? Path$ Items.Count?5      ]? 5   
   $??1??6   $??1??6!   $??5q?61   .+?5      ?? -   5        $??
Betöltés??5      6(   ?? 5      $??	Utónevek??6   ?? 5      ??6   ?? $ 
lbUtoNevek??$ Items.Count?5      ?? 5   
   -   5         ??Name$ 
lbUtoNevek??5      $??5q?6&   $??2??61   $??1??6>   ???	#FFF7EB986N   ?? 5    
   -   5        $ lbCsaladNevek??5       $??5q?6)   $??2??64   $??0??6A   ???	#FFF7EB986Q   ?? 5!   
   -   5        $ lbGeneraltNevek??5!      $??5q?6+   $??3??66   $??0??6C   ???	#FFED8B8B6j   ?? 5"   
   $??3??6   $??1??6"   $??5q?62   .+?5#      ?? 
????? ? ?? CornerRadius$ 10??60    ?? Padding$ 5q?6B   ._?5$      ?? .+?5%      ]? .+?5&      ?? $??Utónevek száma:??6    	? 5'      -   5        	 	?Name$	 	EgyUtoNev??5'   &   $	??Egy??69   
 d? 	IsChecked$

 TrueY?6G   	? 5(      $??Kettő??6&   5)      ]? 5*      .+?5+      ?? $#??Létrehozandó nevek száma: ??6    ?? 5,      -   5         ??Name$ tbLetrehozandoSzam??5,   "   ??6>   ?? $ sliderLetrehozandoSzam??$ Value?5-      ]? 5.      $??Center=?6    .+?5/      ?? $??0??6    ?? 50      -   5         ??Name$ sliderLetrehozandoSzam??50   ?   $??Center=?6!    ? Minimum$ 0Q?6<   $	??170??6?    ? SmallChange$ 1Q?6?    ?? IsSnapToTickEnabled$
 True??6    ? Maximum 6H   ?? $ lbCsaladNevek??$ Items.Count? ? Value 6?   ?? $ tbLetrehozandoSzam??$
 Text?6   ?? 51      ??6    ?? $ lbCsaladNevek??$ Items.Count?52      53      54      ?? 55      -	   5        $??Neveket generál??55      $??2q?6/   6:   ?? 56      -
   5        $??Generált nevek törlése??56      $??2q?66   6A   ?? 57      -   5        $??Nevek rendezése??57      $??2q?6/   6:   ?? 58      -   5        $??Nevek mentése??58      $??2q?6-   68   59      ?? 5:   
   $??4??6   $??2??6!   .@?5;      ?? $??Generált nevek száma:??6   ?? 5<      ??6   ?? $ lbGeneraltNevek??$ Items.Count??? 5=      $
??10 0q?6   ?? 5>      -   5         ??Name$ stbRendezes??5>      63   5?      5@      5A      