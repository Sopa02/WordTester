   M S B A M L   `   `   `  ����E  AWordTester, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WordTester
WordTester  5   	       WordTester.DEMO   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WordTester     5   	     � Title$)  #Különféle megjelenítési módok��5   	   $	��650��6/   $	��900��6<   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��5* �6   �� 5      $
��0.5* �6   �� 5      $��9* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��5* �6   �� 5      $��50 �6   �� 5      $��5* �6   �� 5      $��2* �6   .+�5   
   �� $��0��6   $����Példa ListBox -ra. XAML-ben nincs formázás a megjelenésre. Miután az ItemSource objektumlistát kap, automatikusan minden objektumra a ToString() metódust meghívva betölti a String reprezentást.��6$   $
��Wrap=�5      �� 5   
   -   5        $��lbLista��5      $��1��6   
�������$��Stretch=�5      $��
10 10 10 0q�5      �� 5   
   $��0��6   $��2��6$   $���{Példa formázott kinézetű ListBox-ra. 4 oszlopból és két sorból álló Grid-be helyezett tartalom adja az Items-eket��61   $
��Wrap=�5      �� 5"   
   -   5        $��lbListaFormazott��5"      $��3��6   
�������$��Stretch=�5#      $��
10 10 10 0q�5$      ��5%      �� 5&      .R�5'      �  5(      �� 5)      $��* �6/   �� 5*      $
��1.2* �6/   �� 5+      $��* �6/   �� 5,      $
��1.2* �6/    5.      �� 5/      �� 50      .+�52      �� $��Center=�53       
���  ��$��2��54   5   $��15(�6F   ��52       �� *EnglishWord+ �� Mode$ OneWay=�54   F   � 55      $��1��6&    � Minimum$ 0Q�66    � Maximum$	 100Q�6B   $��10��6P    � Value 56   &   �� *EnglishSuccessPercentage+$ OneWay=��� 57      $��1��6    $��1��6-   $��Center=�59       ��58       �� *EnglishSuccessPercentage+59       �� 5;      $��2��6    $��Center=�5<       
��� d �$��2��5=   7   $��15(�6H   ��5;   0   �� *HungarianWord+$ OneWay=�5=   H   � 5>      $��3��6&   $ 0Q�66   $	 100Q�6B   $��10��6P    5?   &   �� *HungarianSuccessPercentage+$ OneWay=��� 5@      $��1��6    $��4��6-   $��Center=�5B       ��5A       �� *HungarianSuccessPercentage+5B       5C      5D      5F      �� 5I   
   $��2��6   $����Példa DataGrid-re. XAML-ben nincs beállítva a megjelenés. Miután az ItemSource objektumlistát kap, automatikusan az osztály minden public(látható) mezője bekerül egy oszlopként a táblázatba. A mezők neveire kattintva működik a rendezés!��6$   $
��Wrap=�5J      &   System.Windows.Controls.DataGrid  5K   
   -   5          Name$ dgLista��5K   0   $��2��6   $��1��6#   60   �� 5N   
   $��2��6   $��2��6$   $����Példa formázott DataGrid-re. Az XAML-ben az AutoGenerateColumns=False beállítással kikapcsoljuk a fenti automatikus oszlophozzáadást. Helyette magunk alakítjuk ki az oszlopokat.��61   $
��Wrap=�5O        5Q   
   -   5        $ dgListaFormazott��5Q   0   $��2��6   $��3��6#      AutoGenerateColumns .  	   Columns	 5R      0  *System.Windows.Controls.DataGridTextColumn  5S      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Angol szó��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *EnglishWord+4  .System.Windows.Controls.DataGridTemplateColumn  5U      $
 Tudásszint HU -> UK��6)      CellTemplate 5V      �� 5W      .R�5X      ��  �� Orientation$ 
Horizontal=�6)   
�������.+�5Y   "   �� ��6(   �� *EnglishSuccessfulNum+�� 5Z   "   $��/��6(   �� 5[   "   ��6(   �� *EnglishTestNum+�� 5\   "   $��* 100 =��6(   �� 5]   "   
���  ����6(   �� *EnglishSuccessPercentage+6U   �� 5^   "   $��%��6(   5_      5`      5b        5d      $

 UK %��6%    63   �� *EnglishSuccessPercentage+  5f      $
 Magyar szó��6%    69   �� *HungarianWord+  5h      $
 Tudásszint UK -> HU��6)    5i      �� 5j      .R�5k      �� $ 
Horizontal=�6)   
�������.+�5l   "   �� ��6(   �� *HungarianSuccessfulNum+�� 5m   "   $��/��6(   �� 5n   "   ��6(   �� *HungarianTestNum+�� 5o   "   $��* 100 =��6(   �� 5p   "   
���  ����6(   �� *HungarianSuccessPercentage+6W   �� 5q   "   $��%��6(   5r      5s      5u        5w      $

 HU %��6%    63   �� *HungarianSuccessPercentage+5z      �� 5|   
   $��4��6   $��0��6"   .+�5}      �� -   5        $��btnAngol��5}      $��Rendezés (angol)��5~      $
��20 5q�5      $��8q�6   5�      �� 5�      -   5         ��Name$ 	btnMagyar��5�      $��Rendezés (magyar)��5�      $
��20 5q�5�      $��8q�6   5�      5�      5�      5�      