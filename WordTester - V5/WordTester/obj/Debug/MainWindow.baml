   M S B A M L   `   `   `  ����E  AWordTester, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WordTester
WordTester  5   	       WordTester.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WordTester     5   	     � Topmost  .   � Title$ 
MainWindow��5	   	   $	��600��6   $	��900��6)    � 	Resources 5
         BorderStyleSajat �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6)   .�5      ��  � ��
 �����6+   �� 5       �@��CornerRadius$ 10��6-   �� 5       � ��
 � ���6,   �� 5       � ��$
 20 6q�6'   �� 5       � ��$ 5q�60   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��5* �6   �� 5      $��1* �6   �� 5      $��50 �6   .+�5   
   �� $��0��6   $#��Angol-Magyar szófelkérdező��6   $��Center=�5      $��23(�5      �� 5!   
   -   5        $��
brdVezerlo��5!      $��1��6#   #���   5"      ._�5#      �  � ColumnDefinitions 5$      �� 5%      �� 5&      �� 5'       5)      �� 5*      $��2* �6$   �� 5+      $��2* �6$   �� 5,      �� 5-      .+�5/      �� -   5         ��Name$ sliTestWordsNum��5/      $��Center=�50      $��1��51      $��2��6)   52      �� 53      -   5        $��lblChoisedNum��53      $��2��54      $��2��6(   $��Center=�55      $
��Left=�63   $��3��56      �� 58      -   5        	 ��Name$	 chkIsCheckEveryWord��58      $��3��59      $��1��6(   $2��,Hibás válasz esetén mutassa a megoldást?��5:      $��Center=�5;      5<      5=      �� 5?   
   #���   6   $��2��5@      ._�5A      �� 
 �� Orientation$
 
Horizontal=�6   $��Center=�62   .+�5B      �� -   5         ��Name$ btnLoadTest��5B      $��10 15q�5C      $��Teszt betöltése��5D      5F      �� 5G      -   5        $ btnListOfWords��5G      $��10 15q�5H      $��Szavak listája��5I      {�.  5L      �� 5M      -   5        $ btnStartTest��5N      $��10 15q�5O      $��Teszt indítása��5P      {�.  5S      �� 5U      -   5        $ btnDEMO��5U      $��10 15q�5V      $ ��ListBox és DataGrid demó��5W      {�.  5Z      5\      5]      �� 5_   
   #���   6   $��3��5`      ._�5a      � .+�5b      �� $��Teszt neve:��6   �� 5c      -	   5        $��lblFileName��5c      �� 5d      $��Teszt szókészlete:��6   �� 5e      -
   5        $��lblWordsNum��5e      �� 5f      $#��Tesztelt angol szavak száma:��6   �� 5g      -   5        $��lblTestNumUK��5g      �� 5h      $$��Tesztelt magyar szavak száma:��6   �� 5i      -   5        $��lblTestNumHU��5i      5k      5l      	� 5n   
   -   5         	�Name$ rbUKHU��5n      $��Angol-Magyar teszt��6&   $
��Left=�6C   $��	64,83,0,0q�6^   $	��Top=�6q   $��1��6�    	� 	GroupName$ TestType��6�   {�.  6�   	� 5o   
   -   5        $ rbHUUK��5o      $��Magyar-Angol teszt��6&   $
��Left=�6C   $��
218,83,0,0q�6^   $	��Top=�6r   $��1��6�   $ TestType��6�   {�.  6�   	� 5p   
   -   5        $ rbRandom��5p      $%��Véletlenszerűen kiválasztott��6(   $
��Left=�6O   $��
64,154,0,0q�6j   $	��Top=�6~   $��1��6�   $ InfoType��6�   {�.  6�   	� 5q   
   -   5        $ rbLeastKnown��5q      $��Kevésbé tudott szavak��6,   $
��Left=�6L   $��
64,194,0,0q�6g   $	��Top=�6{   $��1��6�   $ InfoType��6�   {�.  6�   	� 5r   
   -   5        $ rbLeastTested��5r      $��Kevésbé tesztelt szavak��6-   $
��Left=�6O   $��
64,174,0,0q�6j   $	��Top=�6~   $��1��6�   $ InfoType��6�   {�.  6�   5t      5u      