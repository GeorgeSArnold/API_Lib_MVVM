   M S B A M L   `   `   `  ����C  ?TicketUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TicketUI.ViewsTicketUI.Views  5           TicketUI.Views.ChatGptView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TicketUI.Views     5      $��22(�5      ���#333333
�������.��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��ChatGptView��6   $
��Bold"�6'   $��22(�69   $
��Left=�5      $��Center=�5      $��13q�5      �� 5   
   $��0��6   $��0��6%    �� Orientation$ 
Horizontal=�62   $��Center=�6K   $��Right=�6f   .+�5      �� -   5         ��Name$ RefreshTable��5   N   $��refresh��6   $��22q�6'   $
��Left=�63   6N   5      &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ 
TicketList��5"      $��1��5#      $��2��6       AutoGenerateColumns .  $��12q�6M   $	��900��5$      ���#424242���#1E1E1E��5"   '   �� *
TicketList+ �� SelectedItem 6J   �� *SelectedTicket+   Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   MinWidth$	 12Q�6H   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 50 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6V     5+      $ Number��6%   $	
 100 6P    65   �� *Number+6P     5,      $ Title��6%   $	
 100 6N    64   �� *Title+6N     5-      $ Group��6%   $	
 100 6N    64   �� *Group+6N     5.      $ State��6%   $	
 100 6N    64   �� *State+6N     5/      $ Priority��6%   $	
 100 6T    67   �� *
Priority+6T     50      $ 
Created at��6%   $	
 220 6X    69   �� *
Created_at+6X   4  .System.Windows.Controls.DataGridTemplateColumn  52      $ Options��6)      CellTemplate 53      �� 54      .R�55      �� $
��Edit��6%   ��64   �� *DataContext.EditTicketCommand+ �� RelativeSource ��  �� AncestorType$ UserControlL�56      58      5:      5<      5=      