   M S B A M L   `   `   `  ����C  ?TicketUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TicketUI.ViewsTicketUI.Views  5      #    TicketUI.Views.ConnectionView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TicketUI.Views     5      ���#2E2E2E
�������$��22(�5      .��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   .+�5      �� $��
Server IP:��6   $��3q�6*   �� 5      -   5         ��Name$ ServerIp��5      $��3q�6B   ���#3D3D3D
�������$	��250��5      $
��Left=�5      ��5   (   �� *
ServerIp+5      �� 5      $��Zammad Token:��6   $��3q�6-   �� 5      -   5        $ ZammadToken��5      $��2q�6H   ���#3D3D3D
�������$	��760��5      $
��Left=�5       ��5   +   �� *ZammadToken+5       �� 5#      $��ChatGPT Token:��6   $��3q�6.   �� 5$      -   5        $ GptToken��5$      $��3q�6B   ���#3D3D3D
�������$	��760��5'      $
��Left=�5(      ��5$   (   �� *
GptToken+5(      �� 5)      -   5         ��Name$ SaveConnectionDetails��5)   7   $��Save Connection Details��6   $��10q�6V   $	��333��6b   $
��Left=�6n   5*      �� 5-   
   $��1��6   .+�5.      �� $��Loaded Server IP:��6   $��3q�61   �� 5/      -   5        $ LoadedServerIp��5/      $��3q�6N   ���#3D3D3D
�������$	��250��52      $
��Left=�53      ��5/   .   �� *LoadedServerIp+53      �� 54      $��Loaded Zammad Token:��6   $��3q�64   �� 55      -   5        $ LoadedZammadToken��55      $��3q�6T   ���#3D3D3D
�������$	��760��58      $
��Left=�59      ��55   1   �� *LoadedZammadToken+59      �� 5:      $��Loaded ChatGPT Token:��6   $��3q�65   �� 5;      -   5        $ LoadedChatGPTToken��5;      $��3q�6R   ���#3D3D3D
�������$	��760��5>      $
��Left=�5?      ��5;   2   �� *LoadedGptToken+5?      �� 5@      -   5        $ LoadConnectionDetails��5@   8   $��Check Connection Details��6   $��10q�6W   $	��333��6c   $
��Left=�6o   5A      5B      5C      