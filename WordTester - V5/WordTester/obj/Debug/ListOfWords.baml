   M S B A M L   `   `   `  ����E  AWordTester, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WordTester
WordTester  5   	       WordTester.ListOfWords   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WordTester     5   	   -   5          � Title$  	Szólista��5   	   $	��740��5	   	   $	��300��6   $	��450��5
   	   $	��900��6   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��7* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ tbHeader��5      $��Center=�6&   $��Center=�6A   $��20(�6^   �� 5   
   -   5         ��Name$ lbListOfWords��5      $��1��6)   $��Stretch=�5      ��5      �� 5      .R�5      �  � ColumnDefinitions 5      �� 5      $
��1.9* �6/   �� 5      $��2* �6/   �� 5      $��* �6/   �� 5      $��45 �6/   �� 5      $
��1.9* �6/   �� 5      $��2* �6/   �� 5      $��* �6/   �� 5       $��45 �6/   .+�5#      �� $��Center=�5$       
���  ��$��15(�5%   5   ��5#       �� *EnglishWord+ �� Mode$ OneWay=�5%   5   �� 5'      $��1��6%    �� Orientation$ 
Horizontal=�66   $��Right=�6O   $��Center=�6k   .+�5(      �� $��Tesztszám:��6$   $��0q�69   �� 5)      $	��4 0q�6G   $��0q�6T   ��6$   �� *EnglishTestNum+6T   �� 5*      $��Tudásszint:��6$   $
��10 0q�6:   $��0q�6H   5+      � 5-      $��2��6&    � Minimum$ 0Q�66    � Maximum$	 100Q�6B   $��10��6P   	 � Value	 5.   &   �� *EnglishSuccessPercentage+$ OneWay=��� 50      $��3��6%   $ 
Horizontal=�66   $
��Left=�6O   $��Center=�6j   .+�51      �� $��10 0 2 0q�6Q   $��0q�6c   ��6$   �� *EnglishSuccessPercentage+6c   �� 52      $��%��6$   $��0q�60   53      �� 55      $��4��6    $��Center=�56       
���  ��$��15(�57   5   ��55   0   �� *HungarianWord+$ OneWay=�57   5   �� 59      $��5��6%   $ 
Horizontal=�66   $��Right=�6O   $��Center=�6k   .+�5:      �� $��Tesztszám:��6$   $��0q�69   �� 5;      $	��4 0q�6I   $��0q�6V   ��6$   �� *HungarianTestNum+6V   �� 5<      $��Tudásszint:��6$   $
��10 0q�6:   $��0q�6H   5=      � 5@      $��6��6&   $ 0Q�66   $	 100Q�6B   $��10��6P   	 5A   &   �� *HungarianSuccessPercentage+$ OneWay=��� 5C      $��7��6%   $ 
Horizontal=�66   $
��Left=�6O   $��Center=�6j   .+�5D      �� $��10 0 2 0q�6S   $��0q�6e   ��6$   �� *HungarianSuccessPercentage+6e   �� 5E      $��%��6$   $��0q�60   5F      5H      5I      5K      �� 5L   
   -   5        $��2��5L      $��Vissza��6   $��20(�6/   6=   5M      5N      