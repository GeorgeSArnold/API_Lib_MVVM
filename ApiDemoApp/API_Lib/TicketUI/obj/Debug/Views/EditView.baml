   M S B A M L   `   `   `  ����C  ?TicketUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TicketUI.ViewsTicketUI.Views  5   	       TicketUI.Views.EditView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TicketUI.Views     5   	     � Title$  EditView��5   	   $	��450��6   $	��800��6'   ���#2E2E2E
������� � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5      ��  �� Orientation$ 
Horizontal=�5      $��0��5      $��10q�5      .+�5      �� $��16(�5      $
��Bold"�5      Ticket Properties5!      5#      �� 5%      $��1��6   $��0��6&   $��17,3,0,0q�5&      .+�5'      �� $	��Id:��6   $��5q�6'   �� 5(      -   5         ��Name$ Id��5(      $	��Top=�5*      $
��Left=�5+      $	��300��5,      $��23��5-      $��5q�5.      ���#3D3D3D
���������5)      �� *SelectedTicket.Id+50      �� 52      $��Number:��6   $��5q�6+   �� 53      -   5        $ Number��53      $	��Top=�55      $
��Left=�56      $	��300��57      $��23��58      $��5q�59      ���#3D3D3D
���������54      �� *SelectedTicket.Number+5;      �� 5=      $��Title:��6   $��5q�6*   �� 5>      -   5        $ Title��5>      $	��Top=�5@      $
��Left=�5A      $	��300��5B      $��23��5C      $��5q�5D      ���#3D3D3D
���������5?      �� *SelectedTicket.Title+5F      �� 5G      $��Article_ids:��6   $��5q�60   �� 5H      -   5        $ ArticleIdsString��5H      $	��Top=�5J      $
��Left=�5K      $	��300��5L      $��23��5M      $��5q�5N      ���#3D3D3D
���������5I      �� *ArticleIdsString+ �� Mode$ OneWay=�5P      5Q      �� 5T      $��1��5U      $��0��5V      $ 
Horizontal=�5W      $��10q�5X      .+�5Z      �� $��10q�5[      $��12(�5\      $��Article ID:��5]      �� 5^      -   5        $ CurrentArticleId��5_      $��33��5a      $��23��5b      ���#3D3D3D
���������5`      �� *CurrentArticleId+$ OneWay=�5d      �� 5f      -   5         ��Name$ 
GetSuggest��5g      $
��Left=�5h      $��10q�5i      $��Get ChatGPT Suggest��5j      ��63   �� *DataContext.GetSuggestCommand+ �� RelativeSource �� 	 �� AncestorType$	 WindowL��� 5l      -   5        $ Clear��5m      $
��Left=�5n      $��10q�5o      $��Clear RichTextBox��5p      ��61   �� *DataContext.ClearRTxtBCommand+ �� $	 WindowL��� 5r      -   5        $
 Undo��5s      $
��Left=�5t      $��10q�5u      $
��Undo��5v      ��6$   �� *DataContext.UndoTextCommand+ �� $	 WindowL�5x      �� 5z      $��2��6   $��7q�5{      $��1��5|      ���#2E2E2E
�������$��Stretch=�5      $��Stretch=�5�      . �5�      /� .T�5�      J� .*�6    .*�5�      �� -	   5        
 ��Name$

 Body��5�      �6,   �� *Body+5�      5�      5�      5�      5�      5�      