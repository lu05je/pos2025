   M S B A M L   `   `   `  ����D  @WpfClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfClient	WpfClient  5   	       WpfClient.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WpfClient     5   	     � Title$.  (PCR-Testsystem Desktop-Client Teststelle��5   	   $	��450��6:   $	��800��6G    � Icon$ /favicon.jpg��6S   .��5	      � -   5         �Name$ ___No_Name_��5	       � ColumnDefinitions 5
   
   �� 5      $	��21* �6   �� 5      $
��379* �6   .+�5   
   �� $��1��6   $/��)PCR-Testsystem Desktop-Client Teststraße��6    $
��Left=�6S   $��31��6n   $��
235,34,0,0q�6z   $	��Top=�6�   $	��251��6�   $
��Bold"�6�   �� 5   
   $��1��6   $��Postleitzahl:��6    $
��Left=�68   $��26��6S   $��
248,70,0,0q�6_   $	��Top=�6s   $��84��6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ txtPLZ��5      $��1��6"   $
��Left=�62   $��26��6M   $��
358,70,0,0q�6Y    �� TextWrapping$
 Wrap=�6m   $�� ��6�   $	��Top=�6�   $��78��6�   �� 5   
   -   5         ��Name$ btnShow��5      $��1��6"   $��Anmeldungen anzeigen��62   $
��Left=�6Q   $��25��6l   $��260,111,0,0q�6x   $	��Top=�6�   $	��176��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$
 grid��5      $��1��6!   $
��Left=�61   $	��178��6L   $��111,160,0,0q�6Y   $	��Top=�6n   $	��572��6�      AutoGenerateColumns$ False��6�   	   GridLinesVisibility$
	 None=�6�   
   HeadersVisibility$
 Column=�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 PLZ��6%      
IsReadOnly$
 True��6J   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *PLZ+6J     5      $ Email��6%   $
 True��6N    64   �� *Email+6N     5      $ 
Geburtstag��6%   $
 True��6T    69   �� *GebTag+6T     5      $ Testzeit(soll)��6%   $
 True��6^    6=   �� *TestzeitSoll+6^   5      �� 5   
   -   5         ��Name$ lblCode��5      $��1��6!   $��Code:��61   $
��Left=�6A   $��26��6\   $��191,369,0,0q�6h   $	��Top=�6}   $��53��6�   $
��Bold"�6�   $y�Hidden=�6�   �� 5   
   -   5        $ txtCode��5      $��1��6#   $
��Left=�63   $��26��6N   $��260,369,0,0q�6Z   $
 Wrap=�6o   $	��Top=�6�   $	��349��6�   $y�Hidden=�6�   �� 5   
   -   5        $ 	btnDoTest��5      $��1��6$   $��Button��64   $
��Left=�6E   $��24��6`   $��248,400,0,0q�6l   $	��Top=�6�   $	��273��6�   $y�Hidden=�6�   �� 5   
   -   5        $ 
lblMessage��5      $��1��6$   $��Label��64   $
��Left=�6D   $��26��6_   $��191,369,0,0q�6k   $	��Top=�6�   $	��446��6�   $y�Hidden=�6�   5      5       