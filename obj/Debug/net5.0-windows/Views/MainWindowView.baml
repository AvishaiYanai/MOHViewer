   M S B A M L   `   `   `  ����D  @MOHViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MOHViewer.ViewsMOHViewer.Views  5   
   $    MOHViewer.Views.MainWindowView   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:MOHViewer.Views     5   
   $	��650��5	   !   $	��800��6.     � Title  6	   �� *Title+.��5
      �  � ColumnDefinitions 5   
   �� 5      $	��800 �6    � RowDefinitions 5   
   �� 5      $��55 �6   �� 5      $��* �6   �� 5      $
��0.2* �6   .+�5   
   �� $��Center=�6   .+�5      �� $��0,0,0,0q�6   $
��Left=�6)   Cities6L   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� $	��200��6   $
��Left=�6$    �� 
IsEditable$
 True��5      $��Center=�5       �� 
IsReadOnly$
 True��5      $|�False��5       �� Text$ --Select City--��5       �� DisplayMemberPath$ CityName��5      ��5      ��  �� Path$" MOHDataFetchService.CityList�	 �� SelectedItem	 5      �� $ SelectedCity�5      �� 5       $��7,2,0,0q�6   $
��Bold"�6-   
���  ����6P   �� *MOHDataFetchService.Loader+6~   5!      5#      &   System.Windows.Controls.DataGrid  5$   
   $��0,35,0,0q�6   $��1��6%   $	��700��5%      $
   HorizontalScrollBarVisibility$
 Hidden=�5&         DataGridStyle#���   5'        GrdiHeaderStyle   ColumnHeaderStyle# �  5(         AutoGenerateColumns$ False��5)      ��5$   2   �� $* $MOHDataFetchService.FilteredRecordes�   Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$
 City��6&   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5,      �� 5-      $ CityName�6"   64   5/        50      $
 Date��6&    51      �� 52      $
 Date�6"   60   54        55      $ Total Verified��6'    56      �� 57      $ TotalVerified�6"   69   59        5:      $ Total Deaths��6'    5;      �� 5<      $ TotalDeaths�6"   67   5>        5?      $ Total Tests��6&    5@      �� 5A      $ 
TotalTests�6"   66   5C      5E      5F      5H      