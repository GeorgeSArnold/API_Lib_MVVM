   M S B A M L   `   `   `  ����C  ?TicketUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TicketUI.ViewsTicketUI.Views  5   	   $    TicketUI.Views.ChatGptEditView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TicketUI.Views     5   	     � Title$  ChatGptEditView��5   	   $	��560��6!   $	��800��6.   ���#2E2E2E
������� � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5      ��  �� Orientation$ 
Horizontal=�5      $��0��5      $��10q�5      .+�5      �� $��16(�5      $
��Bold"�5       Ticket Properties5"      5#      �� 5%      $��1��6   $��0��6&   $��17,3,0,0q�5&      .+�5'      �� $	��Id:��6   $��5q�6'   �� 5(      -   5         ��Name$ Id��5(      $	��Top=�5*      $
��Left=�5+      $	��300��5,      $��23��5-      $��5q�5.      ���#3D3D3D
���������5)      �� *SelectedTicket.Id+50      �� 51      $��Number:��6   $��5q�6+   �� 52      -   5        $ Number��52      $	��Top=�54      $
��Left=�55      $	��300��56      $��23��57      $��5q�58      ���#3D3D3D
���������53      �� *SelectedTicket.Number+5:      �� 5;      $��Title:��6   $��5q�6*   �� 5<      -   5        $ Title��5<      $	��Top=�5>      $
��Left=�5?      $	��300��5@      $��23��5A      $��5q�5B      ���#3D3D3D
���������5=      �� *SelectedTicket.Title+5D      �� 5E      $��Article_ids:��6   $��5q�60   �� 5F      -   5        $ ArticleIdsString��5F      $	��Top=�5H      $
��Left=�5I      $	��300��5J      $��23��5K      $��5q�5L      ���#3D3D3D
���������5G      �� *!SelectedTicket.ArticleIdsString+ �� Mode$ OneWay=�5N      5O      �� 5R      $��1��5S      $��0��5T      $ 
Horizontal=�5U      $��10q�5V      .+�5W      �� $��10q�5X      $��12(�5Y      $��Article ID:��5Z      �� 5[      -   5        $ CurrentArticleId��5\      $��33��5^      $��23��5_      ���#3D3D3D
���������5]      �� *CurrentArticleId+$ OneWay=�5a      �� 5c      -   5         ��Name$ 
GetSuggest��5d      $
��Left=�5e      $��10q�5f      $��Get ChatGPT Suggest��5g      ��63   �� *DataContext.GetSuggestCommand+ �� RelativeSource �� 	 �� AncestorType$	 WindowL��� 5h      -   5        $ Clear��5i      $
��Left=�5j      $��10q�5k      $��Clear Response��5l      ��6.   �� *DataContext.ClearRTxtBCommand+ �� $	 WindowL�5m      �� 5p      $��1��6   $��1��6&   $��7q�66   .+�5q      �� $��Ticket Article Body:��6   �� 5r      ���#3D3D3D
�������$��Stretch=�5u   	   $��Stretch=�5v   	   $	��100��5w   	   . �5x      /� .T�5y      J� .*�6$   .*�5z      �� -   5        
 ��Name$

 Body��5z   "   �60   �� *LastArticleBody+5{      5|      5}      5      �� 5�      $��3��6   $��1��6&   $��7q�66   .+�5�      �� $��GPT-API Response:��6   �� 5�      ���#3D3D3D
�������$��Stretch=�5�   	   $��Stretch=�5�   	   $	��100��5�   	   . �5�      /� .T�5�      J� .*�6$   .*�5�      �� -	   5        $
 Response��5�   "   �64   �� *ResponseBody+5�      5�      5�      5�      5�      5�      5�      